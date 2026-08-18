namespace HelloWorld
{
    public class CatalogService : ICatalogService
    {
        //test
            private static List<Category> _categories = new List<Category>
            {
                new Category(1, "Electronics", "Devices and gadgets"),
                new Category(2, "Books", "Literature and educational materials"),
                new Category(3, "Clothing", "Apparel and accessories")
            };
            private static List<Product> _products = new List<Product>
            {
                new Product(1, "Laptop", 999.99m,0, 1),
                new Product(2, "Smartphone", 499.99m,1, 1),
                new Product(3, "Novel", 19.99m,6, 2),
                new Product(4, "T-Shirt", 14.99m,9, 3)
            };
        public IEnumerable<Category> GetCategories()
        {
            return _categories;
            //throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProducts()
        {
            return _products;
            //throw new NotImplementedException();
        }
        public bool CheckProductIdExist(string checkId, out Product product)
        {
            int intId=int.TryParse(checkId,out intId)? intId : -1;
            product=null;

            if(intId==-1)
            {
                Console.WriteLine("ID not found");
                return false;
            }
            else
            {
                if(_products.Any(p=>p.Id==intId))
                {
                    product=_products.SingleOrDefault(p=>p.Id==intId);
                    return true;
                }
                else
                Console.WriteLine("ID not found");
                return false;
            }
        }
        public bool CheckCategoryIdExist(string checkId, out Category category)
        {
            int intId=int.TryParse(checkId,out intId)? intId : -1;
            category=null;

            if(intId==-1)
            {
                Console.WriteLine("ID not found");
                return false;
            }
            else
            {
                if(_categories.Any(c=>c.Id==intId))
                {
                    category=_categories.SingleOrDefault(c=>c.Id==intId);
                    return true;
                }
                else
                Console.WriteLine("ID not found");
                return false;
            }
        }

        public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
        {
            if(!_products.Any(p=>p.CategoryId==categoryId))
            {
                Console.WriteLine("No products found for the given category ID.");
                return Enumerable.Empty<Product>();
            }
            var ProductByCategory=_products.Where(p=>p.CategoryId==categoryId).OrderBy(p=>p.Name);
            return ProductByCategory;

            // var productsOfCategory=new List<Product>();
            // foreach(var product in products)
            // {
            //     if(product.CategoryId==categoryId)
            //     {
            //         productsOfCategory.Add(product);
            //     }
            // }
            // return productsOfCategory;
            //throw new NotImplementedException();
        }

        public IEnumerable<Product> SearchProductsByName(string productName)
        {
            if(!_products.Any(p=>p.Name.Contains(productName, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("No Products found for the given product name.");
                return Enumerable.Empty<Product>();
            }
            var productsByName=_products.Where(p=>p.Name.Contains(productName,StringComparison.OrdinalIgnoreCase)).OrderBy(p=>p.Id);
            return productsByName;
        }
        public Category? GetCategoryById(int id)
        {
            if(!_categories.Any(c=>c.Id==id))
            {
                Console.WriteLine("Category not found");
                return null;
            }
            var category=_categories.Find(c=>c.Id==id);
            return category;
            // foreach(var category in categories)
            // {
            //     if(category.Id==id)
            //     {
            //         return category;
            //     }
            // }
            // Console.WriteLine("Category not found");
            // return null;
        }

        public Product? GetProductById(int id)
        {
            if(!_products.Any(p=>p.Id==id))
            {
                Console.WriteLine("Product not found");
                return null;
            }
            var product=_products.Find(p=>p.Id==id);
            return product;
            // foreach(var product in products)
            // {
            //     if(product.Id==id)
            //     {
            //         return product;
            //     }
            // }
            // Console.WriteLine("Product not found");
            // return null;
            //throw new NotImplementedException();
        }

        public void AddCategory(string name, string description="general")
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Category name cannot be empty.");
                return;
            }
            Category newCategory=new Category(_categories.Count() + 1, name, description);
            _categories.Add(newCategory);
            Console.WriteLine($"Category added: {newCategory}");
            //Console.WriteLine("not implemented yet");
        }

        public void AddProduct(string name, decimal price,int quantity, int categoryId)
        {
            if(string.IsNullOrWhiteSpace(name)||price<=0||(_categories.Find(c=>c.Id==categoryId)==null))
            {
                Console.WriteLine("Invalid product details. Please provide a valid name, price, and category.");
                return;
            }
            Product newProduct=new Product(_products.Count() + 1, name, price,quantity, categoryId);
            _products.Add(newProduct);
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
            else if(_categories.Find(c=>c.Id==id)==null)
            {
                Console.WriteLine("Category not found");
                return;
            }
            else
            {
                var categoryToUpdate=_categories.Find(c=>c.Id==id);
                categoryToUpdate.Name=newName;
                categoryToUpdate.Description=newDescription;
                Console.WriteLine($"Category updated: {categoryToUpdate}");
            }
            Console.WriteLine("not implemented yet");
        }

        public void UpdateProduct(int id, string newName, decimal newPrice,int quantity, int newCategoryId)
        {
            if(_products.Find(p=>p.Id==id)==null)
            {
                Console.WriteLine("Product not found");
                return;
            }
            else if(_categories.Find(c=>c.Id==newCategoryId)==null)
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
                var productToUpdate=_products.Find(p=>p.Id==id);
                productToUpdate.Name=newName;
                productToUpdate.Price=newPrice;
                productToUpdate.CategoryId=newCategoryId;
                productToUpdate.Quantity=quantity;
                Console.WriteLine($"Product updated: {productToUpdate}");
            }
            
            //Console.WriteLine("not implemented yet");
        }

        public void DeleteCategory(int id)
        {
            if(_categories.Find(c=>c.Id==id)==null)
            {
                Console.WriteLine("Category not found");
                return;
            }
            else
            {
                Console.WriteLine($"Are you sure you want to delete this category {_categories.Find(c=>c.Id==id).Name} ? (y/n)");
                string confirmation=string.Empty;
                do
                {
                    confirmation = Console.ReadLine();
                    if (confirmation == "y")
                    {
                        var categoryToDelete=_categories.Find(c=>c.Id==id);
                        _categories.Remove(categoryToDelete);
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
                } while (confirmation != "y" && confirmation != "n"); 
            }
            //Console.WriteLine("not implemented yet");
        }

        public void DeleteProduct(int id)
        {
            if (_products.Find(p => p.Id == id) == null)
            {
                Console.WriteLine("Product not found");
                return;
            }
            else
            {
                Console.WriteLine($"Are you sure you want to delete this product {_products.Find(p => p.Id == id).Name}? (y/n)");
                string confirmation=string.Empty;
                do
                {
                    confirmation = Console.ReadLine();
                    if (confirmation == "y")
                    {
                        var productToDelete = _products.Find(p => p.Id == id);
                        _products.Remove(productToDelete);
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
                } while (confirmation != "y" && confirmation != "n");

            }
            //Console.WriteLine("not implemented yet");
        }

        ///testing my Linq skills 
        public static void testlinq()
        {
            var test=_products.Where(p=>p.Price>0).GroupBy(p=>p.CategoryId).Select(g=>new{_categories[g.Key-1].Name,productsCount=g.Count()}).OrderByDescending(t=>t.productsCount);
            foreach(var item in test)
            {
                Console.WriteLine($"Category: {item.Name}, Products Count: {item.productsCount}");
            }
        }
        public void Report()
        {
            // total price , msot expensive product, out of stock,average per category
            decimal totalProductsPrice=_products.Sum(p=>p.Price*p.Quantity);
            Product expensive=_products.MaxBy(p=>p.Price);
            List<Product> outOfStock=_products.Where(p=>p.Quantity<1).ToList();
            Console.WriteLine($"The total price of the catalog is: {totalProductsPrice}");
            Console.WriteLine($"The mmost expensive product in the catalog is: {expensive}");
            Console.WriteLine("Products out of stock:");
            outOfStock.ForEach(p=>Console.Write($"{p.Name},"));
            Console.WriteLine();

            var GroupedProducts= _products.GroupBy(p=>p.CategoryId);
            foreach(var group in GroupedProducts)
            {
                Console.WriteLine($"{GetCategoryById(group.Key).Name}'s average price: {group.Average(p=>p.Price)}");
            }
            //average price per cat , count per cat
           // _products.GroupBy(p=>p.CategoryId)
            

        }
    }
}