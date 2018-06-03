using System;
using System.Collections.Generic;

namespace NilamHutAPI.ViewModels.FrontEnd
{
    public class UserBids
    {
        public Guid BidId { get; set; }
        public Guid? ProductId { get; set; }
        public string ProductName { get; set; }
        public DateTime BidTime { get; set; }
        public DateTime BidEndTime { get; set; }
        public int BidPrice { get; set; }

    }
}