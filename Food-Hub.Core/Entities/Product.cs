using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Hub.Core.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public int MerchantId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public Restaurant Restaurant { get; set; }
        public ICollection<ProductDetail> ProductDetails { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
