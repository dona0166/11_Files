using System.IO;
using System;

namespace _11_Files
{
    internal class FileStockRepository : IStockRepository, IFileRepository
    {
        private DirectoryInfo repositoryDir;
        public bool start = false;

        
        public FileStockRepository(DirectoryInfo repositoryDir)
        {
            
            this.repositoryDir = repositoryDir;
            
           
        }
        

        public FileStockRepository()
        {
            
        }

        public int count = 0;
        public long NextId()
        {
            
            count++;
            
            //Convert.ToInt64(repositoryDir.Name + count.ToString());

            return count;
        }

        //public void SaveStock(Stock astock)
        //{

        //}

        //public Stock LoadStock(long anid)
        //{

        //}

        //public ICollection FindAllStocks()
        //{

        //}

        //public void Clear()
        //{

        //}


    }
}