using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.Specifications
{
   public  class ProductsWithTypesAndBrands : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrands()
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);

            // the x containes all the properties of the Product because we are specifying The Entity in
            // the inheritance of base Specification 
        }

        // int id this constructor will get the id of a product will  call the mother constructor and will pass the expression based on the passed id
        public ProductsWithTypesAndBrands(int id)
            : base(x => x.Id == id)
        {
         
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
        }
    }
}
