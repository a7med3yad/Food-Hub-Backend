using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Hub.Core.Entities
{
    public class Attribute
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<ProductDetailAttribute> ProductDetailAttributes { get; set; }
    }
}
