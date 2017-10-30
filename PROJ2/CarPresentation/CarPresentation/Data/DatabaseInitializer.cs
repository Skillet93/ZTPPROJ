using MongoDB.Driver;

namespace CarPresentation.Data
{
    public class DatabaseInitializer
    {
        public static IMongoDatabase Initialize()
        {
            var client = new MongoClient(Constants.Db.DatabaseUrl);
            return client.GetDatabase(Constants.Db.DatabaseName);
        }
    }
}