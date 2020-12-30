using System;
using System.Collections.Generic;
using GismeteoClassLibrary;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Parser.Tools
{
    class DbManager
    {
        public void AddWeatherAsync(List<WeatherInCity> allWeathers)
        {
            try
            {
                IMongoCollection<WeatherInCity> collectionWeathers = ConnectionManager.GetCollection();

                foreach (WeatherInCity item in allWeathers)
                {
                    collectionWeathers.ReplaceOneAsync(new BsonDocument("Name", item.Name), item);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка при добавлении погоды, проверьте соединение с Бд " + e.Message);
            }
        }
    }
}
