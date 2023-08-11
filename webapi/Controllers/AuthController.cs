using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using webapi.Data;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("BookStore/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApiUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public AuthController(RoleManager<IdentityRole> roleManager, UserManager<ApiUser> userManager, ApplicationDbContext context, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _configuration = configuration;
            _context = context;
            _webHostEnvironment = webHostEnvironment;

        }



        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register([FromBody] ApiUser apiUser)
        {

            var users = await _userManager.Users.ToListAsync();

            bool IsFirstUser = users.Count == 0;
            string RoleName = IsFirstUser ? "Admin" : "User";

            var user = new ApiUser
            {
                EnName = apiUser.EnName,
                ArName = apiUser.ArName,
                Email = apiUser.Email,
                UserName = apiUser.UserName,
            };

            IdentityRole role = await _roleManager.FindByNameAsync(RoleName);

            if (role == null)
            {
                role = new IdentityRole(RoleName);
                await _roleManager.CreateAsync(role);
            }


            var result = await _userManager.CreateAsync(user, apiUser.Password);

            if (result.Succeeded)
            {

                await _userManager.AddToRoleAsync(user, RoleName);

            }

            if (result.Errors.Any())
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            return Ok(result);
        }



        [HttpPost]
        [Route("logIn")]
        public async Task<ActionResult<AuthResponse>> Login([FromBody] ApiUser apiUser)
        {

            var user = await _userManager.FindByEmailAsync(apiUser.Email);
            bool ValidPassword = await _userManager.CheckPasswordAsync(user, apiUser.Password);
            if (user == null)
            {
                return BadRequest("Email Can't be Found");
            }

            var userId = user.Id;
            if (ValidPassword)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));

                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var roles = await _userManager.GetRolesAsync(apiUser);
                var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();
                var userClaims = await _userManager.GetClaimsAsync(apiUser);
                var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub , apiUser.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email,apiUser.Email),
                    new Claim("uid",userId)
                }.Union(userClaims).Union(roleClaims);


                var token = new JwtSecurityToken(
                   issuer: _configuration["JwtSettings:Issuer"],
                   audience: _configuration["JwtSettings:Audience"],
                   claims: claims,
                 expires: DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["JwtSettings:DurationInMinutes"])
                  ),
                 signingCredentials: credentials

                 );
                var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");

                int UserRole = 0;
                if (isAdmin)
                {
                    UserRole = 1;
                }
                else
                {
                    UserRole = 0;

                }

                var userToken = new JwtSecurityTokenHandler().WriteToken(token);
                var AuthResponse = new
                {
                    Token = userToken,
                    UserId = userId,
                    Role = UserRole
                };

                return Ok(AuthResponse);

            }
            else
            {

                return Unauthorized();
            }

        }

    }
}