using MongoDB.Driver;

namespace MatchCityNameApi.Interfaces
{
    public interface IMongoDbFactory
    {
        IMongoCollection<T> GetCollection<T>(string databaseName, string collectionNme);
    }
}
