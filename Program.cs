namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            

            Category category =new Category();
            category.Id = 1;
            category.Name = "Electronics";
            category.Description = "Electronic devices";


            Product product =new Product();
            product.Id = 1;
            product.Name = "Laptop";
            product.Price = 1000.00m;


            Console.WriteLine($"Category: {category.Name}, Description: {category.Description}");
            Console.WriteLine($"Product: {product.Name}, Price: {product.Price}");

            
        }
    }
}
