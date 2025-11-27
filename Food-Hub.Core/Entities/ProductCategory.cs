using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Hub.Core.Entities
{
    public class ProductCategory
    {
        public int ProductId { get; set; }
        public int CategoryOfProductId { get; set; }
        public Product Product { get; set; }
        public bool IsDeleted { get; set; }
        public CategoryOfProduct CategoryOfProduct { get; set; }
    }
}
