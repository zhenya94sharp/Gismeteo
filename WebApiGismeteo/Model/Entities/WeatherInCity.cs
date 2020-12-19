using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApiGismeteo.Model.Entities
{
    public class WeatherInCity
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

         [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Href")]
        public string Href { get; set; }

        [BsonElement("ListTenDaysWeather")]
         public List<Weather> ListTenDaysWeather { get; set; }
    }
}
