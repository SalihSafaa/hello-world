namespace HelloWorld
{
    public interface ICatalogService
    {
        IEnumerable<Category> GetCategories();
        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetProductsByCategoryId(int categoryId);

        Category GetCategoryById(int id);
        Product GetProductById(int id);

        void AddCategory(Category category);
        void AddProduct(Product product);

        void UpdateCategory(Category category);
        void UpdateProduct(Product product);

        void DeleteCategory(int id);
        void DeleteProduct(int id);
    }
}