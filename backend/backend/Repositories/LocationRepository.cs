using Microsoft.EntityFrameworkCore;

using backend.Interfaces.Repositories;
using backend.Models;
using backend.Helpers;

namespace backend.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly DataContext _context;

        public LocationRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Location> GetLocationByCity(string city)
        {
            Location? location = await _context.Locations
                .SingleOrDefaultAsync(l => l.City.ToLower() == city.ToLower());

            if (location == null)
            {
                throw new AppException("City not found", StatusCodes.Status404NotFound);
            }

            return location;
        }

    }
}
