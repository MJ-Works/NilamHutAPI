using System;
using System.ComponentModel.DataAnnotations;

namespace NilamHutAPI.Models
{
    public class vipUser
    {
        public Guid Id { get; set; }

        [Required]
        public String ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        
    }
}