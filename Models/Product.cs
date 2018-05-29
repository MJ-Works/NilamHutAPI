using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace NilamHutAPI.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        [Required]
        public string ApplicationUserId { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime? StartDateTime { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime? EndDateTime { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }

        [Required]
        [StringLength(1000)]
        public String ProductDescription { get; set; }

        [Required]
        [Range(1,100000)]
        public String Quantity { get; set; }
        
        [Required]
        [Range(1,10000000)]
        public double BasePrice { get; set; }

        [Required]
        [StringLength(1000)]
        public String ContactInfo { get; set; }

        public Category Category { get; set; }
        //[Required]
        public Guid? CategoryId { get; set; }

        public City City { get; set; }
        //[Required]
        public Guid? CityId { get; set; }

        public List<Bid> Bids { get; set; }

        public List<Image> Image { get; set; }

        public List<ProductTag> Tags { get; set; }
    }
}