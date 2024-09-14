﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebShop.Domain.Entities;
using WebShopProject.Domain.Entities;
using WebShopProject.Infrastructure.Database;

namespace WebShop.Infrastructure.Seeders
{
    internal class DataSeeder(ProjectDbContext dbContext) : IDataSeeder
    {
        Tuple<string, string>  hashedPasswordAndSalt = HashPassword("password");
        Tuple<string, string> hashedPasswordAndSalt2 = HashPassword("password");
        Tuple<string, string> hashedAdminPasswordAndSalt = HashPassword("password");
        Guid productId1 = new Guid("9F7A10C8-3F6D-4F4A-93F0-9D1FCE9B5687");
        Guid productId2 = new Guid("D49D82B4-1D42-44F2-8B7B-9F1B3F7A52D1");
        Guid orderId1 = new Guid("C5B8E7E2-4F3F-4A6E-B6F3-58C1D5C5E1E3");
        Guid orderId2 = new Guid("7A1E2D6C-0F8E-4A6F-9C3C-FB8B6D68D8A2");
        Guid userId1 = new Guid("3D5A9F9C-5A1F-4D1C-B9E9-6C2A9C7B2A34");
        Guid userId2 = new Guid("9A2E4D8B-6F1D-4E5F-8F1F-2C3B4A6D7E1A");
        Guid orderItemId1 = new Guid("A8B9F6C7-4D3E-4F2D-B1E8-9C5D3A7E4B6F");
        Guid orderItemId2 = new Guid("D1E9F5C3-2F4D-4A7B-9E6F-8A4C7D2B5F1A");

        private readonly static int iterations = 1000;

        private static Tuple<string, string> HashPassword(string password)
        {
            var sBytes = new byte[password.Length];
            new RNGCryptoServiceProvider().GetNonZeroBytes(sBytes);
            var salt = Convert.ToBase64String(sBytes);

            var derivedBytes = new Rfc2898DeriveBytes(password, sBytes, iterations);

            return new Tuple<string, string>
            (
                Convert.ToBase64String(derivedBytes.GetBytes(256)),
                salt
            );
        }


        public async Task Seed()
        {
            if (await dbContext.Database.CanConnectAsync())
            {
                if (!dbContext.Products.Any())
                {
                    var products = GetProducts();
                    dbContext.Products.AddRange(products);
                    await dbContext.SaveChangesAsync();
                }
                if (!dbContext.Users.Any())
                {
                    var users = GetUsers();
                    dbContext.Users.AddRange(users);
                    await dbContext.SaveChangesAsync();
                }
                
                if (!dbContext.Admins.Any())
                {
                    var admins = GetAdmins();
                    dbContext.Admins.AddRange(admins);
                    await dbContext.SaveChangesAsync();
                }
              
               
            }

        }


        private IEnumerable<Admin> GetAdmins()
        {
            return new List<Admin>
            {
                new Admin
                {
                    AdminId = Guid.NewGuid(),
                    Username = "admin",
                    Password = hashedAdminPasswordAndSalt.Item1,
                    Salt = hashedAdminPasswordAndSalt.Item2,
                    Name = "Admin",
                    Surname = "Admin",
                    Contact = "+12345678912"
                }
            };
        }

        private IEnumerable<Product> GetProducts()
        {
            var productOne = new Product
            {
                ProductId = productId1,
                Name = "Product 1",
                Description = "Description of product 1.",
                Category = "CategoryOne",
                Gender = "Male",
                Price = 1111,
                Quantity = 111,
                Image = "https://SOMEURL.jpg"
            };

            var productTwo = new Product
            {
                ProductId = productId2,
                Name = "ProductTwo",
                Description = "Product two decription.",
                Category = "CategoryTwo",
                Gender = "Female",
                Price = 1234,
                Quantity = 12,
                Image = "https://SOMEURL.jpg"
            };

            return new List<Product> { productOne, productTwo };
        }
    

        private IEnumerable<User> GetUsers()
        {
            List<User> users = [new()

            {
                UserId = userId1,
                Name = "User",
                Surname = "One",
                Username = "userone",
                Password = hashedPasswordAndSalt2.Item1,
                Salt = hashedPasswordAndSalt2.Item2,
                Address = new()
                {
                    City = "Amsterdam",
                    StreetAndNumber = "123 Street",
                    PostalCode = "1234"
                },
                Contact = "123-456-7891234",
                Orders = new List<Order>
                    {
                       new Order
                        {
                            OrderId = orderId1,
                            Date = DateTime.Now.AddDays(-7),
                            UserId = userId1,
                            isPaid = true,

                            OrderItems = new List<OrderItem>
                            {
                            new OrderItem
                                    {
                                        ProductId = productId1,
                                        OrderId = orderId1,
                                        Quantity = 2, 
                                    }
                            }
                        }
                    }
            },new (){
                UserId = userId2,
                Name = "User",
                Surname = "Two",
                Username = "usertwo",
                Password = hashedPasswordAndSalt.Item1,
                Salt = hashedPasswordAndSalt.Item2,
                Address = new Address
                {
                    City = "Novi Sad",
                    StreetAndNumber = "456 Street",
                    PostalCode = "98765"
                },
                Contact = "987-654-321",
                Orders = new List<Order>
                    {
                       new Order
                        {
                            OrderId = orderId2,
                            Date = DateTime.Now.AddDays(-7),
                            UserId = userId2,
                            isPaid = false,
                            OrderItems = new List<OrderItem>
                            {
                            new OrderItem
                                    {
                                        ProductId = productId2,
                                        OrderId = orderId2,
                                        Quantity = 1, // Example quantity

                                    }
                            }
                        }
                    }
            }

                ];

            return users;
        }
    }
}
