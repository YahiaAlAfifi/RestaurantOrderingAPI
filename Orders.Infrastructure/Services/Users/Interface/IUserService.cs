using Orders.Core.Dtos;
using Orders.Core.ViewModels;

namespace Orders.Infrastructure.Services.Users
{
    public interface IUserService
    {
        Task<List<UserViewModel>> GetAll(string? searchKey);
        Task<string> Create(CreateUserDto dto);
        Task<string> Update(UpdateUserDto dto);
        Task<string> Delete(string id);
        Task<UserViewModel> Get(string id);
    }
}