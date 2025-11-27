using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Hub.Core.Entities
{
    public class Restaurant
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string RestaurantName { get; set; }
        public string Description { get; set; }
        public bool IsOpen { get; set; }
        public DateTime CreatedAt { get; set; }
        public User User { get; set; }
        public ICollection<Product> Products { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<RestaurantCategory> RestaurantCategories { get; set; }
    }
}
