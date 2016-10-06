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
        Stock astock;
        
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
            thewriter = File.CreateText(repositoryDir + "\\" + StockFileName(astock));
            adictionary[astock.Id] = astock;
            NextId();
            
            
        }

        public Stock LoadStock(long anid)
        {
            return adictionary[anid];
        }





    }
}