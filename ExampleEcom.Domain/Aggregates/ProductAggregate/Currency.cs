using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExampleEcom.Domain.Aggregates.ProductAggregate
{
    [Table("currency")]
    public class Currency
    {
        [Required]
        public int Id { get; set; }

        [Required, StringLength(64)]
        public string Name { get; set; }

        [Required, MinLength(3), MaxLength(3)]
        public string Code { get; set; }

        [Required, MinLength(3), MaxLength(3)]
        public string Number { get; set; }

        [Required, StringLength(3)]
        public string Symbol { get; set; }

        [Required]
        public CurrencySymbolOrientation MyProperty { get; set; }

        [Required]
        public bool SpacedSymbol { get; set; }
    }
}
