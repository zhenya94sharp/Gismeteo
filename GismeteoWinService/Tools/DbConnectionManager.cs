using System;
using System.Collections.Generic;
using System.Linq;
using GismeteoWinClassLibrary;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Parser.Tools
{
    class DbConnectionManager
    {
        private MongoClient client;
        private IMongoDatabase db;
        private IMongoCollection<WeatherInCity> collectionWeathers;

        private MongoClient GetClient()
        {
            if (client == null)
            {
                client = new MongoClient("mongodb://localhost:27017");
            }

            return client;
        }
        public DbConnectionManager()
        {
            client = GetClient();

            db = client.GetDatabase("gismeteo");

            collectionWeathers = db.GetCollection<WeatherInCity>("weather");
        }

        public IMongoCollection<WeatherInCity> GetCollection()
        {

            db = client.GetDatabase("gismeteo");
            collectionWeathers = db.GetCollection<WeatherInCity>("weather");
            return collectionWeathers;
        }

        public void AddWeatherAsync(List<WeatherInCity> allWeathers)
        {
            try
            {
                foreach (WeatherInCity item in allWeathers)
                {
                    collectionWeathers.ReplaceOneAsync(new BsonDocument("Name", item.Name), item);
                }

                //await collectionWeathers.InsertManyAsync(allWeathers);
            }
            catch (Exception e)
            {
                throw new Exception("Ошибка при добавлении погоды " + e.Message);
            }
        }
    }
}
