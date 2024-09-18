﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Domain.Entities;

namespace WebShopProject.Application.Products.Dto
{
    public class ProductDto
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Category { get; set; } = default!;
        public int Quantity { get; set; }
        public string? Image { get; set; }
        public string KindOfHoney { get; set; } = default!;
        public decimal Price { get; set; }

    }
}
