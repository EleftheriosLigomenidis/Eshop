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
namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productReposit;

        public ProductsController(IProductRepository productReposit)
        {
            _productReposit = productReposit;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            // action result we are returning a type of http response
            // async instead of passing the request to finish it passes it into a delegateto query the database
            return Ok( await _productReposit.GetProductsAsync());


        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id )
        {
            return await _productReposit.GetProductByIdAsync(id);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<ProductBrand>> GetProductBrands()
        {
            return Ok(await _productReposit.GetProductBrands());
        }

        [HttpGet("types")]
        public async Task<ActionResult<ProductBrand>> GetProductTypes()
        {
            return Ok(await _productReposit.GetProductTypes());
        }
    }
}