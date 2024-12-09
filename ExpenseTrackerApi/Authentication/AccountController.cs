using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ExpenseTrackerApi.Authentication.Models;
using ExpenseTrackerApi.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ModelLayer.Models;

namespace ExpenseTrackerApi.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(UserManager<AppUserModel> userManager, IConfiguration configuration, IUser userService) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterOrUpdateUserModel model)
        {
            //check if the model is valid
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            AppUserModel? existedUser = await userManager.FindByNameAsync(model.Username);
            if (existedUser is not null)
            {
                ModelState.AddModelError("Username registered", "Username is already taken");
                return BadRequest(ModelState);
            }

            //create a new user object
            AppUserModel newUser = new AppUserModel
            {
                UserName = model.Username,
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            //try to save the user
            IdentityResult result = await userManager.CreateAsync(newUser, model.Password);

            //If the user is successfully created return Ok

            if (result.Succeeded)
            {
                string? token = GenerateToken(model.Username);
                //Here I came up with to call the service which store the user in the business database
                User? userDbBusiness = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Username = model.Username,
                    IdentificationID = "1512121212",
                    Email = model.Email,
                    StatusId = 1
                };
                SavedAuthorization savedAuthorization = await userService.PostUser(userDbBusiness);
                return Ok(new { token, savedAuthorization });
            }

            // If there are any errors, add them to the ModelState object
            // and return the error to the client
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            // If we got this far, something failed, redisplay form
            return BadRequest(ModelState);
        }

        private string? GenerateToken(string username)
        {
            string? secret = configuration["JwtConfig:Secret"];
            string? issuer = configuration["JwtConfig:ValidIssuer"];
            string? audience = configuration["JwtConfig:ValidAudiences"];

            if (secret is null || issuer is null || audience is null)
            {
                throw new ApplicationException("Jwt is not set in the appsettings.json");
            }

            SymmetricSecurityKey signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, username),
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor);
            string token = tokenHandler.WriteToken(securityToken);
            return token;
        }
    }
}