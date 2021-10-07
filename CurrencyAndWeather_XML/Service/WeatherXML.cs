using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml;

namespace CurrencyAndWeather_XML.Service
{
    class WeatherXML
    {
        XmlDocument xdoc = null;
            Dictionary<string, int> cities = new Dictionary<string, int>();
        public WeatherXML()
        {
            xdoc = new XmlDocument();
            Init();
        }
        public void Init()
        {
            cities.Add("Lutsk", 33187);
            cities.Add("Odessa", 33837);
            cities.Add("Kyiv", 33345);
            cities.Add("Rivne", 33301);
            cities.Add("Sarny", 33088);
        }
       
        public void GetWeather()
        {
            int select = 0;
            do
            {
                Console.WriteLine("Aviable cities to watch weather: \n");
                foreach (var c in cities)
                {
                    Console.WriteLine(c.Key + "  ");
                }
                Console.WriteLine();
                Console.WriteLine("\n Input name of city: ");
                var city = Console.ReadLine();
                var result = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(city);
                foreach (var item in cities)
                {
                    if (item.Key == result)
                    {
                        xdoc.Load($"http://informer.gismeteo.by/rss/" + item.Value + ".xml");
                    }
                }
                XmlNodeList xNodelts = xdoc.DocumentElement.SelectNodes("//channel/item");
                foreach (XmlNode xNode in xNodelts)
                {
                    Console.WriteLine($"Name of City: {xNode.SelectSingleNode("title").InnerText}");
                    Console.WriteLine($"Description: {xNode.SelectSingleNode("description").InnerText}");
                    Console.WriteLine($"Category: {xNode.SelectSingleNode("category").InnerText}");

                }
                Console.WriteLine("Press any key...");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Do you want to change weather of city again? : 1{yep} / 2{nope} : ");
               select = Convert.ToInt32(Console.ReadLine());
            } while (select!=2);
        }

    }
}
