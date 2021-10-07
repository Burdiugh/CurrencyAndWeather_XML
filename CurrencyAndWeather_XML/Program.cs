using CurrencyAndWeather_XML.Service;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Xml;

namespace CurrencyAndWeather_XML
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            // Task 1 ---


            //CurrencyXML xml = new CurrencyXML();
            //xml.GetCurrency();



            // Task 2 ---
            #region ConsoleColor
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Red;
            #endregion
            WeatherXML weather = new WeatherXML();
            weather.GetWeather();

           

           

            

        }
    }
}
