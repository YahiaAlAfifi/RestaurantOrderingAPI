using System;
using System.Collections.Generic;
using System.Text;

namespace Orders.Core.ViewModels
{
    public class ResturantViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? LogoUrl { get; set; }
        public string Phone { get; set; } = null!;
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string? Address { get; set; }
        public int MealCount { get; set; }
    }
}