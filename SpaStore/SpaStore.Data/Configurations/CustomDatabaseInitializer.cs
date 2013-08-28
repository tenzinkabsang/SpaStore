using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using SpaStore.Model;

namespace SpaStore.Data.Configurations
{
    //public class CustomDatabaseInitializer : DropCreateDatabaseIfModelChanges<EfDbContext>
    //{
    //    protected override void Seed(EfDbContext context)
    //    {
    //        base.Seed(context);
    //    }
    //}

    public class CustomDatabaseInitializer : CreateDatabaseIfNotExists<EfDbContext>
    {
        protected override void Seed(EfDbContext context)
        {
            var categories = AddCategories(context);

            var products = AddProducts(context, categories);

            var images = AddImages(context, products);

            base.Seed(context);
        }


        private List<Category> AddCategories(EfDbContext context)
        {
            var names = new[] { WATERSPORT, SOCCER, CHESS, COMPUTER };

            var categories = new List<Category>();
            Array.ForEach(names, name =>
            {
                var category = new Category { Name = name };
                categories.Add(category);
                context.Categories.AddOrUpdate(category);
            });

            context.SaveChanges();
            return categories;
        }

        private List<Image> AddImages(EfDbContext context, List<Product> products)
        {
            var images = new List<Image>();

            products.ForEach(p =>
            {
                var img = new Image
                {
                    Name = "Placeholder",
                    IsPrimary = true,
                    Url = "//placehold.it/260x180",
                    ProductId = p.Id
                };

                images.Add(img);
                context.Images.AddOrUpdate(img);
            });

            context.SaveChanges();
            return images;
        }

        private List<Product> AddProducts(EfDbContext context, List<Category> categories)
        {
            var products = new List<Product>();

            products.Add(new Product
            {
                Name = "Kayak",
                Description = "A boat for one person",
                Price = 275.99m,
                Category = categories.First(c => c.Name == WATERSPORT)
            });

            products.Add(new Product
            {
                Name = "Lifejacket",
                Description = "Protective and fashionable",
                Price = 48.89m,
                Category = categories.First(c => c.Name == WATERSPORT)
            });

            products.Add(new Product
            {
                Name = "Soccer ball",
                Description = "FIFA-approved size and weight",
                Price = 19.50m,
                Category = categories.First(c => c.Name == SOCCER)
            });

            products.Add(new Product
            {
                Name = "Corner Flats",
                Description = "Give your playing field a professional touch",
                Price = 29.99m,
                Category = categories.First(c => c.Name == SOCCER)
            });

            products.Add(new Product
            {
                Name = "Thinking cap",
                Description = "Improve your brain efficiency by 75%",
                Price = 8.33m,
                Category = categories.First(c => c.Name == CHESS)
            });

            products.Add(new Product
            {
                Name = "Human Chess Board",
                Description = "A fun game for the family",
                Price = 17.99m,
                Category = categories.First(c => c.Name == CHESS)
            });

            products.Add(new Product
            {
                Name = "24 inch HD monitor",
                Description = "Crystal clear display for perfect gaming and usual programming",
                Price = 259.99m,
                Category = categories.First(c => c.Name == COMPUTER)
            });

            products.ForEach(p => context.Products.AddOrUpdate(p));
            context.SaveChanges();
            return products;
        }

        private const string WATERSPORT = "Watersport";
        private const string SOCCER = "Soccer";
        private const string CHESS = "Chess";
        private const string COMPUTER = "Computer";
    }
}