using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Proyecto.Infrastructure.Context.Security;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Api.Controllers.v1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ApiUsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        public ApiUsersController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        private UserToken BuildToken(UserInfo userInfo, IList<string> roles)
        {
            var claims = new List<Claim>{
                new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            foreach (var rol in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, rol));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddMinutes(5);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: expiration,
                signingCredentials: creds
            );

            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };


        }

        [HttpPost("sign-up")]
        public async Task<ActionResult<UserToken>> CreateUser([FromBody] UserInfo userInfo)
        {
            var user = new ApplicationUser { UserName = userInfo.Email, Email = userInfo.Email };
            var result = await _userManager.CreateAsync(user, userInfo.Password);
            if (result.Succeeded)
            {
                return BuildToken(userInfo, new List<string>());
            }
            else
            { 
                return BadRequest(new { errors = result.Errors.ToList() });
            }
        }

        [HttpPost("log-in")]
        public async Task<ActionResult<UserToken>> LogInUser([FromBody] UserInfo userInfo)
        {
            var result = await _signInManager.PasswordSignInAsync(userInfo.Email, userInfo.Password, isPersistent: false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                var usuario = await _userManager.FindByEmailAsync(userInfo.Email);
                var roles = await _userManager.GetRolesAsync(usuario);
                return BuildToken(userInfo, roles);
            }
            else
            {
                return BadRequest("Intento de Log-In inválido");
            }
        }
    }
}
