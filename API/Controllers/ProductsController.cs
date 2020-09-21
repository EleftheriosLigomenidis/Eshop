using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using Core.Specifications;
using API.Dtos;
using AutoMapper;
using API.errors;
using Core;
using API.Helpers;

namespace API.Controllers
{

    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productReposit;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productReposit
            ,IGenericRepository<ProductBrand> productBrandRepo,IGenericRepository<ProductType>
            productTypeRepo,IMapper mapper)
        {
            _productReposit = productReposit;
            _productTypeRepo = productTypeRepo;
            _productBrandRepo = productBrandRepo;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Pagination<Product>>>> GetProducts([FromQuery]ProductSpecParams productParams)
        {
            var spec = new ProductsWithTypesAndBrands(productParams);
            // action result we are returning a type of http response
            // async instead of passing the request to finish it passes it into a delegateto query the database
            var products =  await _productReposit.ListAsync(spec);
            var countSpecs = new ProductWithFiltersSpecification(productParams);

            var totalItems = await _productReposit.CountAsync(countSpecs);
            var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturn>>(products);
            return Ok(new Pagination<ProductToReturn>(productParams.PageIndex,productParams.PageSize,totalItems,data));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse),StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturn>> GetProduct(int id )
        {

            var spec = new ProductsWithTypesAndBrands(id);

            
            var product =  await _productReposit.GetEntityWithSpec(spec);
            if(product == null)
            {
                return NotFound(new ApiResponse(404)); // consistent errors
            }
            return _mapper.Map<Product, ProductToReturn>(product);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _productBrandRepo.ListAllAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductTypes()
        {
            return Ok(await _productTypeRepo.ListAllAsync());
        }
    }
}