using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinFormsClient
{
    public partial class FormMain : Form
    {
        private ControllerFormMain controller;
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            controller = new ControllerFormMain(this);
        }

        private async void buttonGetWeathers_Click(object sender, EventArgs e)
        {
            List<WeatherInCity> weather = await controller.GetWeather();
            controller.DrawWeather(0, 0);
        }

        private void comboBoxCities_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.DrawWeather(comboBoxCities.SelectedIndex, comboBoxDays.SelectedIndex);
        }

        private void comboBoxDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.DrawWeather(comboBoxCities.SelectedIndex, comboBoxDays.SelectedIndex);
        }
    }
}
