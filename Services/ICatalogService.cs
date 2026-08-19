namespace HelloWorld
{
    public interface ICatalogService
    {
        IEnumerable<Category> GetCategories();
        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetProductsByCategoryId(int categoryId);

        IEnumerable<Product> SearchProductsByName(string productName);

        public bool CheckProductIdExist(string checkId, out Product product);

        public bool CheckCategoryIdExist(string checkId, out Category category);


        Category? GetCategoryById(int id);
        Product? GetProductById(int id);


        void AddCategory(string name, string description="general");
        void AddProduct(string name, decimal price,int quantity, int categoryId);

        void UpdateCategory(int id, string newName, string newDescription="general");
        void UpdateProduct(int id, string newName, decimal newPrice,int quantity, int newCategoryId);

        void DeleteCategory(int id);
        void DeleteProduct(int id);

        void Report();

    }
}