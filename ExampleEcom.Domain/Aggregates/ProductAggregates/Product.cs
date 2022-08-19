using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExampleEcom.Domain.Aggregates.ProductAggregates
{
    public class Product
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required, StringLength(256)]
        public string DisplayName { get; set; } = default!;

        [Required, DataType(DataType.MultilineText)]
        public string Description { get; set; } = default!;

        public List<ProductPrice> Prices { get; set; } = default!;

        public ProductCategory Category { get; set; } = default!;
    }
}
