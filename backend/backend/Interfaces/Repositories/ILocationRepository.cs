using backend.Models;

namespace backend.Interfaces.Repositories
{
    public interface ILocationRepository
    {
        public Task<Location> GetLocationByCity(string city);
    }
}
