﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly EshopDb _context;

        public ProductsController(EshopDb context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            // action result we are returning a type of http response
            // async instead of passing the request to finish it passes it into a delegateto query the database
            return Ok( await  _context.Products.ToListAsync());


        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id )
        {
            
            return await _context.Products.FindAsync(id);
        }
    }
}