﻿using Microsoft.Extensions.Configuration;
using oreoApplicationCommonLayer.Models;
using oreoApplicationRepositoryLayer.IRepositoryServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace oreoApplicationRepositoryLayer.RepositoryServices
{
    public class AdminRL:IAdminRL
    {
        public SqlConnection connection;
        public readonly IConfiguration configuration;
        public AdminRL(IConfiguration configuration)
        {
            this.configuration = configuration;
            connection = new SqlConnection(this.configuration.GetConnectionString("OreoContext"));

        }


        public static string Encryptdata(string password)
        {
            string strmsg = string.Empty;
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            strmsg = Convert.ToBase64String(encode);
            return strmsg;
        }
        public static string Decryptdata(string encryptpwd)
        {
            string decryptpwd = string.Empty;
            UTF8Encoding encodepwd = new UTF8Encoding();
            Decoder Decode = encodepwd.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encryptpwd);
            int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            decryptpwd = new String(decoded_char);
            return decryptpwd;
        }

        public bool AdminRegister(AdminRegistration register)
        {
            //SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (this.connection)
                {
                    var password = Encryptdata(register.Password);
                    SqlCommand sqlCommand = new SqlCommand("spRegisterAdmin", this.connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Fullname", register.FullName);
                    sqlCommand.Parameters.AddWithValue("@Email", register.Email);
                    sqlCommand.Parameters.AddWithValue("@Password", password);
                    sqlCommand.Parameters.AddWithValue("@MobileNumber", register.MobileNumber);
                    sqlCommand.Parameters.AddWithValue("@Role", "Admin");
                    this.connection.Open();
                    int result = sqlCommand.ExecuteNonQuery();
                    if (result != 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                this.connection.Close();
            }
        }

        public AdminRegistration1 loginAdmin(AdminLogin user)
        {
            List<AdminRegistration1> users = new List<AdminRegistration1>();
            AdminRegistration1 registration = new AdminRegistration1();
            try
            {
                using (this.connection)
                {
                    var password = Encryptdata(user.Password);
                    SqlCommand command = new SqlCommand("spLoginAdmin", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@password", password);
                    this.connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            registration.AdminId = dataReader.GetInt32(0);
                            registration.FullName = dataReader.GetString(1);
                            registration.Email = dataReader.GetString(2);
                            registration.Password = dataReader.GetString(3);
                            registration.MobileNumber = dataReader.GetString(4);
                            registration.Role = dataReader.GetString(5);
                        }
                    }
                }
                return registration;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                this.connection.Close();
            }
        }


    }
}
