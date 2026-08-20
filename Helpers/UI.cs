namespace HelloWorld
{
    public static class UI
    {
        
        public static void MenuSelection()
        {
            ICatalogService catalogService = new CatalogService();
            int choice;
            
            do
            {
                // Console.WriteLine("1. List Categories");
                // Console.WriteLine("2. List Products");
                // Console.WriteLine("3. List Products by Category");
                // Console.WriteLine("4. Get Category by Id");
                // Console.WriteLine("5. Get Product by Id");
                // Console.WriteLine("6. Add Category");
                // Console.WriteLine("7. Add Product");
                // Console.WriteLine("8. Update Category");
                // Console.WriteLine("9. Update Product");
                // Console.WriteLine("10. Delete Category");
                // Console.WriteLine("11. Delete Product");
                // Console.WriteLine("12. Search Products by Name");
                // Console.WriteLine("13. Test LINQ Skills");
                // Console.WriteLine("0. Exit");

                //making the list exactly like the task intended
                Console.WriteLine("1. Add Category");
                Console.WriteLine("2. Add Product");
                Console.WriteLine("3. List Products");
                Console.WriteLine("4. List By a Categorie");
                Console.WriteLine("5. Search Products by Name");
                Console.WriteLine("6. Update Product");
                Console.WriteLine("7. Delete Product");
                Console.WriteLine("8. Reports");
                Console.WriteLine("0. Exit");


                choice = int.TryParse(Console.ReadLine(), out choice) ? choice : -1;

                switch(choice)
                {
                    case 1:
                        // Add Category
                        Console.WriteLine("Enter Category Name:");
                        string? categoryName,categoryDescription;
                        do
                        {
                            categoryName=Console.ReadLine();
                        }while(!UserInputValidations.ValidateString(ref categoryName));
                        Console.WriteLine("Enter Category Description");
                        do
                        {
                            categoryDescription=Console.ReadLine();
                        }while(!UserInputValidations.ValidateString(ref categoryDescription));
                        catalogService.AddCategory(categoryName,categoryDescription);
                        break;
                    case 2:
                        // Add Product 
                        string? productName,productPrice,productCategoryId;
                        decimal price;
                        int intproductCategotyId;
                        string quantityInput;
                        int productQuantity;
                        catalogService.GetCategories().ToList().ForEach(c=>Console.WriteLine($"{c.Id} {c.Name}"));
                        do  
                        {
                            Console.WriteLine("Enter the category id for this product");
                            productCategoryId=Console.ReadLine();

                        }while(!UserInputValidations.ValidateAndCovertToInt(productCategoryId,out intproductCategotyId) || !catalogService.CheckCategoryIdExist(productCategoryId,out _));
                        
                        do
                        {
                            Console.WriteLine("Enter Product name.");
                            productName=Console.ReadLine();
                        }while(!UserInputValidations.ValidateString(ref productName));
                        
                        do
                        {
                            Console.WriteLine("Enter product Price");
                            productPrice=Console.ReadLine();
                        }while(!UserInputValidations.ValidatePrice(productPrice, out price));
                        
                        do
                        {
                            Console.WriteLine("Enter the quantity of this Product");
                            quantityInput=Console.ReadLine();
                        }while(!UserInputValidations.ValidateAndCovertToInt(quantityInput,out productQuantity)||productQuantity<0);
                        catalogService.AddProduct(productName,price,productQuantity,intproductCategotyId);
                        break;
                    case 3:
                        //List product
                        Console.WriteLine($"{"ID",-5} | {"Product Name",-12} | {"Price",-9} | {"InStock",-9} | {"CategoryName",-12} | {"Created At",-30}");
                        Console.WriteLine(new string('-',84));
                        catalogService.GetProducts().ToList()
                        .ForEach(p=>Console.WriteLine
                        ($"{p.Id,-5} | {p.Name,-12} | {p.Price,-9:C} | {p.Quantity,-9} | {catalogService.
                        GetCategoryById
                        (p.CategoryId)?.Name,-12} | {p.CreatedAt,-30}"));
                        break;
                    case 4:
                        //list by category
                        catalogService.GetCategories().ToList().ForEach(c=>Console.Write($"{c.Id}  {c.Name} "));
                        Console.WriteLine("\nselect the category id to list products from");
                        int id;
                        string? listBycategoryInput;
                        do
                        {
                            listBycategoryInput=Console.ReadLine();
                        }while(!UserInputValidations.ValidateAndCovertToInt(listBycategoryInput,out id) || !catalogService.CheckCategoryIdExist(listBycategoryInput,out _));
                        catalogService.GetProducts().Where(p=>p.CategoryId==id).ToList()
                        .ForEach(p=>Console.WriteLine($"{p.Name} {p.Price}"));
                        break;
                    case 5:
                        //search products by name
                        string? input;
                        Console.WriteLine("Enter the name of the products to search of");
                        do
                        {
                            input=Console.ReadLine();
                        }while(!UserInputValidations.ValidateString(ref input));
                        catalogService.SearchProductsByName(input).ToList().ForEach(p=>
                        Console.WriteLine($"{p.Id}. {p.Name} :{p.Price} "));
                        break;
                    case 6:
                        //update products
                        Console.WriteLine("Enter the id of the product to update");
                        catalogService.GetProducts().ToList().ForEach(p=>Console.WriteLine($"{p.Id}.{p.Name}"));
                        string updateId;
                        do
                        {
                            updateId=Console.ReadLine();
                        }while(!UserInputValidations.ValidateAndCovertToInt(updateId,out id) || !catalogService.CheckProductIdExist(updateId,out _));
                        catalogService.GetCategories().ToList().ForEach(c=>Console.WriteLine($"{c.Id} {c.Name}"));
                        Console.WriteLine("Enter the category id for this product");
                        do  
                        {
                            productCategoryId=Console.ReadLine();

                        }while(!UserInputValidations.ValidateAndCovertToInt(productCategoryId,out intproductCategotyId) || !catalogService.CheckCategoryIdExist(productCategoryId,out _));
                        Console.WriteLine("Enter Product name.");
                        do
                        {
                            productName=Console.ReadLine();
                        }while(!UserInputValidations.ValidateString(ref productName));
                        Console.WriteLine("Enter product Price");
                        do
                        {
                            productPrice=Console.ReadLine();
                        }while(!UserInputValidations.ValidatePrice(productPrice, out price));
                        Console.WriteLine("Enter the quantity of this Product");
                        do
                        {
                            quantityInput=Console.ReadLine();
                        }while(!UserInputValidations.ValidateAndCovertToInt(quantityInput,out productQuantity)|| (productQuantity<0));
                        catalogService.UpdateProduct(id,productName,price,productQuantity,intproductCategotyId);
                        break;
                    case 7:
                        //delete product
                        Console.WriteLine("Enter the id of the product to delete");
                        catalogService.GetProducts().ToList().ForEach(p=>Console.WriteLine($"{p.Id}.{p.Name}"));
                        string deleteId;
                         do
                        {
                            deleteId=Console.ReadLine();
                        }while(!UserInputValidations.ValidateAndCovertToInt(deleteId,out id) || !catalogService.CheckProductIdExist(deleteId,out _));
                        catalogService.DeleteProduct(id);
                        break;
                    case 8:
                        //Report
                        catalogService.Report();
                        break;

                }
/*
                switch (choice)
                {
                    case 1:
                        // List Categories
                        var categories = catalogService.GetCategories();
                        // foreach (var category in categories)
                        // {
                        //     Console.WriteLine(category);
                        // }
                        categories.ToList().ForEach(category => Console.WriteLine(category));
                        break;
                    case 2:
                        // List Products
                        var products = catalogService.GetProducts();
                        // foreach (var product in products)
                        // {
                        //     Console.WriteLine(product);
                        // }
                        products.ToList().ForEach(product => Console.WriteLine(product));
                        break;
                    case 3:
                        // List Products by Category
                        Console.WriteLine("Enter Category Id:");
                        int categoryId;
                        do
                        {
                            Console.WriteLine("Enter a valid Category Id:");
                        } while (!int.TryParse(Console.ReadLine(), out categoryId));
                        var productsByCategory = catalogService.GetProductsByCategoryId(categoryId);
                        productsByCategory.ToList().ForEach(product => Console.WriteLine(product));
                        break;
                    case 4:
                        // Get Category by Id
                        int categoryIdToFind;
                        do
                        {
                            Console.WriteLine("Enter a valid Category Id:");

                        } while (!int.TryParse(Console.ReadLine(), out categoryIdToFind));
                        var category = catalogService.GetCategoryById(categoryIdToFind);
                        Console.WriteLine(category);
                        break;
                    case 5:
                        // Get Product by Id
                        int productId;
                        do
                        {
                            Console.WriteLine("Enter a valid Product Id:");
                        } while (!int.TryParse(Console.ReadLine(), out productId));
                        var product = catalogService.GetProductById(productId);
                        Console.WriteLine(product);
                        break;
                    case 6:
                        // Add Category
                        Console.WriteLine("Enter Category Name:");
                        string categoryName = Console.ReadLine();
                        Console.WriteLine("Enter Category Description:");
                        string categoryDescription = Console.ReadLine();
                        catalogService.AddCategory(categoryName, categoryDescription);
                        break;
                    case 7:
                        // Add Product
                        Console.WriteLine("Enter Product Name:");
                        string productName = Console.ReadLine();
                        Console.WriteLine("Enter Product Description:");
                        string productDescription = Console.ReadLine();
                        Console.WriteLine("Enter Product Price:");
                        decimal productPrice=Convert.ToDecimal(Console.ReadLine());
                        Console.WriteLine("Enter Product Category Id:");
                        int.TryParse(Console.ReadLine(), out int productCategoryId);

                        catalogService.AddProduct(productName, productPrice, productCategoryId);
                        break;
                    case 8:
                        // Update Category
                        Console.WriteLine("Enter Category Id to update:");
                        int.TryParse(Console.ReadLine(), out int categoryIdToUpdate);
                        Console.WriteLine("Enter new Category Name:");
                        string newCategoryName = Console.ReadLine();
                        Console.WriteLine("Enter new Category Description:");
                        string newCategoryDescription = Console.ReadLine();
                        catalogService.UpdateCategory(categoryIdToUpdate, newCategoryName, newCategoryDescription);
                        
                        break;
                    case 9:
                        // Update Product
                        Console.WriteLine("Enter Product Id to update:");
                        int.TryParse(Console.ReadLine(), out int productIdToUpdate);
                        Console.WriteLine("Enter new Product Name:");
                        string newProductName = Console.ReadLine();
                        Console.WriteLine("Enter new Product Price:");
                        decimal newProductPrice=Convert.ToDecimal(Console.ReadLine());
                        Console.WriteLine("Enter new Product Category Id:");
                        int.TryParse(Console.ReadLine(), out int newProductCategoryId);
                        catalogService.UpdateProduct(productIdToUpdate, newProductName, newProductPrice, newProductCategoryId);
                        break;
                    case 10:
                        // Delete Category
                        Console.WriteLine("Enter Category Id to delete:");
                        int.TryParse(Console.ReadLine(), out int categoryIdToDelete);
                        catalogService.DeleteCategory(categoryIdToDelete);
                        break;
                    case 11:
                        // Delete Product
                        Console.WriteLine("Enter Product Id to delete:");
                        int.TryParse(Console.ReadLine(), out int productIdToDelete);
                        catalogService.DeleteProduct(productIdToDelete);
                        break;
                    case 12:
                        // Search Products by Name
                        Console.WriteLine("Enter Product Name to search:");
                        string productNameToSearch = Console.ReadLine();
                        var productsByName = catalogService.SearchProductsByName(productNameToSearch);
                        productsByName.ToList().ForEach(product => Console.WriteLine(product));
                        break;
                    case 13:
                        // Test LINQ Skills
                        CatalogService.testlinq();
                        break;
                    case 0:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
                */
            } while (choice != 0);
            
        }
    }
}