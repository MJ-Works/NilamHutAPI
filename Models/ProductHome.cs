using System;
using System.Collections.Generic;
namespace NilamHutAPI.Models
{
    public class ProductHome
    {
        public Guid productId { get; set; }
        // public int bidPrice { get; set; }
        public double basePrice { get; set; }
        // public Guid bidderId { get; set; }
        public Bid Bid { get; set; }
        public Image Image { get; set; }
        public DateTime? endDate { get; set; }
        public DateTime? startDate { get; set; }
    }
}