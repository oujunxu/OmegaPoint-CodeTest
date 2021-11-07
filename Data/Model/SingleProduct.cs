﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OmegaPointSimpleAPI.Data.Model
{
    public class SingleProduct
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        public float Rate { get; set; }
        public int Count { get; set; }
    }
}
