using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Windows.Forms;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Svg;
using WinFormsClient.Entities;

namespace WinFormsClient
{
    class ControllerFormMain
    {
        private FormMain form;

        public ControllerFormMain(FormMain form)
        {
            this.form = form;
        }

        public async Task<List<WeatherInCity>> GetWeather()
        {
            try
            {
                HttpClient client = new HttpClient();

                HttpResponseMessage message =
                    await client.GetAsync("https://localhost:44300/api/Gismeteo/GetListWeather/");

                string json = await message.Content.ReadAsStringAsync();

                if (message.StatusCode == HttpStatusCode.OK)
                {
                    List<WeatherInCity> weathersList = JsonConvert.DeserializeObject<List<WeatherInCity>>(json);

                    return weathersList;
                }
                else
                {
                    throw new Exception(json);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Ошибка Api! " + e.Message);
            }
        }

        public void DrawWeather(WeatherInCity weather, int indexDay)
        {
            if (weather == null)
            {
                MessageBox.Show("Вначале загрузите погоду");
                return;
            }

            SvgDocument image = SvgDocument.Open($@"C:\Users\G580\Documents\GitHub\Gismeteo\Images\{weather.Name}{indexDay+1}.svg");
            form.pictureBox.Image = image.Draw();
            form.labelName.Text = weather.Name;
            form.labelTemperatureDay.Text = weather.ListTenDaysWeather[indexDay].TemperatureDay;
            form.labelTemperatureNight.Text = weather.ListTenDaysWeather[indexDay].TemperatureNight;
            form.labelHumidity.Text = weather.ListTenDaysWeather[indexDay].Humidity;
            form.labelWind.Text = weather.ListTenDaysWeather[indexDay].Wind;
            form.labelPrecipitation.Text = weather.ListTenDaysWeather[indexDay].Precipitation;
            form.labelPressure.Text = weather.ListTenDaysWeather[indexDay].Pressure;
        }

    }
}
