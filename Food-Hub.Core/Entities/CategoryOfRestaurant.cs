using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Hub.Core.Entities
{
    public class CategoryOfRestaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<RestaurantCategory> RestaurantCategories { get; set; }
    }
}
