namespace HelloWorld
{
    public class Product 
    {
        public int Id { get; }

        public DateTime CreatedAt{get;}

        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int Quantity {get; set;}

        public Product(int id, string name, decimal price,int quantity, int categoryId)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(categoryId);
            ArgumentException.ThrowIfNullOrWhiteSpace(name,nameof(name));
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);
            ArgumentOutOfRangeException.ThrowIfLessThan(quantity,0,nameof(quantity));
            
            
            Id = id;
            Name = name;
            Price = price;
            CategoryId = categoryId;
            Quantity=quantity;
            CreatedAt=DateTime.Now;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Price: {Price} ,quantity: {Quantity}, CategoryId: {CategoryId} Created At: {CreatedAt}";
        }
    }
}