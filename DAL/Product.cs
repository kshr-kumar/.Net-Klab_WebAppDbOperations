
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCodeFirst
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        public decimal Price { get; set; }
        public int CategoryId { get; set; }   // Navigation Property Name

        [ForeignKey("CategoryId")] //forign key
        public Category Category { get; set; }
    }
}
