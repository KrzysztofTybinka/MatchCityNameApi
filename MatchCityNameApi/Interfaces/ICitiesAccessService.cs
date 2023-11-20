using MatchCityNameApi.DataAccess.Models;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace MatchCityNameApi.Interfaces
{
    public interface ICitiesAccessService
    {
        public Task<City> GetCityAsync(string id);
        public Task<IEnumerable<City>> GetCitiesAsync(Expression<Func<City, bool>> filter, FindOptions<City, City> options);
    }
}
