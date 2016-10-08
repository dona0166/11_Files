using System;
using System.IO;


namespace _11_Files
{
    internal class StockIO
    {


        Stock anewstock;
        public void WriteStock(StringWriter sw, Stock astock)
        {
            sw.WriteLine(astock.Symbol.ToUpper() + "\r\n" + astock.PricePerShare.ToString().Replace(".",",") + "\r\n" + astock.NumShares);
            sw.Close();
        }

        TextWriter writingtest;
        public void WriteStock(FileInfo writeonfile, Stock astock)
        {
            writingtest = writeonfile.CreateText();
            
            writingtest.WriteLine(astock.Symbol.ToUpper() + "\r\n" + astock.PricePerShare.ToString().Replace(".", ",") + "\r\n" + astock.NumShares);
            writingtest.Close();
        }

        public Stock ReadStock(StringReader data)
        {
            string symbol = data.ReadLine();
            double price = Convert.ToDouble(data.ReadLine().Replace(",","."));
            int number = Convert.ToInt32(data.ReadLine());
            data.Close();
            anewstock = new Stock(symbol, price, number);
            return anewstock;
        }
        TextReader readingtest;
        public Stock ReadStock(FileInfo readfromfile)
        {
            readingtest = readfromfile.OpenText();
            string symbol = readingtest.ReadLine();
            double price = Convert.ToDouble(readingtest.ReadLine().Replace(",", "."));
            int number = Convert.ToInt32(readingtest.ReadLine());
            readingtest.Close();
            anewstock = new Stock(symbol, price, number);
            return anewstock;
        }


    }
}