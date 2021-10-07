using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace CurrencyAndWeather_XML.Service
{
    class PrivatCurrency
    {
        decimal usd_sale { get; set; }
        decimal usd_buy { get; set; }
        decimal euro_sale { get; set; }
        decimal euro_buy { get; set; }
        decimal rub_sale { get; set; }
        decimal rub_buy { get; set; }
        decimal btc_buy { get; set; }
        decimal btc_sale { get; set; }
        XmlDocument document = new XmlDocument();
        XmlElement xRoot = null;
        public PrivatCurrency()
        {
            document.Load("https://api.privatbank.ua/p24api/pubinfo?exchange&coursid=5");
            xRoot = document.DocumentElement;
        }
        public void GetCurrency()
        {
            int select = 0;
            do
            {
                Console.WriteLine("\t\t\t--- Privat 24 --- Course of currency ---\n\n");
                Console.WriteLine("1. USD\n" +
                    "2. Euro\n" +
                    "3. Rub\n" +
                    "4. BTC\n" +
                    "0. Exit\n");
                Console.Write("Which currency do you want to get? : ");
                select = Convert.ToInt32(Console.ReadLine());
                switch (select)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("You selected USD!");
                        Console.WriteLine("Buy or sale? : 1. Buy / 2. Sale ");
                        select = Convert.ToInt32(Console.ReadLine());
                        switch (select)
                        {
                            case 1:
                                Console.WriteLine($"Result: {GetUSD_Buy()}\n\n");
                                break;
                            case 2:
                                Console.WriteLine($"Result: {GetUSD_Sale()}\n\n");
                                break;
                        }
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("You selected EURO!");
                        Console.WriteLine("Buy or sale? : 1. Buy / 2. Sale ");
                        select = Convert.ToInt32(Console.ReadLine());
                        switch (select)
                        {
                            case 1:
                                Console.WriteLine($"Result: {GetEuro_Buy()}\n\n");
                                break;
                            case 2:
                                Console.WriteLine($"Result: {GetEuro_Sale()}\n\n");
                                break;
                        }
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("You selected RUB!");
                        Console.WriteLine("Buy or sale? : 1. Buy / 2. Sale ");
                        select = Convert.ToInt32(Console.ReadLine());
                        switch (select)
                        {
                            case 1:
                                Console.WriteLine($"Result: {GetRub_Buy()}\n\n");
                                break;
                            case 2:
                                Console.WriteLine($"Result: {GetRub_Sale()}\n\n");
                                break;
                        }
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("You selected BTC!");
                        Console.WriteLine("Buy or sale? : 1. Buy / 2. Sale ");
                        select = Convert.ToInt32(Console.ReadLine());
                        switch (select)
                        {
                            case 1:
                                Console.WriteLine($"Result: {GetBTC_Buy()}\n\n");
                                break;
                            case 2:
                                Console.WriteLine($"Result: {GetBTC_Sale()}\n\n");
                                break;
                        }
                        break;
                }
            } while (select != 0);
        }
        public decimal GetUSD_Sale()
        {

            usd_sale = decimal.Parse(xRoot.SelectSingleNode($"//row[{1}]/exchangerate/@sale").Value,
                new System.Globalization.NumberFormatInfo() { NumberDecimalSeparator = "." });
            return usd_sale;
        }
        public decimal GetUSD_Buy()
        {

            usd_buy = decimal.Parse(xRoot.SelectSingleNode($"//row[{1}]/exchangerate/@buy").Value,
                new System.Globalization.NumberFormatInfo() { NumberDecimalSeparator = "." });
            return usd_buy;
        }
        public decimal GetEuro_Sale()
        {
            euro_sale = decimal.Parse(xRoot.SelectSingleNode($"//row[{2}]/exchangerate/@sale").Value,
                new System.Globalization.NumberFormatInfo() { NumberDecimalSeparator = "." });
            return euro_sale;
        }
        public decimal GetEuro_Buy()
        {

            euro_buy = decimal.Parse(xRoot.SelectSingleNode($"//row[{2}]/exchangerate/@buy").Value,
                new System.Globalization.NumberFormatInfo() { NumberDecimalSeparator = "." });
            return euro_buy;
        }
        public decimal GetRub_Sale()
        {

            rub_sale = decimal.Parse(xRoot.SelectSingleNode($"//row[{3}]/exchangerate/@sale").Value,
                new System.Globalization.NumberFormatInfo() { NumberDecimalSeparator = "." });
            return rub_sale;
        }
        public decimal GetRub_Buy()
        {

            rub_buy = decimal.Parse(xRoot.SelectSingleNode($"//row[{3}]/exchangerate/@buy").Value,
                new System.Globalization.NumberFormatInfo() { NumberDecimalSeparator = "." });
            return rub_buy;
        }
        public decimal GetBTC_Sale()
        {

            btc_sale = decimal.Parse(xRoot.SelectSingleNode($"//row[{4}]/exchangerate/@sale").Value,
                new System.Globalization.NumberFormatInfo() { NumberDecimalSeparator = "." });
            return btc_sale;
        }
        public decimal GetBTC_Buy()
        {
            btc_buy = decimal.Parse(xRoot.SelectSingleNode($"//row[{4}]/exchangerate/@buy").Value,
                new System.Globalization.NumberFormatInfo() { NumberDecimalSeparator = "." });
            return btc_buy;
        }
        public void Show()
        {
            Console.WriteLine($"USD from UAN - Buy: {GetUSD_Buy()}, Sale: {GetUSD_Sale()}");
            Console.WriteLine($"Euro from UAN - Buy: {GetEuro_Buy()}, Sale: {GetEuro_Sale()}");
            Console.WriteLine($"Rub from UAN - Buy: {GetRub_Buy()}, Sale: {GetRub_Sale()}");
            Console.WriteLine($"Btc from UAN - Buy: {GetBTC_Buy()}, Sale: {GetBTC_Sale()}");
        }
    }
}
