using System;
using System.Collections.Generic;
namespace NilamHutAPI.ViewModels.FrontEnd
{
    public class UserInfo
    {
        public Guid userId { get; set; }
        public String  applicationUserId { get; set; }
        public string fullName { get; set; }
        public Guid cityId { get; set; }
        public String cityName { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string  postCode { get; set; }
        public string email { get; set; }
        public string image { get; set; }
    }
}