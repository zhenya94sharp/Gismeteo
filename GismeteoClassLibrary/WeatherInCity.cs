using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GismeteoClassLibrary
{
    public class WeatherInCity
    {
        public ObjectId Id { get; set; }

        [BsonElement("Name")] 
        public string Name { get; set; }

        [BsonElement("Href")] 
        public string Href { get; set; }

        [BsonElement("ListTenDaysWeather")] 
        public List<Weather> ListTenDaysWeather { get; set; }
    }
}
