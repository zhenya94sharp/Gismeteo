using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GismeteoWinClassLibrary;
using HtmlAgilityPack;

namespace GismeteoWinService.Controllers
{
    class ParserController
    {
        List<WeatherInCity> tempList = new List<WeatherInCity>();
        private List<Weather> tempListWeathers;
        private Weather tempWeather;
        private HtmlNodeCollection tegsCollection;
        string htmlData;

        public async Task<string> LoadHtml(string url)
        {
            HttpClient client = new HttpClient();

            string htmlData;

            try
            {
                HttpResponseMessage message = await client.GetAsync(url);

                if (message.StatusCode == HttpStatusCode.OK)
                {
                    htmlData = await message.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new Exception("Ошибка загрузки. ErrorCode:" + message.StatusCode);
                }

                return htmlData;
            }
            catch (Exception e)
            {
                throw e;
            }


        }

        public List<WeatherInCity> GetListCities(HtmlDocument doc)
        {
            tegsCollection = doc.DocumentNode.SelectNodes("//noscript[@id='noscript']");

            HtmlNodeCollection childCollection = tegsCollection[0].ChildNodes;

            for (int i = 0; i < childCollection.Count; i += 2) //города и ссылки
            {
                string href = childCollection[i].GetAttributeValue("href", "not found");
                string name = childCollection[i].GetAttributeValue("data-name", "not found");

                WeatherInCity cityAndHref = new WeatherInCity()
                {
                    Name = name,
                    Href = $"https://gismeteo.ru{href}10-days"
                };
                tempList.Add(cityAndHref);
            }

            return tempList;
        }

        private void CreateNewListWeather()
        {
            tempListWeathers = new List<Weather>();
        }

        private void GetWind(HtmlDocument doc)
        {
            tegsCollection = doc.DocumentNode.SelectNodes("//span[@class='unit unit_wind_m_s']");
            string wind;

            for (int i = 0; i < 10; i++)
            {
                wind = tegsCollection[i].InnerText;
                wind = wind.Replace('\n', ' ');
                wind = wind.Replace(" ", "") + " м/с";

                tempWeather = new Weather()
                {
                    Wind = wind
                };

                tempListWeathers.Add(tempWeather);
            }

            Console.WriteLine(DateTime.Now + ":Получены данные о ветре на 10 дней");
        }

        private void GetTemperature(HtmlDocument doc)
        {
            int index = 0;

            tegsCollection = doc.DocumentNode.SelectNodes("//span[@class='unit unit_temperature_c']");

            for (int i = 0; i < 20; i++)
            {
                string temperature = tegsCollection[i].InnerText;

                if (temperature.Length > 4)
                {
                    temperature = temperature.Remove(0, 6);
                    temperature = temperature.Replace(';', '-') + " C";
                }


                if (i == 0 || i % 2 == 0)
                {
                    tempListWeathers[index].TemperatureDay = temperature;
                }
                else
                {
                    tempListWeathers[index].TemperatureNight = temperature;
                    index++;
                }
            }

            Console.WriteLine(DateTime.Now + ":Получены данные о температуре на 10 дней");
        }

        private void GetPressure(HtmlDocument doc)
        {
            string pressure;

            tegsCollection = doc.DocumentNode.SelectNodes("//span[@class='unit unit_pressure_mm_hg_atm']");

            for (int i = 1; i < 11; i++)
            {
                pressure = tegsCollection[i].InnerText;
                pressure = pressure.Replace('\n', ' ');
                pressure = pressure.Replace(" ", "") + " мм рт.ст.";

                tempListWeathers[i - 1].Pressure = pressure;
            }

            Console.WriteLine(DateTime.Now + ":Получены данные о давлении на 10 дней");
        }

