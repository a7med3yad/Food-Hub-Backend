using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Hub.Core.Entities
{
    public class RestaurantCategory
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public int CategoryOfRestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        public bool IsDeleted { get; set; }
        public CategoryOfRestaurant CategoryOfRestaurant { get; set; }
    }
}
