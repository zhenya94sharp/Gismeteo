using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GismeteoWinClassLibrary;
using MongoDB.Driver;

namespace GismeteoWinService.Tools
{
    class ConnectionManager
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
                throw new Exception("Ошибка при получении коллекции, проверьте соединение с Бд " + e.Message);
            }
        }


    }
}
