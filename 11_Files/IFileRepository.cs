namespace _11_Files
{
    internal interface IFileRepository
    {
        string StockFileName(Stock astock);

        string StockFileName(long astick);

        void SaveStock(Stock astock);

        
    }
}