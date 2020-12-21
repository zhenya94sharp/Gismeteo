using System;
using System.Collections.Generic;
using System.Threading;
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
            DbConnectionManager manager = new DbConnectionManager();

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
                    catch (Exception e)
                    {
                        Console.WriteLine("Ошибка загрузки данных, проверьте соединение" + e.Message);
                    }
                } while (!result);

                doc.LoadHtml(htmlData);

                try
                {
                    List<WeatherInCity> listCities = controller.GetListCities(doc);

                    List<WeatherInCity> allWeathers = await controller.GetAllWeatherInCity(listCities);

                    manager.AddWeatherAsync(allWeathers);

                    Console.WriteLine(DateTime.Now + ":Все данные о погоде добавлены в Бд");
                    Console.WriteLine("************");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ошибка соединения" + e.Message);
                }
                Thread.Sleep(500);


                Console.WriteLine("Для повторного запуска нажмите Enter. Для выхода введите exit");
                string answer = Console.ReadLine();

                status = answer != "exit";
            } while (status == true);
        }
    }
}