        private void GetPrecipitation(HtmlDocument doc)
        {
            string precipitation;

            tegsCollection = doc.DocumentNode.SelectNodes("//div[@class='w_prec__value']"); //осадки kakaya to fignya parsitsa

            if (tegsCollection == null)
            {
                precipitation = "Без осадков";

                for (int i = 0; i < 10; i++)
                {
                    tempListWeathers[i].Precipitation = precipitation;
                }
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    precipitation = tegsCollection[i].InnerText;
                    precipitation = precipitation.Replace('\n', ' ');
                    precipitation = precipitation.Replace(" ", "") + " мм";

                    tempListWeathers[i].Precipitation = precipitation;
                }
            }

        }

        private void GetHumidity(HtmlDocument doc)
        {
            string humidity;
            tegsCollection = doc.DocumentNode.SelectNodes("//span[@class='tooltip']");

            for (int i = 0; i < 10; i++)
            {
                humidity = tegsCollection[i].GetAttributeValue("data-text", "not found");

                if (humidity.Contains("&"))
                {
                    humidity = humidity.Remove(humidity.IndexOf('&'), 5);
                    humidity = humidity.Replace(';', ' ');
                }

                tempListWeathers[i].Humidity = humidity;
            }

            Console.WriteLine(DateTime.Now + ":Получены данные об осадках на 10 дней");
        }

        private void GetSvgImage(HtmlDocument doc, string cityName)
        {
            tegsCollection = doc.DocumentNode.SelectNodes("//svg");

            for (int i = 5; i < 15; i++)
            {
                string svg = tegsCollection[i].OuterHtml;

                File.WriteAllText($@"C:\Users\G580\Documents\GitHub\Gismeteo\WinFormsClient\bin\Debug\Images\{cityName}{i - 4}.svg", svg);
            }
        }

        private void GetDate(HtmlDocument doc)
        {
            tegsCollection = doc.DocumentNode.SelectNodes("//div[@class='w_date__day']");
            int index = 0;
            int index2 = 0;

            for (int i = 0; i < 10; i++)
            {
                string date = tegsCollection[i].InnerHtml;
                string date2;

                if (date == "Вс" || date == "Сб")
                {
                    date2= doc.DocumentNode.SelectNodes("//span[@class='w_date__date weekend']")[index].InnerHtml;
                    date2 = date2.Replace('\n', ' ');
                    date2 = date2.Replace(" ", "");
                    index++;
                }
                else
                {
                    date2 = doc.DocumentNode.SelectNodes("//span[@class='w_date__date black']")[index2].InnerHtml;
                    date2 = date2.Replace('\n', ' ');
                    date2 = date2.Replace(" ", "");
                    index2++;
                }
                tempListWeathers[i].Date = date+" "+date2;
            }
        }

        private List<Weather> GetListWeathers(HtmlDocument doc, string cityName)
        {
            GetSvgImage(doc, cityName);
            CreateNewListWeather();
            GetWind(doc);
            GetDate(doc);
            GetTemperature(doc);
            GetPressure(doc);
            GetPrecipitation(doc);
            GetHumidity(doc);
            return tempListWeathers;
        }

        public async Task<List<WeatherInCity>> GetAllWeatherInCity(List<WeatherInCity> listWeatherInCities)
        {
            HtmlDocument doc = new HtmlDocument();
            bool result = false;
            List<WeatherInCity> allWeathers = new List<WeatherInCity>();

            foreach (WeatherInCity weather in listWeatherInCities)
            {
                result = false;

                do
                {
                    try
                    {
                        Thread.Sleep(500);
                        htmlData = await LoadHtml(weather.Href);
                        result = true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Ошибка загрузки данных, проверьте соединение" + e.Message);
                        Console.ReadKey();
                    }
                } while (!result);

                doc.LoadHtml(htmlData);

                Console.WriteLine(DateTime.Now +
                                  $": Начинаем парсить погоду в г.{weather.Name} по ссылке {weather.Href}");

                List<Weather> listWeathers = GetListWeathers(doc, weather.Name);

                WeatherInCity weatherInCity = new WeatherInCity()
                {
                    Name = weather.Name,
                    Href = weather.Href,
                    ListTenDaysWeather = listWeathers
                };

                allWeathers.Add(weatherInCity);
                Console.WriteLine();
            }

            return allWeathers;
        }
    }
}
