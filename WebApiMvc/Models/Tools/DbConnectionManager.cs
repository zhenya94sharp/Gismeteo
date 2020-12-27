﻿using System;
using GismeteoClassLibrary;
using MongoDB.Driver;

namespace WebApiMvc.Models.Tools
{
    public class DbConnectionManager
    {
        private static MongoClient client;


        private static MongoClient GetClient()
        {
            if (client == null)
            {
                client = new MongoClient("mongodb://localhost:27017");
            }

            return client;
        }

        public static IMongoCollection<WeatherInCity> GetCollectionWeather()
        {
            try
            {
                client = GetClient();

                IMongoDatabase db = client.GetDatabase("gismeteo");

                IMongoCollection<WeatherInCity> collectionWeather = db.GetCollection<WeatherInCity>("weather");

                return collectionWeather;

            }
            catch (Exception e)
            {
                throw new Exception("Ошибка! Проверьте соединение с Бд " + e.Message);
            }
        }
    }
}
