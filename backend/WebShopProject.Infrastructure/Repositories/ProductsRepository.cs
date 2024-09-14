using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebShop.Domain.Entities;
using WebShop.Domain.Repositories;
using WebShopProject.Domain.Entities;
using WebShopProject.Infrastructure.Database;

namespace WebShop.Infrastructure.Repositories
{
    internal class ProductsRepository(ProjectDbContext dbContext) : IProductsRepository
    {
        
        public async Task<Guid> CreateProduct(Product p)
        {

            dbContext.Products.Add(p);
            await dbContext.SaveChangesAsync();
            return p.ProductId;
        }

        public async Task DeleteProduct(Product p)
        {

            dbContext.Remove(p);
            await dbContext.SaveChangesAsync();
        }

        public Task<IEnumerable<Product>> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public async Task<Product?> GetProductById(Guid productId)
        {
            var product = await dbContext.Products
            .FirstOrDefaultAsync(x => x.ProductId == productId);
            return product;
        }

        public async Task<IEnumerable<Product>> GetProductsByCategory(string category)
        {
            var p = await dbContext.Products.Where(x => x.Category == category).ToListAsync();
            return p;
        }

        public async Task<IEnumerable<Product>> GetProductsByGender(string gender)
        {
            var products = await dbContext.Products
           .Where(u => u.Gender == gender)
           .ToListAsync();

            return products;
        }

        public async Task SaveChanges()
        {
             await dbContext.SaveChangesAsync();
        }
    }
}
