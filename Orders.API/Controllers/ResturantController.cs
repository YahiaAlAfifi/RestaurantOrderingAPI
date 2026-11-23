using Microsoft.AspNetCore.Mvc;
using Orders.Core.Constant;
using Orders.Core.Dtos;
using Orders.Infrastructure.Services.Resturants;

namespace Orders.API.Controllers
{
    public class ResturantController : BaseController
    {
        private readonly IResturantService _resturantService;

        public ResturantController(
            IResturantService resturantService)
        {
            _resturantService = resturantService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            string? searchKey = null)
        {
            var resturants =
                await _resturantService.GetAll(searchKey);

            return Ok(await GetResponse(resturants));
        }

        [HttpGet]
        public async Task<IActionResult> NearMe()
        {
            var userId = User.FindFirst(
                Claims.UserId)?.Value;

            if (string.IsNullOrWhiteSpace(userId))
            {
                return Unauthorized();
            }

            var resturants =
                await _resturantService.NearMe(userId);

            return Ok(await GetResponse(resturants));
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateResturantDto dto)
        {
            var savedId =
                await _resturantService.Create(dto);

            return Ok(await GetResponse(savedId));
        }
    }
}