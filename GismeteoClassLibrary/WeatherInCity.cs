using System;
using System.Collections.Generic;
using System.Text;

namespace GismeteoClassLibrary
{
    public class WeatherInCity
    {
        public string Name
        {
            get; set;
        }

        public string Href
        {
            get; set;
        }

        public List<Weather> ListTenDaysWeather
        {
            get; set;
        }
    }
}
