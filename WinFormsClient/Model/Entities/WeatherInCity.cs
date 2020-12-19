using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsClient.Entities
{
    class WeatherInCity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Href { get; set; }
        public List<Weather> ListTenDaysWeather { get; set; }
    }
}
