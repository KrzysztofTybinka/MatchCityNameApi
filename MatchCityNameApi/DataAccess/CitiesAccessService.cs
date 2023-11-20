using MatchCityNameApi.DataAccess.Models;
using MatchCityNameApi.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Globalization;
using System.Linq.Expressions;

namespace MatchCityNameApi.DataAccess
{
    public class CitiesAccessService : ICitiesAccessService
    {
        private readonly IMongoCollection<City> _cities;

        public CitiesAccessService(IMongoDbFactory mongoDbFactory)
        {
            _cities = mongoDbFactory.GetCollection<City>(
                "geodb", "cities");
        }

        public async Task<City> GetCityAsync(string id)
        {
            var results = await _cities.FindAsync(
                x => x.Id == id);
            return await results.SingleAsync();
        }

        public async Task<IEnumerable<City>> GetCitiesAsync(
            Expression<Func<City, bool>> filter, 
            FindOptions<City> options)
        {

            var results = await _cities.FindAsync(filter, 
                options);
            return await results.ToListAsync();
        }
    }
}
