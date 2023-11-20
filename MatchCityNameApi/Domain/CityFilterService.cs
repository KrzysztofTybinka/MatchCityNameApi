using MatchCityNameApi.DataAccess;
using MatchCityNameApi.DataAccess.Models;
using MatchCityNameApi.Interfaces;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace MatchCityNameApi.Domain
{
    public class CityFilterService
    {
        private ICitiesAccessService _cityAccessService;


        public CityFilterService(ICitiesAccessService cities)
        {
            _cityAccessService = cities;
        }

        public async Task<IEnumerable<City>> GetFilteredCitiesAsync(string startsWith, int? limit)
        {
            if (string.IsNullOrEmpty(startsWith) 
                || startsWith.Length < 2)
            {
                throw new BadHttpRequestException("Invalid query string");
            }

            Expression<Func<City, bool>> filter = 
                x => x.name.StartsWith(startsWith);

            var findOptions = new FindOptions<City, City>()
            {
                Sort = Builders<City>.Sort.Descending("dem"),
                Limit = limit
            };

            return await _cityAccessService.GetCitiesAsync(filter, findOptions);
        }
    }
}
