using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Hub.Core.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public decimal Subtotal { get; set; }
        public decimal DeliveryFee { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Tax { get; set; }
        public int CustomerId { get; set; }
        public int RestaurantId { get; set; }
        public string DeliveryAddress { get; set; }
        public string PaymentMethod { get; set; }
        public Decimal PaidAmount { get; set; }
        public ICollection<ProductOrder> ProductOrders { get; set; }    
    }
}
