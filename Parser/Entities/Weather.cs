using System;

namespace Parser.Entities
{
    class Weather
    {
        public string Precipitation
        {
            get; set;
        }
        public string TemperatureDay
        {
            get; set;
        }

        public string TemperatureNight
        {
            get; set;
        }
        public string Wind
        {
            get; set;
        }
        public string Pressure
        {
            get; set;
        }
        public string Humidity
        {
            get; set;
        }

        public string Date { get; set; }
    }
}
