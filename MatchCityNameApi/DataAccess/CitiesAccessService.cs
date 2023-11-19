using MatchCityNameApi.DataAccess.Models;
using MatchCityNameApi.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Globalization;

namespace MatchCityNameApi.DataAccess
{
    public class CitiesAccessService : ICitiesAccessService
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

        public async Task<IEnumerable<City>> GetFilteredCitiesAsync()
        {
            var sort = Builders<City>.Sort.Ascending("dem");

            var results = await _cities.FindAsync(
                x => x.name.StartsWith("xd"),
                new FindOptions<City, City>()
                {
                    Sort = sort,
                    Limit = 5
                });

            return await results.ToListAsync();
        }
    }
}
