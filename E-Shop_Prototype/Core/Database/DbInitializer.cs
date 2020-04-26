using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Shop_Mini.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Shop_Mini.Database
{
    public static class DbInitializer
    {
        private static string EncryptPassword(string password)
        {
            var data = System.Text.Encoding.ASCII.GetBytes(password);
            var hash = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            return System.Text.Encoding.ASCII.GetString(hash);
        }
        public static void Initialize(SqlServerContext context)
        {
            // Look for any students.
            if (context.User.Any())
            {
                return;   // DB has been seeded
            }

            context.Database.Migrate();

            var users = new User[]
            {
            new User{Id = Guid.NewGuid(), UserName = "admin", Password = EncryptPassword("toor")},
            };
            foreach (var u in users)
            {
                context.User.Add(u);
            }

            context.SaveChanges();

            var cat1Id = Guid.NewGuid();
            var cat2Id = Guid.NewGuid();

            var categories = new Category[]
            {
            new Category{Id = cat1Id, Name = "Books"},
            new Category{Id = cat2Id, Name = "Technology"},
            };
            foreach (var c in categories)
            {
                context.Category.Add(c);
            }
            context.SaveChanges();

            var products = new Product[]
            {
            new Product{Id = Guid.NewGuid(), CategoryId = cat1Id, Name = "Lord of the Rings", ImagePath = "./Images/Lotr.jpg", SpecificationFilePath = "./Spec/Lotr.pdf", Description = "Lord of the rings book, just now in the shop. best seller", Price = 2000},
            new Product{Id = Guid.NewGuid(), CategoryId = cat2Id, Name = "Lord of the PCs", ImagePath = "./Images/pc.jpg", SpecificationFilePath = "./Spec/pc.pdf", Description = "Lord of the PCs, just now in the shop. best PC", Price = 4000},            };
            foreach (var e in products)
            {
                context.Product.Add(e);
            }
            context.SaveChanges();
        }
    }
}
