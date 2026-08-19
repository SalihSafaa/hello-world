namespace HelloWorld
{
    public class Category
    {

        public int Id { get; }

        public string Name { get; set; }
        public string Description { get; set; }

        public Category(int id, string name, string description)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);
            ArgumentException.ThrowIfNullOrWhiteSpace(name,nameof(name));
            Id = id;
            Name = name;
            Description = description;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Description: {Description}";
        }
    }
}
