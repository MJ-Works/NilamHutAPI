using System;
using System.ComponentModel.DataAnnotations;

namespace NilamHutAPI.Models
{
    public class Bid
    {
        public Guid Id { get; set; }

        [Required]
        public int BidPrice { get; set; }

        [Required]
        public String ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [Required]
        public Guid PostId { get; set; }
        public Post Post { get; set; }
    }
}