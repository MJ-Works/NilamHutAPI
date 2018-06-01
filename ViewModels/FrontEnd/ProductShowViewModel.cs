using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using NilamHutAPI.Models;

namespace NilamHutAPI.ViewModels.FrontEnd
{
    public class ProductShowViewModel
    {
        public Guid posterId { get; set; }
        public Guid userId { get; set; }
        public string userName { get; set; }
        public string userImage { get; set; }
        public string userPhone { get; set; }
        public string userCity { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string ProductName { get; set; }
        public String ProductDescription { get; set; }
        public String Quantity { get; set; }
        public double BasePrice { get; set; }
        public String ContactInfo { get; set; }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public Guid CityId { get; set; }
        public string CityName { get; set; }
        public List<string> Image { get; set; }
        public List<BidFrontEnd> Bids { get; set; }
    }
}