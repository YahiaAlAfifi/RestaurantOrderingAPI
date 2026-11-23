using System;
using System.Collections.Generic;
using System.Text;

namespace Orders.Core.Dtos
{
    public class CreateResturantDto
    {
        public string Name { get; set; } = null!;
        public string? LogoUrl { get; set; }
        public string Phone { get; set; } = null!;
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string? Address { get; set; }
    }
}