using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Hub.Core.Entities
{
    public class ProductDetailAttribute
    {
        public int Id { get; set; }
        public int ProductDetailId { get; set; }
        public int AttributeId { get; set; }
        public int MeasureUnitId { get; set; }
        public string Value { get; set; }
        public ProductDetail ProductDetail { get; set; }
        public Attribute Attribute { get; set; }
        public bool IsDeleted { get; set; }
        public MeasureUnit MeasureUnit { get; set; }
    }
}
