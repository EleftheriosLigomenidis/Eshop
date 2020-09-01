using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
     public class ProductRepository : IProductRepository
    {
        private readonly EshopDb _context;
        public ProductRepository(EshopDb context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrands()
        {
            return await _context.ProductBrands.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products
                  .Include(p => p.ProductBrand)
                .Include(p => p.ProductType)
                .FirstOrDefaultAsync(p => p.Id == id); 
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _context.Products
                .Include(p => p.ProductBrand)
                .Include(p => p.ProductType)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypes()
        {
            return await _context.ProductTypes.ToListAsync();
        }
    }
}
