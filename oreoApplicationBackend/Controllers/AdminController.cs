using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using oreoApplicationBusinessLayer.IBusinessService;
using oreoApplicationCommonLayer.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace oreoApplicationBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly IAdminBL adminBL;
        IConfiguration configuration;

        public AdminController(IAdminBL adminBL, IConfiguration configuration)
        {
            this.adminBL = adminBL;
            this.configuration = configuration;
        }

        [HttpPost()]
        public IActionResult AdminRegister(AdminRegistration adminUser)
        {
            try
            {
                if (this.adminBL.AdminRegister(adminUser))
                {
                    return this.Ok(new { Success = true, Message = "The admin has been added successfully !!!" });
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        new { Success = false, Message = "Sorry, admin has not been added !!! " });
                }
            }
            catch (Exception exception)
            {
                if (exception != null)
                {
                    return StatusCode(StatusCodes.Status409Conflict,
                        new { Success = false, ErrorMessage = "Cannot add duplicate email id." });
                }
                else
                {
                    return this.BadRequest(new { success = false, Message = exception.Message });
                }

            }
        }

        [HttpPost("Login")]
        public ActionResult AdminLogin(AdminLogin login)
        {
            try
            {
                var result = this.adminBL.AdminLogin(login);
                if (result != null)
                {
                    string token = GenrateJWTToken(result.Email, result.AdminId,result.Role);
                    return this.Ok(new
                    {
                        success = true,
                        Message = "You have logged in successfully !!!",
                        Data = result,
                        Token = token
                    });
                }
                else
                {
                    return this.NotFound(new { Success = false, Message = "Sorry user login was unsuccessfully" });
                }
            }
            catch (Exception e)
            {

                return this.BadRequest(new { Success = false, Message = e.Message });

            }
        }

        private string GenrateJWTToken(string email, long id, string Role)
        {
            var secretkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Key"]));
            var signinCredentials = new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256);
            string userId = Convert.ToString(id);
            var claims = new List<Claim>
                        {
                            new Claim("email", email),
                            new Claim(ClaimTypes.Role, Role),
                            new Claim("id",userId),

                        };
            var tokenOptionOne = new JwtSecurityToken(

                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: signinCredentials
                );
            string token = new JwtSecurityTokenHandler().WriteToken(tokenOptionOne);
            return token;
        }
    }
}
