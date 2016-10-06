using System.Collections.Generic;
using System.Collections;

namespace _11_Files
{
    internal interface IStockRepository
    {
        long NextId();
        void SaveStock(Stock astock);
        Stock LoadStock(long id);
    }
}