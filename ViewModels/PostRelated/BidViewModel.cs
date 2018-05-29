using System;
using System.ComponentModel.DataAnnotations;
using NilamHutAPI.Models;

namespace NilamHutAPI.ViewModels.PostRelated
{
    public class BidViewModel
    {
        [Required]
        [Range(1,10000000)]
        public int BidPrice { get; set; }

        [Required]
        public String ApplicationUserId { get; set; }

        [Required]
        public Guid ProductId { get; set; }
    }
}