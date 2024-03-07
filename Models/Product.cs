using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Products.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string ProductName { get; set; }
		public string Manufacturer { get; set; }
		public double Price { get; set; }
        public int Quantity { get; set; }
		public string Description { get; set; }

		[ForeignKey("Categories")]
        public int CetegoryId { get; set; }
        public virtual Category Categories { get; set; }
    }
}
