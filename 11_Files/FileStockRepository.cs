using System.IO;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace _11_Files
{

    internal class FileStockRepository : IStockRepository, IFileRepository
    {
        private DirectoryInfo repositoryDir;
        public TextWriter thewriter;
        public TextReader thereader;
        Dictionary<long, Stock> adictionary = new Dictionary<long, Stock>();
        Dictionary<long, Stock> anewdictionary = new Dictionary<long, Stock>();
        Stock somestock;
        
       
        
        public FileStockRepository(DirectoryInfo repositoryDir)
        {
            
            this.repositoryDir = repositoryDir;
            

        }
        
        public FileStockRepository()
        {
            
        }

        long counter = 1;
        public long NextId()
        {
            
            counter++;
            return counter;
            
        }
        
        public string StockFileName(Stock astock)
        {

            return "stock" + astock.Id + ".txt";


        }
        public string StockFileName(long stocknum)
        {

            return "stock" + stocknum.ToString() + ".txt";
        }

        public void SaveStock(Stock astock)
        {
            
            astock.Id = counter;
            thewriter = File.CreateText(repositoryDir + StockFileName(astock));
            
            thewriter.WriteLine(astock.Id);
            thewriter.WriteLine(astock.Symbol);
            thewriter.WriteLine(astock.PricePerShare);
            thewriter.WriteLine(astock.NumShares);
            adictionary.Add(counter, astock);
            thewriter.Close();
            NextId();


        }

        
        public Stock LoadStock(long anid)
        {
            thereader = new StreamReader(repositoryDir + StockFileName(anid));
            string id = thereader.ReadLine();
            string symbol = thereader.ReadLine();
            double price = Convert.ToDouble(thereader.ReadLine());
            int number = Convert.ToInt32(thereader.ReadLine());
            somestock = new Stock(symbol, price, number);
            anewdictionary.Add(anid, somestock);
            thereader.Close();
            
            return somestock;
            
        }

        public void Clear()
        {
            foreach(FileInfo file in repositoryDir.GetFiles())
            {
                file.Delete();
            }
        }

        public ICollection FindAllStocks()
        {
            return repositoryDir.GetFiles();
        }





    }
}