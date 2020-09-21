using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrands : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrands(ProductSpecParams productParams)
            : base(x => (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId) &&
            (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId) &&
            (string.IsNullOrEmpty(productParams.KeyWord) || x.Name.ToLower().Contains(productParams.KeyWord)) // this is mine tested and worked in postman // scenario we have a search field and we want to find products by name 
            
            )  //we want the expression on the right to be executed ONLY if there is a value
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
            AddOrderBy(x => x.Name);
            // the x containes all the properties of the Product because we are specifying The Entity in
            // the inheritance of base Specification 
            ApplyPaging(productParams.PageSize * (productParams.PageIndex - 1), productParams.PageSize);
            if (!string.IsNullOrEmpty(productParams.Sort))
            {
                switch (productParams.Sort)
                {
                    case "priceAsc":
                         AddOrderBy(x => x.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDesc(x => x.Price);
                        break;
                    default:
                        AddOrderBy(x => x.Name);
                        break;

                }
           
            }

       
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
