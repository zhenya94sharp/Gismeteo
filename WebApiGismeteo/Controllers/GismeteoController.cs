using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using GismeteoClassLibrary;
using MongoDB.Bson;
using MongoDB.Driver;
using WebApiGismeteo.Model.Tools;

namespace WebApiGismeteo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GismeteoController : ControllerBase
    {
        [HttpGet("GetListWeather")]
        public ActionResult GetListWeather()
        {
            try
            {
                IMongoCollection<WeatherInCity> collectionW = DbConnectionManager.GetCollectionWeather();

                List<WeatherInCity> listWeathers = collectionW.Find(new BsonDocument()).ToList();

                return Ok(listWeathers);
            }
            catch (Exception e)
            {
                return Conflict("Нет соединения с Бд"+e.Message);
            }
        }
    }
}
