using System.ComponentModel.DataAnnotations.Schema;

namespace ExampleEcom.Domain.Aggregates.ProductAggregate
{
    [Table("product_price")]
    public class ProductPrice
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CurrencyId { get; set; }
        public double Value { get; set; }

        public Product Product { get; set; }
        public Currency Currency { get; set; }
    }
}
