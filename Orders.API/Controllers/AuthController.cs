using Microsoft.AspNetCore.Mvc;
using Orders.Core.Dtos;
using Orders.Infrastructure.Services.Auth;
using Microsoft.AspNetCore.Authorization;


namespace Orders.API.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(
            [FromBody] LoginDto dto)
        {
            var result = await _authService.Login(dto);

            return Ok(await GetResponse(result));
        }
    }
}