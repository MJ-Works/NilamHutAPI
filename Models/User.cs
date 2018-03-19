using System;
using System.ComponentModel.DataAnnotations;
namespace NilamHutAPI.Models
{
    public class User
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }
    }
}