using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Orders.API.Data;
using Orders.Data.Models;
using Orders.Core.Dtos;
using Orders.Core.ViewModels;

namespace Orders.Infrastructure.Services.Users
{
    public class UserService : IUserService
    {
        private readonly OrdersDbContext _db;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public UserService(
            OrdersDbContext db,
            IMapper mapper,
            UserManager<User> userManager)
        {
            _db = db;
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<List<UserViewModel>> GetAll(
        string? searchKey)
        {
            var users = _db.Users
                .Where(x =>
                    !x.IsDelete &&
                    (string.IsNullOrWhiteSpace(searchKey) ||
                     x.FullName.Contains(searchKey) ||
                     (x.PhoneNumber != null &&
                      x.PhoneNumber.Contains(searchKey))))
                .ToList();

            return _mapper.Map<List<UserViewModel>>(users);
        }

        public async Task<string> Create(CreateUserDto dto)
        {
            var user = _mapper.Map<User>(dto);

            user.UserName = dto.PhoneNumber;

            await _userManager.CreateAsync(
                user,
                dto.Password);

            return user.Id;
        }

        public async Task<string> Update(UpdateUserDto dto)
        {
            var user = _db.Users
                .SingleOrDefault(x =>
                    x.Id == dto.Id && !x.IsDelete);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            var updatedUser = _mapper.Map(dto, user);

            _db.Users.Update(updatedUser);
            _db.SaveChanges();

            return user.Id;
        }

        public async Task<string> Delete(string id)
        {
            var user = _db.Users
                .SingleOrDefault(x =>
                    x.Id == id && !x.IsDelete);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            user.IsDelete = true;

            _db.Users.Update(user);
            _db.SaveChanges();

            return user.Id;
        }

        public async Task<UserViewModel> Get(string id)
        {
            var user = _db.Users
                .SingleOrDefault(x =>
                    x.Id == id && !x.IsDelete);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            return _mapper.Map<UserViewModel>(user);
        }
    }
}