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
    public class AccountController(
        UserManager<AppUserModel> userManager,
        IConfiguration configuration,
        IUser userService) : ControllerBase
    //IConfiguration interface to get the configuration values from the appsettings.json file.
    {
        [HttpPost("register-user")]
        public Task<IActionResult> RegisterUser([FromBody] RegisterOrUpdateUserModel userModel)
        {
            return RegisterUserWithRole(userModel, AppRoles.User);
        }

        [HttpPost("register-admin")]
        public Task<IActionResult> RegisterAdmin([FromBody] RegisterOrUpdateUserModel userModel)
        {
            return RegisterUserWithRole(userModel, AppRoles.Admin);
        }

        [HttpPost("register-vip-user")]
        public Task<IActionResult> RegisterVipUser([FromBody] RegisterOrUpdateUserModel userModel)
        {
            return RegisterUserWithRole(userModel, AppRoles.VipUser);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            //Get the secret in the configuration
            //Check if the model is valid
            if (!ModelState.IsValid) return BadRequest(ModelState);
            AppUserModel? user = await userManager.FindByNameAsync(model.Username);
            if (user is not null)
            {
                if (await userManager.CheckPasswordAsync(user, model.Password))
                {
                    string? token = await GenerateToken(user, model.Username);
                    return Ok(new { token });
                }
            }

            //If the user is not found display an error message
            ModelState.AddModelError("Problem", "Invalid username or password");
            return BadRequest(ModelState);
        }

        private async Task<IActionResult> RegisterUserWithRole(RegisterOrUpdateUserModel userModel, string userRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            AppUserModel? existedEmail = await userManager.FindByEmailAsync(userModel.Email);
            AppUserModel? existedUser = await userManager.FindByNameAsync(userModel.Username.Normalize());

            if (existedEmail is not null || existedUser is not null)
            {
                ModelState.AddModelError("Register error", "Username or Email are already taken");
                return BadRequest(ModelState);
            }

            // Create a new user object
            AppUserModel newUser = new AppUserModel()
            {
                UserName = userModel.Username,
                Email = userModel.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            // Try to save the user
            IdentityResult newUserResult = await userManager.CreateAsync(newUser, userModel.Password);

            // Add user role
            IdentityResult roleResult = await userManager.AddToRoleAsync(newUser, userRole);

            // If the user is successfully created
            if (newUserResult.Succeeded && roleResult.Succeeded)
            {
                SavedAuthorization savedAuthorization = await CreateUserInTheBusinessDb(userModel);
                AppUserModel? createdUser = await userManager.FindByNameAsync(userModel.Username);
                string? token = await GenerateToken(createdUser!, userModel.Username);
                return Ok(new { token, savedAuthorization });
            }

            // If there are any errors, add them to the ModelState object
            // and return the error to the client
            foreach (IdentityError error in newUserResult.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            foreach (IdentityError error in roleResult.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return BadRequest(ModelState);
        }

        private async Task<SavedAuthorization> CreateUserInTheBusinessDb(RegisterOrUpdateUserModel userModel)
        {
            User userDbExpenseTracker = new User
            {
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Username = userModel.Username,
                Email = userModel.Email,
                StatusId = 1
            };
            SavedAuthorization savedAuthorization = await userService.PostUser(userDbExpenseTracker);
            return savedAuthorization;
        }

        private async Task<string?> GenerateToken(AppUserModel user, string userName)
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

            // we need to include the roles of the user in the token
            //We can use the GetRolesAsync() method to get the roles and then add them to the claims

            IList<string> userRoles = await userManager.GetRolesAsync(user);
            List<Claim> claims = new List<Claim>
            {
                new(ClaimTypes.Name, userName)
            };

            claims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
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