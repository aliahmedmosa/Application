using Application.DTOs.IdentityDTOs;
using Application.Persistence.Contracts.Identity;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static Application.DTOs.IdentityDTOs.ServiceResponses;

namespace Persistence.Repositories.Identity
{
    public class AccountRepository
        (
        UserManager<AppUser> userManager,
        RoleManager<IdentityRole> roleManager,
        IConfiguration config
        ) : IUserAccount
    {
        public async Task<GeneralResponse> CreateAccount(UserDTO userDTO)
        {
            if (userDTO is null) return new ServiceResponses.GeneralResponse(false,"Model is empty");
            var newUser = new AppUser()
            {
                Name = userDTO.Name,
                Email = userDTO.Email,
                PasswordHash = userDTO.Password,
                UserName = userDTO.Email
            };
            var user = await userManager.FindByEmailAsync( newUser.Email );
            if (user is not null) return new ServiceResponses.GeneralResponse(false, "User Registered alraedy");
            
            var createUser=await userManager.CreateAsync( newUser!,userDTO.Password );
            if (!createUser.Succeeded) return new ServiceResponses.GeneralResponse(false, "Error Occured .. Please try again ! ");
            /*
            //Assign Defult Role :Admin too first registration
            var checkAdmin = await roleManager.FindByNameAsync("Admin");
            if(checkAdmin is null)
            {
                await roleManager.CreateAsync(new IdentityRole() { Name = "Admin" });
                await userManager.AddToRoleAsync(newUser, "Admin");
                return new ServiceResponses.GeneralResponse(true, "Account Created");
            }
            else
            {
                var checkUser = await roleManager.FindByNameAsync("User");
                if (checkUser is null)
                    await roleManager.CreateAsync(new IdentityRole() { Name = "User" });
                await userManager.AddToRoleAsync(newUser, "User");
                return new ServiceResponses.GeneralResponse(true, "Account created");
            }*/
            return new ServiceResponses.GeneralResponse(true, "Account created");
        }

        public async Task<LoginResponse> LoginAccount(LoginDTO loginDTO)
        {
            if (loginDTO is null)
                return new LoginResponse(false, null!, "Login container is emplty");
            
            var user = await userManager.FindByEmailAsync (loginDTO.Email);
            if(user is null)
                return new LoginResponse(false, null!, "User not found");

            bool checkPassword = await userManager.CheckPasswordAsync(user, loginDTO.Password);
            if(!checkPassword)
                return new LoginResponse(false, null!, "Invalid password/email");

            //var userRole = await userManager.GetRolesAsync(user);
            var userSession = new UserSession(user.Id, user.Name, user.Email, "Admin");
            string token = GenerateToken(userSession);
            return new LoginResponse(true, token, "Login Completed");
        }
        private string GenerateToken(UserSession userSession)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userSession.Id),
                new Claim(ClaimTypes.Name, userSession.Name),
                new Claim(ClaimTypes.Email, userSession.Email),
                new Claim(ClaimTypes.Role, userSession.Role)
            };
            var token = new JwtSecurityToken(
                issuer: config["Jwt:Issuer"],
                audience: config["Jwt:Audience"],
                claims: userClaims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
