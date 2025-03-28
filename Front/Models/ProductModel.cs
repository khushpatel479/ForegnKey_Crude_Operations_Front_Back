namespace Inmemory_Consumer.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public int Qty { get; set; }
        public int ProductTotalPrice => ProductPrice * Qty;
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
