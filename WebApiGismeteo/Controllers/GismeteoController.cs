﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using WebApiGismeteo.Model.Entities;
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
            catch (Exception)
            {
                return Conflict("Нет соединения с Бд");
            }
        }
    }
}
