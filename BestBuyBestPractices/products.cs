using System;
namespace BestBuyBestPractices
{
    public class products
    {
        public products()
        {
        }

        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryID { get; set; }
        public int OnSale { get; set; }
        public string StockLevel { get; set; }

    }
}
