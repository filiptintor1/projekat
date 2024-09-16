using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Domain.Entities;
using WebShopProject.Domain.Repositories;
using WebShopProject.Infrastructure.Database;

namespace WebShopProject.Infrastructure.Repositories
{
    internal class OrderItemsRepository(ProjectDbContext dbContext) : IOrderItemsRepository
    {
        public async Task CreateOrderItem(OrderItem oi)
        {
            dbContext.OrderItems.Add(oi);
            await dbContext.SaveChangesAsync();
            
        }

        public async Task DeleteOrderItem(OrderItem oi)
        {
            dbContext.Remove(oi);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrderItem>> GetAllOrderItems()
        {
            var items = await dbContext.OrderItems.ToListAsync();
            return items;
        }

        public async Task SaveChanges()
        {
           await dbContext.SaveChangesAsync();  
        }
    }
}
