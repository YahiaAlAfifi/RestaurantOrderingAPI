using System;
using System.Collections.Generic;
using System.Text;

namespace Orders.Core.Dtos
{
    public class UpdateCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}