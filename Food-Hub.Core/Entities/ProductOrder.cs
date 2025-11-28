using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Hub.Core.Entities
{
    public class ProductOrder
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductDetailId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public Order Order { get; set; }
        public bool IsDeleted { get; set; }
        public ProductDetail ProductDetail { get; set; }
    }
}
