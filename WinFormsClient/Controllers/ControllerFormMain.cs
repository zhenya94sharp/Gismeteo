﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Windows.Forms;
using System.Threading.Tasks;
using GismeteoWinClassLibrary;
using Newtonsoft.Json;
using Svg;

namespace WinFormsClient
{
    class ControllerFormMain
    {
        private FormMain form;
        private List<WeatherInCity> weathersList;

        public ControllerFormMain(FormMain form)
        {
            this.form = form;
            weathersList=new List<WeatherInCity>();
        }

        public async Task<List<WeatherInCity>> GetWeather()
        {
            try
            {
                HttpClient client = new HttpClient();

                HttpResponseMessage message =
                    await client.GetAsync("https://localhost:44310/Gismeteo/");

                string json = await message.Content.ReadAsStringAsync();

                if (message.StatusCode == HttpStatusCode.OK)
                {
                    weathersList = JsonConvert.DeserializeObject<List<WeatherInCity>>(json);

                    return weathersList;
                }
                else
                {
                    MessageBox.Show(json+" Приложение будет закрыто");
                    Application.Exit();
                    return null;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка соединения с Api! Приложение будет закрыто "+e.Message);
                Application.Exit();
                return null;
            }
        }

        public void DrawWeather(int indexCity, int indexDay)
        {
            try
            {
                if (indexDay == -1)
                {
                    indexDay = 0;
                }
                SvgDocument image = SvgDocument.Open($@"Images\{weathersList[indexCity].Name}{indexDay + 1}.svg");
                form.pictureBox.Image = image.Draw();
                form.labelName.Text = weathersList[indexCity].Name;
                form.labelTemperatureDay.Text = weathersList[indexCity].ListTenDaysWeather[indexDay].TemperatureDay;
                form.labelTemperatureNight.Text = weathersList[indexCity].ListTenDaysWeather[indexDay].TemperatureNight;
                form.labelHumidity.Text = weathersList[indexCity].ListTenDaysWeather[indexDay].Humidity;
                form.labelWind.Text = weathersList[indexCity].ListTenDaysWeather[indexDay].Wind;
                form.labelPrecipitation.Text = weathersList[indexCity].ListTenDaysWeather[indexDay].Precipitation;
                form.labelPressure.Text = weathersList[indexCity].ListTenDaysWeather[indexDay].Pressure;
            }
            catch (Exception e)
            {
                MessageBox.Show("Не удалось отобразить погоду. Ошибка: "+e.Message);
            }
           
        }

    }
}
