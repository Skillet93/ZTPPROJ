using MongoDB.Driver;

namespace MultilanguageApp
{
    public class DatabaseInitializer
    {
        public static IMongoCollection<T> GetCollection<T>(string collection)
        {
            var client = new MongoClient(Constants.Db.DatabaseUrl);
            var database = client.GetDatabase(Constants.Db.DatabaseName);
            return database.GetCollection<T>(collection);
        }
    }
}