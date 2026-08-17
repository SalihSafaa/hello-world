namespace HelloWorld
{
    public class CatalogService : ICatalogService
    {
        //test
            private static List<Category> categories = new List<Category>
            {
                new Category(1, "Electronics", "Devices and gadgets"),
                new Category(2, "Books", "Literature and educational materials"),
                new Category(3, "Clothing", "Apparel and accessories")
            };
            private static List<Product> products = new List<Product>
            {
                new Product(1, "Laptop", 999.99m, 1),
                new Product(2, "Smartphone", 499.99m, 1),
                new Product(3, "Novel", 19.99m, 2),
                new Product(4, "T-Shirt", 14.99m, 3)
            };
        public IEnumerable<Category> GetCategories()
        {
            return categories;
            //throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProducts()
        {
            return products;
            //throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
        {
            var productsOfCategory=new List<Product>();
            foreach(var product in products)
            {
                if(product.CategoryId==categoryId)
                {
                    productsOfCategory.Add(product);
                }
            }
            return productsOfCategory;
            //throw new NotImplementedException();
        }

        public Category? GetCategoryById(int id)
        {
            foreach(var category in categories)
            {
                if(category.Id==id)
                {
                    return category;
                }
            }
            Console.WriteLine("Category not found");
            return null;
        }

        public Product? GetProductById(int id)
        {
            foreach(var product in products)
            {
                if(product.Id==id)
                {
                    return product;
                }
            }
            Console.WriteLine("Product not found");
            return null;
            //throw new NotImplementedException();
        }

        public void AddCategory(string name, string description="general")
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Category name cannot be empty.");
                return;
            }
            Category newCategory=new Category(categories.Count() + 1, name, description);
            categories.Add(newCategory);
            Console.WriteLine($"Category added: {newCategory}");
            //Console.WriteLine("not implemented yet");
        }

        public void AddProduct(string name, decimal price, int categoryId)
        {
            if(string.IsNullOrWhiteSpace(name)||price<=0||(categories.Find(c=>c.Id==categoryId)==null))
            {
                Console.WriteLine("Invalid product details. Please provide a valid name, price, and category.");
                return;
            }
            Product newProduct=new Product(products.Count() + 1, name, price, categoryId);
            products.Add(newProduct);
            Console.WriteLine($"Product added: {newProduct}");
            //Console.WriteLine("not implemented yet");
        }

        public void UpdateCategory(int id, string newName, string newDescription="general")
        {
            if(string.IsNullOrWhiteSpace(newName))
            {
                Console.WriteLine("Category name cannot be empty.");
                return;
            }
            else if(categories.Find(c=>c.Id==id)==null)
            {
                Console.WriteLine("Category not found");
                return;
            }
            else
            {
                var categoryToUpdate=categories.Find(c=>c.Id==id);
                categoryToUpdate.Name=newName;
                categoryToUpdate.Description=newDescription;
                Console.WriteLine($"Category updated: {categoryToUpdate}");
            }
            Console.WriteLine("not implemented yet");
        }

        public void UpdateProduct(int id, string newName, decimal newPrice, int newCategoryId)
        {
            if(products.Find(p=>p.Id==id)==null)
            {
                Console.WriteLine("Product not found");
                return;
            }
            else if(categories.Find(c=>c.Id==newCategoryId)==null)
            {
                Console.WriteLine("Category not found");
                return;
            }
            else if(string.IsNullOrWhiteSpace(newName))
            {
                Console.WriteLine("Product name cannot be empty.");
                return;
            }
            else if(newPrice<=0)
            {
                Console.WriteLine("Product price must be greater than zero.");
                return;
            }
            else
            {
                var productToUpdate=products.Find(p=>p.Id==id);
                productToUpdate.Name=newName;
                productToUpdate.Price=newPrice;
                productToUpdate.CategoryId=newCategoryId;
                Console.WriteLine($"Product updated: {productToUpdate}");
            }
            
            //Console.WriteLine("not implemented yet");
        }

        public void DeleteCategory(int id)
        {
            if(categories.Find(c=>c.Id==id)==null)
            {
                Console.WriteLine("Category not found");
                return;
            }
            else
            {
                Console.WriteLine($"Are you sure you want to delete this category {categories.Find(c=>c.Id==id).Name} ? (y/n)");

                do
                {
                    var confirmation = Console.ReadLine();
                    if (confirmation == "y")
                    {
                        var categoryToDelete=categories.Find(c=>c.Id==id);
                        categories.Remove(categoryToDelete);
                        Console.WriteLine($"Category deleted: {categoryToDelete}");
                    }
                    else if (confirmation == "n")
                    {
                        Console.WriteLine("Category deletion canceled.");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
                    }
                } while (true); 
            }
            //Console.WriteLine("not implemented yet");
        }

        public void DeleteProduct(int id)
        {
            if (products.Find(p => p.Id == id) == null)
            {
                Console.WriteLine("Product not found");
                return;
            }
            else
            {
                Console.WriteLine($"Are you sure you want to delete this product {products.Find(p => p.Id == id).Name}? (y/n)");
                do
                {
                    var confirmation = Console.ReadLine();
                    if (confirmation == "y")
                    {
                        var productToDelete = products.Find(p => p.Id == id);
                        products.Remove(productToDelete);
                        Console.WriteLine($"Product deleted: {productToDelete}");
                    }
                    else if (confirmation == "n")
                    {
                        Console.WriteLine("Product deletion canceled.");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
                    }
                } while (true);

            }
            //Console.WriteLine("not implemented yet");
        }
    }
}