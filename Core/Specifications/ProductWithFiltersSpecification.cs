using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Specifications
{
    public class ProductWithFiltersSpecification :BaseSpecification<Product>
    {
        public ProductWithFiltersSpecification(ProductSpecParams productParams)
            : base(x => (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId) &&
            (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId) &&
            (string.IsNullOrEmpty(productParams.KeyWord) || x.Name.Contains(productParams.KeyWord)))
        {

        }
    }
}
