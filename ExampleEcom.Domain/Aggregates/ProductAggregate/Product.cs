using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExampleEcom.Domain.Aggregates.ProductAggregate
{
    [Table("product")]
    public class Product
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public ProductPrice Price { get; set; }
    }
}
