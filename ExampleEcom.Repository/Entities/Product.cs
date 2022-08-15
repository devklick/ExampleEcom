namespace ExampleEcom.Repository.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Category { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public string Currency { get; set; } = string.Empty;
    }
}