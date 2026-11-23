using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Orders.API.Data;
using Orders.Core.ViewModels;
using Orders.Core.Dtos;
using Orders.Data.Models;
using Orders.Infrastructure.Extensions;

namespace Orders.Infrastructure.Services.Resturants
{
    public class ResturantService : IResturantService
    {
        private readonly OrdersDbContext _db;
        private readonly IMapper _mapper;

        public ResturantService(
            OrdersDbContext db,
            IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<ResturantViewModel>> GetAll(
            string? searchKey)
        {
            var resturants = await _db.Resturants
                .Include(x => x.Meals)
                .Where(x =>
                    string.IsNullOrWhiteSpace(searchKey) ||
                    x.Name.Contains(searchKey))
                .ToListAsync();

            return _mapper
                .Map<List<ResturantViewModel>>(resturants);
        }
        public async Task<int> Create(
              CreateResturantDto dto)
        {
            var resturant = _mapper.Map<Resturant>(dto);

            await _db.Resturants.AddAsync(resturant);
            await _db.SaveChangesAsync();

            return resturant.Id;
        }

        public async Task<List<ResturantViewModel>> NearMe(
    string userId)
        {
            var user = await _db.Users
                .SingleOrDefaultAsync(x =>
                    x.Id == userId && !x.IsDelete);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            var resturants = await _db.Resturants
                .Include(x => x.Meals)
                .ToListAsync();

            var distances = new Dictionary<int, double>();

            var userLocation = new Coordinates(
                (double)user.Latitude!,
                (double)user.Longitude!);

            foreach (var resturant in resturants)
            {
                var resturantLocation = new Coordinates(
                    (double)resturant.Latitude!,
                    (double)resturant.Longitude!);

                var distance =
                    userLocation.DistanceTo(resturantLocation);

                distances.Add(resturant.Id, distance);
            }

            var nearestIds = distances
                .OrderBy(x => x.Value)
                .Take(10)
                .Select(x => x.Key)
                .ToList();

            var nearResturants = nearestIds
                .Select(id =>
                    resturants.Single(x => x.Id == id))
                .ToList();

            return _mapper
                .Map<List<ResturantViewModel>>(nearResturants);
        }
    }
}