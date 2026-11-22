using Orders.Core.Dtos;
using Orders.Core.ViewModels;

namespace Orders.Infrastructure.Services.Categories
{
    public interface ICategoryService
    {
        Task<List<CategoryViewModel>> GetAll(string searchKey);
        Task<int> Create(CreateCategoryDto dto);
        Task<int> Update(UpdateCategoryDto dto);
        Task<int> Delete(int id);
        Task<CategoryViewModel> Get(int id);
    }
}