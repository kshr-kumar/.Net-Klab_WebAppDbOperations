using System.ComponentModel.DataAnnotations.Schema;

namespace EFCodeFirst
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }
    }
}
