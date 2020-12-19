using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApiGismeteo.Model.Entities
{
    public class Weather
    {
        [BsonElement("Precipitation")]
        public string Precipitation { get; set; }

        [BsonElement("TemperatureDay")]
        public string TemperatureDay { get; set; }

        [BsonElement("TemperatureNight")]
        public string TemperatureNight { get; set; }

        [BsonElement("Wind")]
        public string Wind { get; set; }
        [BsonElement("Pressure")]
        public string Pressure { get; set; }
        [BsonElement("Humidity")]
        public string Humidity { get; set; }
    }
}
