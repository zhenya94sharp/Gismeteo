using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsClient
{
    class WeatherInCity
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
