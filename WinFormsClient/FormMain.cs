using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinFormsClient.Entities;

namespace WinFormsClient
{
    public partial class FormMain : Form
    {
        private List<WeatherInCity> weather;
        private int indexCity;
        private int indexDay;

        private ControllerFormMain controller;
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            controller = new ControllerFormMain(this);
            indexCity = 0;
            indexDay = 0;
        }

        private async void buttonGetWeathers_Click(object sender, EventArgs e)
        {
            try
            {
                weather = await controller.GetWeather();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            
            controller.DrawWeather(weather[indexCity],indexDay);
        }

        private void comboBoxCities_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (weather == null)
            {
                MessageBox.Show("Сначала загрузите погоду");
                return;
            }
            indexCity = comboBoxCities.SelectedIndex;

            controller.DrawWeather(weather[indexCity], indexDay);
        }

        private void comboBoxDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (weather == null)
            {
                MessageBox.Show("Сначала загрузите погоду");
                return;
            }
               
            indexDay = comboBoxDays.SelectedIndex;

            controller.DrawWeather(weather[indexCity], indexDay);
        }
    }
}
