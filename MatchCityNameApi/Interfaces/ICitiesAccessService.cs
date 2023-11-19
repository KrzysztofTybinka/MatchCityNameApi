using MatchCityNameApi.DataAccess.Models;

namespace MatchCityNameApi.Interfaces
{
    public interface ICitiesAccessService
    {
        public Task<City> GetCityAsync(string id);
        public Task<IEnumerable<City>> GetFilteredCitiesAsync();
    }
}
