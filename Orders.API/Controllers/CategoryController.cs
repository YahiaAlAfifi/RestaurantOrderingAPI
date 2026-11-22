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
        public ActionResult GetAll(string searchKey)
        {
            var categories = _categoryService.GetAll(searchKey);

            return Ok(GetResponse(categories));
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var category = _categoryService.Get(id);

            return Ok(GetResponse(category));
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateCategoryDto dto)
        {
            var savedId = _categoryService.Create(dto);

            return Ok(GetResponse(savedId));
        }

        [HttpPut]
        public IActionResult Update(UpdateCategoryDto dto)
        {
            var savedId = _categoryService.Update(dto);

            return Ok(GetResponse(savedId));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var deletedId = _categoryService.Delete(id);

            return Ok(GetResponse(deletedId));
        }

    }
}