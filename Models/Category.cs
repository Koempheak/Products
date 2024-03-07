using System.ComponentModel.DataAnnotations;

namespace Products.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
}
