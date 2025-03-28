using System.ComponentModel.DataAnnotations;

namespace Inmemory_Collection.Models
{
    public class ProductModel
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public int Qty { get; set; }
        public int ProductTotalPrice =>  ProductPrice * Qty;
        public int CategoryId { get; set; }
    }
}
