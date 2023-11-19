using MatchCityNameApi.DataAccess.Models;
using MatchCityNameApi.Interfaces;
using MongoDB.Driver;

namespace MatchCityNameApi.DataAccess
{
    public class CitiesAccessService
    {
        private readonly IMongoCollection<City> _cities;

        public CitiesAccessService(IMongoDbFactory mongoDbFactory)
        {
            _cities = mongoDbFactory.GetCollection<City>("geodb", "cities");
        }

        public async Task<City> GetCityAsync(string id)
        {
            var results = await _cities.FindAsync(x => x.Id == id);
            return await results.SingleAsync();
        }

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            var results = await _cities.FindAsync(x => x.cou_name_en.StartsWith("ab"));
            return await results.ToListAsync();
        }
    }
}
