using System.ComponentModel.DataAnnotations;

namespace ExampleEcom.Domain.Aggregates.ProductAggregates
{
    public class ProductPrice
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int CurrencyId { get; set; }

        [Required]
        public double Value { get; set; }

        public Product Product { get; set; } = default!;
        public Currency Currency { get; set; } = default!;
    }
}
