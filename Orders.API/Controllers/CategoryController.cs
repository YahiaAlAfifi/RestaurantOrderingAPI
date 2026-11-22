using Microsoft.AspNetCore.Mvc;
using Orders.Core.Dtos;
using Orders.Infrastructure.Services.Categories;

namespace Orders.API.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(
            ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            string? searchKey = null)
        {
            var categories =
                await _categoryService.GetAll(searchKey);

            return Ok(await GetResponse(categories));
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var category =
                await _categoryService.Get(id);

            return Ok(await GetResponse(category));
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateCategoryDto dto)
        {
            var savedId =
                await _categoryService.Create(dto);

            return Ok(await GetResponse(savedId));
        }

        [HttpPut]
        public async Task<IActionResult> Update(
            UpdateCategoryDto dto)
        {
            var savedId =
                await _categoryService.Update(dto);

            return Ok(await GetResponse(savedId));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedId =
                await _categoryService.Delete(id);

            return Ok(await GetResponse(deletedId));
        }
    }
}