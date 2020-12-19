using System;
using System.Collections.Generic;
using Parser.Entities;

namespace Parser
{
    class WeatherInCity
    {
        public string Name { get; set; }

        public string Href { get; set; }

        public List<Weather> ListTenDaysWeather { get; set; }
    }
}
