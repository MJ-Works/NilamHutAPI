using System;
using System.Collections.Generic;
namespace NilamHutAPI.Models
{
    public class ProductHome
    {
        public String ProductName { get; set; }
        public Guid? CityId { get; set; }
        public Guid? CategoryId { get; set; }
        public Guid productId { get; set; }
        public double basePrice { get; set; }
        // public Guid bidderId { get; set; }
        public Bid Bid { get; set; }
        public Image Image { get; set; }
        public DateTime? endDate { get; set; }
        public DateTime? startDate { get; set; }
    }
}