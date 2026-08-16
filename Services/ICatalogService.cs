namespace HelloWorld
{
    public interface ICatalogService
    {
        IEnumerable<Category> GetCategories();
        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetProductsByCategoryId(int categoryId);

        Category? GetCategoryById(int id);
        Product? GetProductById(int id);

        void AddCategory(string name, string description);
        void AddProduct(string name, decimal price, int categoryId);

        void UpdateCategory(int id, string newName, string newDescription);
        void UpdateProduct(int id, string newName, decimal newPrice, int newCategoryId);

        void DeleteCategory(int id);
        void DeleteProduct(int id);

    }
}