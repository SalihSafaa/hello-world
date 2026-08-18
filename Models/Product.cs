namespace HelloWorld
{
    public class Product 
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int Quantity {get; set;}

        public Product(int id, string name, decimal price,int quantity, int categoryId)
        {
            Id = id;
            Name = name;
            Price = price;
            CategoryId = categoryId;
            Quantity=quantity;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Price: {Price} ,quantity: {Quantity}, CategoryId: {CategoryId}";
        }
    }
}