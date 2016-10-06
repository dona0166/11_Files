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
        public FileInfo afile;
        public TextWriter thewriter;
        Dictionary<long, Stock> adictionary = new Dictionary<long, Stock>();
        List<long> alist = new List<long>();
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
            thewriter.Close();
            adictionary[astock.Id] = astock;
            //newname = "new" + astock.Symbol.Substring(0, 1).ToUpper() + astock.Symbol.Substring(1);
            NextId();
            
            
        }

        string newname = "";
        public Stock LoadStock(long anid)
        {
            
            adictionary[anid].Symbol = "new" + adictionary[anid].Symbol.Substring(0, 1).ToUpper() + adictionary[anid].Symbol.Substring(1);
            somestock = adictionary[anid];
            
        }





    }
}