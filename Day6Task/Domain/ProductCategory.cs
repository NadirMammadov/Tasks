﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6Task.Domain
{
    public class ProductCategory
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
    }
}
