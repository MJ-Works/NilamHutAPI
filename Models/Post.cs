using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NilamHutAPI.Models
{
    public class Post
    {
        public Guid Id { get; set; }

        [Required]
        public Guid userId { get; set; }
        public User User { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime? StartDateTime { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime? EndDateTime { get; set; }

        [Required]
        [StringLength(1000)]
        public String ContactInfo { get; set; }

        public Country Country { get; set; }
        public Guid? CountryId { get; set; }

        public City City { get; set; }
        public Guid? CityId { get; set; }

        public Product Product { get; set; }
        public List<Bid> Bids { get; set; }
    }
}