using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Project.Models;
using Project.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Project.API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IAccountService _accountService;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _config;

        public AccountController(IAccountService accountService, ITokenService tokenService, IConfiguration config)
        {
            _accountService = accountService;
            _tokenService = tokenService;
            _config = config;
        }

        [HttpGet]
        [Route("login")]
        public IActionResult Login(string userName, string password)
        {
            UserLogin userLogin = _accountService.Login(userName, password);

            if (userLogin == null)
                return Unauthorized("Invalid Credentials");

            var token = _tokenService.CreateToken(userLogin);

            return Ok(token);
        }

        //[HttpGet]
        //[Route("login")]
        //public IActionResult Login(string userName, string password)
        //{
        //    UserLogin userLogin = _accountService.Login(userName, password);

        //    if (userLogin != null)
        //    {

        //        var claims = new List<Claim>
        //        {
        //            new Claim(ClaimTypes.Name, userLogin.Name),
        //            new Claim("UserId", Convert.ToString(userLogin.Id), ClaimValueTypes.Integer)
        //        };

        //        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Secret"]));

        //        var token = new JwtSecurityToken(
        //            issuer: _config["JWT:ValidIssuer"],
        //            audience: _config["JWT:ValidAudience"],
        //            claims: claims,
        //            expires: DateTime.Now.AddMinutes(120),
        //            signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
        //        );

        //        return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        //    }
        //    return BadRequest();
        //}

    }
}
