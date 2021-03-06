﻿using System;
using System.Collections.Generic;
using System.IO;
using System.ServiceProcess;
using System.Threading;
using GismeteoWinClassLibrary;
using GismeteoWinService.Controllers;
using GismeteoWinService.Tools;
using HtmlAgilityPack;

namespace GismeteoWinService
{
    public partial class GismeteoService : ServiceBase
    {
        public GismeteoService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Start();
        }

        protected override void OnStop()
        {
            Stop();
        }

        private void Stop()
        {
            ServiceController controller = new ServiceController("GismeteoWinService");
            controller.Stop();
        }

        private async void Start()
        {
            ParserServiceController controller = new ParserServiceController();
            HtmlDocument doc = new HtmlDocument();
            DbManager manager = new DbManager();

            string url;
            string htmlData = "";
            bool status = true;

            do
            {
                bool result = false;
                do
                {
                    try
                    {
                        url = "https://www.gismeteo.ru/";
                        htmlData = await controller.LoadHtml(url);
                        result = true;
                    }
                    catch (Exception e)
                    {
                        File.WriteAllText(@"C:\Users\G580\Documents\GitHub\Gismeteo\GismeteoWinService\bin\Debug\ErrorLog.txt", "Ошибка подключения, проверьте соединение "+e.Message);
                        Thread.Sleep(1000*10);
                    }
                } while (!result);

                doc.LoadHtml(htmlData);

                try
                {
                    List<WeatherInCity> listCities = controller.GetListCities(doc);

                    List<WeatherInCity> allWeathers = await controller.GetAllWeatherInCity(listCities);

                    manager.AddWeatherAsync(allWeathers);
                }
                catch (Exception e)
                {
                    File.WriteAllText(@"C:\Users\G580\Documents\GitHub\Gismeteo\GismeteoWinService\bin\Debug\ErrorLog.txt", "Ошибка подключения, проверьте соединение с Бд и Интернетом " + e.Message);
                    Thread.Sleep(1000*10);
                }
                Thread.Sleep(1000 *3600*24);
            } while (status == true);
        }
    }
}
