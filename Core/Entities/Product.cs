﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Runtime;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Product : BaseEntity
    {
        
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public string ProductPhotoUrl { get; set; }

        public int ProductBrandId { get; set; }


        public ProductBrand ProductBrand { get; set; }

        public int ProductTypeId { get; set; }

        public ProductType ProductType { get; set; }
    }
}
