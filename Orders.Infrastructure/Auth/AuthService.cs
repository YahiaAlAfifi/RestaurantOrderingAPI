using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Orders.API.Data;
using Orders.Core.Dtos;
using Orders.Core.Exceptions;
using Orders.Core.ViewModels;
using Orders.Data.Models;
using Microsoft.IdentityModel.Tokens;
using Orders.Core.Constant;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Orders.Infrastructure.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly OrdersDbContext _db;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public AuthService(
            OrdersDbContext db,
            UserManager<User> userManager,
            IMapper mapper)
        {
            _db = db;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<LoginResponseViewModel> Login(LoginDto dto)
        {
            var user = await _db.Users
                .SingleOrDefaultAsync(x => x.UserName == dto.Username);

            if (user == null)
            {
                throw new InvalidUsernameOrPassword();
            }

            var result = await _userManager
                .CheckPasswordAsync(user, dto.Password);

            if (!result)
            {
                throw new InvalidUsernameOrPassword();
            }

            var accessToken = await GenerateAccessToken(user);
            var userViewModel = _mapper.Map<UserViewModel>(user);

            return new LoginResponseViewModel
            {
                AccessToken = accessToken,
                User = userViewModel
            };
        }
        private async Task<AccessTokenViewModel> GenerateAccessToken(User user)
        {
            var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
    {
        new Claim(JwtRegisteredClaimNames.Sub, user.UserName!),
        new Claim(JwtRegisteredClaimNames.Email, user.Email!),
        new Claim(Claims.UserId, user.Id),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

            if (roles.Any())
            {
                claims.Add(
                    new Claim(ClaimTypes.Role, string.Join(",", roles)));
            }

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("vhvhljlnljn23fkhjgfvjf"));

            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256);

            var expires = DateTime.Now.AddMonths(7);

            var accessToken = new JwtSecurityToken(
                "https://localhost:7147/",
                "https://localhost:7147/",
                claims,
                expires: expires,
                signingCredentials: credentials);

            return new AccessTokenViewModel
            {
                AccessToken =
                    new JwtSecurityTokenHandler().WriteToken(accessToken),
                ExpireAt = expires
            };
        }
    }
}