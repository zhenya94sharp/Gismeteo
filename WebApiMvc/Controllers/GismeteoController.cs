using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using GismeteoClassLibrary;
using MongoDB.Bson;
using MongoDB.Driver;
using WebApiMvc.Models.Tools;

namespace WebApiMvc
{
    public class GismeteoController : Controller
    {
        public IActionResult Index()
        {
            try
            {
                IMongoCollection<WeatherInCity> collectionW = DbConnectionManager.GetCollectionWeather();

                List<WeatherInCity> listWeathers = collectionW.Find(new BsonDocument()).ToList();

                return Ok(listWeathers);
            }
            catch (Exception e)
            {
                return Conflict("Ошибка! Проверьте соединение с Бд " + e.Message);
            }
        }

    }
}
