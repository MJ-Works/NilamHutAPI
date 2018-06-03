using System;
using System.Collections.Generic;

namespace NilamHutAPI.ViewModels.FrontEnd
{
    public class UserPosts
    {
        public Guid PostId { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public String ProductName { get; set; }
    }
}