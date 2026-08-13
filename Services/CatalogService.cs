namespace HelloWorld
{
    public class CatalogService : ICatalogService
    {
        public IEnumerable<Category> GetCategories()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProducts()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Category GetCategoryById(int id)
        {
            throw new NotImplementedException();
        }

        public Product GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public void AddCategory(Category category)
        {
            Console.WriteLine("not implemented yet");
        }

        public void AddProduct(Product product)
        {
            Console.WriteLine("not implemented yet");
        }

        public void UpdateCategory(Category category)
        {
            Console.WriteLine("not implemented yet");
        }

        public void UpdateProduct(Product product)
        {
            Console.WriteLine("not implemented yet");
        }

        public void DeleteCategory(int id)
        {
            Console.WriteLine("not implemented yet");
        }

        public void DeleteProduct(int id)
        {
            Console.WriteLine("not implemented yet");
        }
    }
}