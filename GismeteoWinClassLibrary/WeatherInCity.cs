using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace GismeteoWinClassLibrary
{
    public class WeatherInCity
    {

        [BsonElement("Name")]
        public string Name
        {
            get; set;
        }

        [BsonElement("Href")]
        public string Href
        {
            get; set;
        }

        [BsonElement("ListTenDaysWeather")]
        public List<Weather> ListTenDaysWeather
        {
            get; set;
        }
    }
}
