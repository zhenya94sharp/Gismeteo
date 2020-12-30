using System;
using MongoDB.Driver;

namespace GismeteoClassLibrary
{
    public static class ConnectionManager
    {
        public static IMongoCollection<WeatherInCity> GetCollection()
        {
            try
            {
                MongoClient client = new MongoClient("mongodb://localhost:27017");

                IMongoDatabase db = client.GetDatabase("gismeteo");

                IMongoCollection<WeatherInCity> collectionWeathers = db.GetCollection<WeatherInCity>("weather");
                return collectionWeathers;
            }
            catch (Exception e)
            {
                throw new Exception("Ошибка при получении коллекции, проверьте соединение с Бд "+e.Message);
            }
           
        }
    }
}
