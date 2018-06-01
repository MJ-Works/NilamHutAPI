using System;
using System.Collections.Generic;

namespace NilamHutAPI.Models
{
    public class HomeProducts
    {
        public Guid productId { get; set; }
        public int bidPrice { get; set; }
        public double basePrice { get; set; }
        public string bidderId { get; set; }
        public String bidderName { get; set; }
        public String image { get; set; }
        public DateTime? endDate { get; set; }
        public DateTime? startDate { get; set; }
    }
}