using System;
using System.Collections.Generic;
using System.Text;

namespace Orders.Core.Dtos
{
    public class CreateUserDto
    {
        public string FullName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string Address { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}