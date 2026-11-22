using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Orders.Data.Models
{
    public class User : IdentityUser
    {

        [Required]
        public string FullName { get; set; } = null!;

        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string? Address { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDelete { get; set; }


        public User()
        {
            CreatedAt = DateTime.Now;
        }

    }
}
