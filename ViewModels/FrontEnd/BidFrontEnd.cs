using System;
using System.Collections.Generic;

namespace NilamHutAPI.ViewModels.FrontEnd
{
    public class BidFrontEnd
    {
        public Guid ProductId { get; set; }
        public double BidPrice { get; set; }
        public DateTime BidTime { get; set; }
        public Guid UserId { get; set; }
        public String UserName { get; set; }
        public string userAddress { get; set; }
        public string userImage { get; set; }
    }
    
}