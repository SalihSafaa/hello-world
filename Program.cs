namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int choice;
            ICatalogService catalogService = new CatalogService();

            do
            {
                Console.WriteLine("1. List Categories");
                Console.WriteLine("2. List Products");
                Console.WriteLine("3. List Products by Category");
                Console.WriteLine("4. Get Category by Id");
                Console.WriteLine("5. Get Product by Id");
                Console.WriteLine("6. Add Category");
                Console.WriteLine("7. Add Product");
                Console.WriteLine("8. Update Category");
                Console.WriteLine("9. Update Product");
                Console.WriteLine("10. Delete Category");
                Console.WriteLine("11. Delete Product");
                Console.WriteLine("12. Search Products by Name");
                Console.WriteLine("0. Exit");
                choice = int.TryParse(Console.ReadLine(), out choice) ? choice : -1;


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
                    case 0:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } while (choice != 0);


            

            
        }
    }
}
