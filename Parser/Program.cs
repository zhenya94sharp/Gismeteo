﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GismeteoClassLibrary;
using HtmlAgilityPack;
using Parser.Controllers;
using Parser.Tools;

namespace Parser
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ParserController controller = new ParserController();
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
                    Console.WriteLine("Для запуска программы нажмите Enter...");
                    Console.ReadLine();

                    try
                    {
                        url = "https://www.gismeteo.ru/";
                        htmlData = await controller.LoadHtml(url);
                        result = true;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Ошибка загрузки данных, проверьте соединение. Нажмите Enter чтобы повторить загрузку...");
                    }
                } while (!result);

                doc.LoadHtml(htmlData);

                List<WeatherInCity> listCities = controller.GetListCities(doc);

                List<WeatherInCity> allWeathers = await controller.GetAllWeatherInCity(listCities);

                manager.AddWeatherAsync(allWeathers);

                Console.WriteLine(DateTime.Now + ":Все данные о погоде добавлены в Бд");
                Console.WriteLine();


                Console.WriteLine("Для повторного запуска нажмите Enter. Для выхода введите exit");
                string answer="";
                answer = Console.ReadLine();

                status = answer != "exit";
            } while (status == true);
        }
    }
}
