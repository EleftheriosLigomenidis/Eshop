using API.Dtos;
using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductToReturn, string>
    {
        private readonly IConfiguration _config;

        public ProductUrlResolver(IConfiguration configuration)
        {
            _config = configuration;
        }
        public string Resolve(Product source, ProductToReturn destination, string destMember, ResolutionContext context)
        {
            // check if url is empty or not

            if (!string.IsNullOrEmpty(source.ProductPhotoUrl))
            {
                // key ===> apiurl vulue ===> httpt....
                return _config["ApiUrl"] + source.ProductPhotoUrl;
            }

            return null;
        }
    }
}
