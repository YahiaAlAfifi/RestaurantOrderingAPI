using Microsoft.AspNetCore.Mvc;
using Orders.Core.Dtos;
using Orders.Infrastructure.Services.Users;

namespace Orders.API.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            string? searchKey = null)
        {
            var users =
                await _userService.GetAll(searchKey);

            return Ok(await GetResponse(users));
        }

        [HttpGet]
        public async Task<IActionResult> Get(string id)
        {
            var user =
                await _userService.Get(id);

            return Ok(await GetResponse(user));
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateUserDto dto)
        {
            var savedId =
                await _userService.Create(dto);

            return Ok(await GetResponse(savedId));
        }

        [HttpPut]
        public async Task<IActionResult> Update(
            UpdateUserDto dto)
        {
            var savedId =
                await _userService.Update(dto);

            return Ok(await GetResponse(savedId));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var deletedId =
                await _userService.Delete(id);

            return Ok(await GetResponse(deletedId));
        }
    }
}