using System;
using System.Collections.Generic;
using System.Text;

namespace Orders.Core.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int MealCount { get; set; }
    }
}