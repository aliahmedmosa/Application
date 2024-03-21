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
            if (userDTO is null) return new GeneralResponse(false,"Model is empty");
            var newUser = new AppUser()
            {
                Name = userDTO.Name,
                Email = userDTO.Email,
                PasswordHash = userDTO.Password,
                UserName = userDTO.Email
            };
            var user = await userManager.FindByEmailAsync( newUser.Email );
            if (user is not null) return new GeneralResponse(false, "User Registered alraedy");
            
            var createUser=await userManager.CreateAsync( newUser!,userDTO.Password );
            if (!createUser.Succeeded) return new GeneralResponse(false, "Error Occured .. Please try again ! ");
            
            //Assign Defult Role :Admin too first registration
            var checkAdmin = await roleManager.FindByNameAsync("Admin");
            if(checkAdmin is null)
            {
                await roleManager.CreateAsync(new IdentityRole() { Name = "Admin" });
                await userManager.AddToRoleAsync(newUser, "Admin");
                return new GeneralResponse(true, "Account Created");
            }
            else
            {
                var checkUser = await roleManager.FindByNameAsync("User");
                if (checkUser is null)
                    await roleManager.CreateAsync(new IdentityRole() { Name = "User" });
                await userManager.AddToRoleAsync(newUser, "User");
                return new GeneralResponse(true, "Account created");
            }
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

            string token =await CreateJwtToken(user);
            return new LoginResponse(true, token, "Login Completed");
        }
        private async Task<string> CreateJwtToken(AppUser user)
        {
            var userClaims = await userManager.GetClaimsAsync(user);
            var roles = await userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
            {
                roleClaims.Add(new Claim("roles", role));
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(roleClaims)
            .Union(userClaims);
            var x = config["Jwt:Key"]!;
            var symmerticSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]!));
            var signingCredentials = new SigningCredentials(symmerticSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: config["Jwt:Issuer"],
                audience: config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }
        
    }
}
