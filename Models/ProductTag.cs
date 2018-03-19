using System;
namespace NilamHutAPI.Models
{
    public class ProductTag
    {
        public Guid ProductId { get; set; }
        public Guid TagId { get; set; }
        public Product Product { get; set; }
        public Tag Tag { get; set; }
    }
}