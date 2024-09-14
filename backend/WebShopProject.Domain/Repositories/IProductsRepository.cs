using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShopProject.Domain.Entities;

namespace WebShop.Domain.Repositories;

public interface IProductsRepository
{
    Task<IEnumerable<Product>> GetAllProducts();
    Task<Product?> GetProductById(Guid productId);
    Task<IEnumerable<Product>> GetProductsByGender(string gender);
    Task<IEnumerable<Product>> GetProductsByCategory(string category);
    Task<Guid> CreateProduct(Product p);
    Task DeleteProduct(Product p);

   // Task<(IEnumerable<Product>, int)> GetAllMatchingAsync(int pageSize, int pageNumber, string? searchPhrase, string? category, string? gender, string? sortBy, SortDirection sortDirection);
    Task SaveChanges();


}
