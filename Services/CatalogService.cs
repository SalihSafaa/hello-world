using System.Data.Common;

namespace HelloWorld
{
    public class CatalogService : ICatalogService
    {
        private static int _nextCategoryId=1;
        private static int _nextProductId=1;
        //test
            private static Dictionary<int,Category> _categories = new Dictionary<int, Category>
            {
                {_nextCategoryId,new Category(_nextCategoryId++, "Electronics", "Devices and gadgets")},
                {_nextCategoryId,new Category(_nextCategoryId++, "Books", "Literature and educational materials")},
                {_nextCategoryId,new Category(_nextCategoryId++, "Clothing", "Apparel and accessories")}
            };
            private static Dictionary<int,Product> _products = new Dictionary<int, Product>
            {
               {_nextProductId, new Product(_nextProductId++, "Laptop", 999.99m,0, 1)},
               {_nextProductId, new Product(_nextProductId++, "Smartphone", 499.99m,1, 1)},
               {_nextProductId, new Product(_nextProductId++, "Novel", 19.99m,6, 2)},
               {_nextProductId, new Product(_nextProductId++, "T-Shirt", 14.99m,9, 3)}
            };
        public List<int> ExistingCategoryID()
        {
            return _categories.Values.Select(p=>p.Id).ToList();
        }
        public IEnumerable<Category> GetCategories()
        {
            return _categories.Values;
            //throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProducts()
        {
            return _products.Values;
            //throw new NotImplementedException();
        }
        public bool CheckProductIdExist(string checkId, out Product product)
        {
            product = null;
            if (!int.TryParse(checkId, out int productId) || !_products.TryGetValue(productId, out product))
            {
                Console.WriteLine("ID not found");
                return false;
            }

            return true;
        }
        public bool CheckCategoryIdExist(string checkId, out Category category)
        {
            category = null;
            if (!int.TryParse(checkId, out int categoryId) || !_categories.TryGetValue(categoryId, out category))
            {
                Console.WriteLine("ID not found");
                return false;
            }

            return true;
        }

        public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
        {
            if(!_products.Values.Any(p=>p.CategoryId==categoryId))
            {
                Console.WriteLine("No products found for the given category ID.");
                return Enumerable.Empty<Product>();
            }
            var ProductByCategory=_products.Values.Where(p=>p.CategoryId==categoryId).OrderBy(p=>p.Name);
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
            if (string.IsNullOrWhiteSpace(productName))
            {
                Console.WriteLine("Product name cannot be empty.");
                return Enumerable.Empty<Product>();
            }
            if(!_products.Values.Any(p=>p.Name.Contains(productName, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("No Products found for the given product name.");
                return Enumerable.Empty<Product>();
            }
            var productsByName=_products.Values.Where(p=>p.Name.Contains(productName,StringComparison.OrdinalIgnoreCase)).OrderBy(p=>p.Id);
            return productsByName;
        }
        public Category? GetCategoryById(int id)
        {
            if(_categories.TryGetValue(id,out var category))
            {
                return category;
            }
            Console.WriteLine("category not found");
            return null;
            // if(!_categories.Any(c=>c.Id==id))
            // {
            //     Console.WriteLine("Category not found");
            //     return null;
            // }
            // var category=_categories.Find(c=>c.Id==id);
            // return category;
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
            if(_products.TryGetValue(id,out var product))
            {
                return product;
            }
            Console.WriteLine("product not found");
            return null;
            // if(!_products.Any(p=>p.Id==id))
            // {
            //     Console.WriteLine("Product not found");
            //     return null;
            // }
            // var product=_products.Find(p=>p.Id==id);
            // return product;
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
            Category newCategory=new Category(_nextCategoryId, name, description);
            _categories.Add(_nextCategoryId++,newCategory);
            Console.WriteLine($"Category added: {newCategory}");
            //Console.WriteLine("not implemented yet");
        }

        public void AddProduct(string name, decimal price,int quantity, int categoryId)
        {
            if(string.IsNullOrWhiteSpace(name)||price<=0||!CheckCategoryIdExist(categoryId.ToString(),out _)||quantity<0)
            {
                Console.WriteLine("Invalid product details. Please provide a valid name, price, and category.");
                return;
            }
            Product newProduct=new Product(_nextProductId, name, price,quantity, categoryId);
            _products.Add(_nextProductId++,newProduct);
            Console.WriteLine($"Product added: {newProduct}");
            //Console.WriteLine("not implemented yet");
        }

        public void UpdateCategory(int id, string newName, string newDescription="general")
        {
            Category categoryToUpdate;
            if(string.IsNullOrWhiteSpace(newName))
            {
                Console.WriteLine("Category name cannot be empty.");
                return;
            }
            else if(!CheckCategoryIdExist(id.ToString(),out categoryToUpdate))
            {
                Console.WriteLine("Category not found");
                return;
            }
            else
            {
                categoryToUpdate.Name=newName;
                categoryToUpdate.Description=newDescription;
                Console.WriteLine($"Category updated: {categoryToUpdate}");
            }
            //Console.WriteLine("not implemented yet");
        }

        public void UpdateProduct(int id, string newName, decimal newPrice,int quantity, int newCategoryId)
        {
            // if(_products.Find(p=>p.Id==id)==null)
            if(!_products.TryGetValue(id, out var productToUpdate))
            {
                Console.WriteLine("Product not found");
                return;
            }
            // else if(_categories.Find(c=>c.Id==newCategoryId)==null)
            else if(!_categories.ContainsKey(newCategoryId))
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
            else if(quantity<0)
            {
                Console.WriteLine("Product quantity cannot be negative.");
                return;
            }
            else
            {
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
            // if(_categories.Find(c=>c.Id==id)==null)
            if(!_categories.TryGetValue(id, out var categoryToDelete))
            {
                Console.WriteLine("Category not found");
                return;
            }
            else
            {
                if (_products.Values.Any(product => product.CategoryId == id))
                {
                    Console.WriteLine("Category cannot be deleted while products belong to it.");
                    return;
                }

                // Console.WriteLine($"Are you sure you want to delete this category {_categories.Find(c=>c.Id==id).Name} ? (y/n)");
                Console.WriteLine($"Are you sure you want to delete this category {categoryToDelete.Name} ? (y/n)");
                string confirmation=string.Empty;
                do
                {
                    confirmation = Console.ReadLine();
                    if (confirmation == "y")
                    {
                        // var categoryToDelete=_categories.Find(c=>c.Id==id);
                        _categories.Remove(id);
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
            // if (_products.Find(p => p.Id == id) == null)
            if (!_products.TryGetValue(id, out var productToDelete))
            {
                Console.WriteLine("Product not found");
                return;
            }
            else
            {
                // Console.WriteLine($"Are you sure you want to delete this product {_products.Find(p => p.Id == id).Name}? (y/n)");
                Console.WriteLine($"Are you sure you want to delete this product {productToDelete.Name}? (y/n)");
                string confirmation=string.Empty;
                do
                {
                    confirmation = Console.ReadLine();
                    if (confirmation == "y")
                    {
                        // var productToDelete = _products.Find(p => p.Id == id);
                        _products.Remove(id);
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
            // var test=_products.Where(p=>p.Price>0).GroupBy(p=>p.CategoryId).Select(g=>new{_categories[g.Key-1].Name,productsCount=g.Count()}).OrderByDescending(t=>t.productsCount);
            var test=_products.Values.Where(p=>p.Price>0).GroupBy(p=>p.CategoryId).Select(g=>new{CategoryName=_categories.TryGetValue(g.Key, out var category) ? category.Name : "Unknown", productsCount=g.Count()}).OrderByDescending(t=>t.productsCount);
            foreach(var item in test)
            {
                Console.WriteLine($"Category: {item.CategoryName}, Products Count: {item.productsCount}");
            }
        }
        public void Report()
        {
            // total price , msot expensive product, out of stock,average per category
            if (_products.Count == 0)
            {
                Console.WriteLine("The catalog has no products.");
                return;
            }

            decimal totalProductsPrice=_products.Values.Sum(p=>p.Price*p.Quantity);
            Product expensive=_products.Values.MaxBy(p=>p.Price);
            List<Product> outOfStock=_products.Values.Where(p=>p.Quantity<1).ToList();
            Console.WriteLine($"The total price of the catalog is: {totalProductsPrice}");
            Console.WriteLine($"The mmost expensive product in the catalog is: {expensive}");
            Console.WriteLine("\nProducts out of stock:");
            outOfStock.ForEach(p=>Console.Write($"{p.Name},"));
            Console.WriteLine("\n");

            var GroupedProducts= _products.Values.GroupBy(p=>p.CategoryId);
            foreach(var group in GroupedProducts)
            {
                var categoryName = GetCategoryById(group.Key)?.Name ?? "Unknown";
                Console.WriteLine($"{categoryName}'s average price: {group.Average(p=>p.Price)}, product count: {group.Count()}");
            }
            //average price per cat , count per cat
           // _products.GroupBy(p=>p.CategoryId)
            

        }
    }
}