using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Hub.Core.Entities
{
    public class ProductDetail
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int? AvailableQuantity { get; set; }
        public bool IsDeleted { get; set; }
        public Product Product { get; set; }
        public ICollection<ProductOrder> ProductOrders { get; set; }
        public ICollection<ProductDetailAttribute> ProductDetailAttributes { get; set; }
    }
}
