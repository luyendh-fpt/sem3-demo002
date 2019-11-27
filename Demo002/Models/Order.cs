using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo002.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string MemberId { get; set; }
        public int PaymentTypeId { get; set; }
        public double TotalPrice { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipPhone { get; set; }

        public long CreatedAt { get; set; }
        public long UpdatedAt { get; set; }
        public long DeletedAt { get; set; }
        public int Status { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}