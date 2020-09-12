﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ProductToReturn
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public string ProductPhotoUrl { get; set; }



        public string ProductBrand { get; set; }

   

        public string ProductType { get; set; }
    }
}