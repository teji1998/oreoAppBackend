using Microsoft.Extensions.Configuration;
using oreoApplicationCommonLayer.Models;
using oreoApplicationRepositoryLayer.IRepositoryServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace oreoApplicationRepositoryLayer.RepositoryServices
{
    public class ProductRL:IProductRL
    {
        public SqlConnection connection;
        private readonly IConfiguration configuration;

        public ProductRL(IConfiguration configuration)
        {
            this.configuration = configuration;
            connection = new SqlConnection(this.configuration.GetConnectionString("OreoContext"));
        }
        public List<Product> GetAllProducts()
        {
            List<Product> productsList = new List<Product>();
            try
            {
                using(this.connection)
                {
                    SqlCommand command = new SqlCommand("spGetAllProducts", this.connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    this.connection.Open();
                    SqlDataReader reader =command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Product product = new Product();
                            product.ProductId = reader.GetInt32(0);
                            product.ProductName = reader.GetString(1);
                            product.ActualPrice = reader.GetDouble(2);
                            product.DiscountedPrice = reader.GetDouble(3);
                            product.ProductQuantity = reader.GetInt32(4);
                            product.ProductImage = reader.GetString(5);
                            productsList.Add(product);
                        }
                    }
                }
                Console.WriteLine(productsList);
                return productsList;
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

        public bool AddProduct(Product products)
        {

            try
            {
                using (connection)
                {
                    SqlCommand sqlCommand = new SqlCommand("spProduct", this.connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@ProductName", products.ProductName);
                    sqlCommand.Parameters.AddWithValue("@ActualPrice", products.ActualPrice);
                    sqlCommand.Parameters.AddWithValue("@DiscountedPrice", products.DiscountedPrice);
                    sqlCommand.Parameters.AddWithValue("@ProductQuantity", products.ProductQuantity);
                    sqlCommand.Parameters.AddWithValue("@ProductImage", products.ProductImage);
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
        /*public bool RemoveProduct(Product products)
        {
            try
            {
                using (connection)
                {
                    SqlCommand sqlCommand = new SqlCommand("spRemoveProduct", this.connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@ProductId", products.ProductId);
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
        }*/
    }
}
