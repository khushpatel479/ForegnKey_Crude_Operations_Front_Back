using System.ComponentModel.DataAnnotations;

namespace Inmemory_Collection.Models
{
    public class CategoryModel
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
