using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirst.Extended_Entities
{
    public partial class Category
    {
        [NotMapped]
        public string Description { get; set; }
    }
}
