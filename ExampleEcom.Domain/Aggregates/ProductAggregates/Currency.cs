using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ExampleEcom.Domain.Aggregates.ProductAggregates
{
    public class Currency
    {
        [Required]
        public int Id { get; set; }

        [Required, StringLength(64)]
        public string Name { get; set; } = default!;

        [Required, MinLength(3), MaxLength(3)]
        public string Code { get; set; } = default!;

        [Required, MinLength(3), MaxLength(3)]
        public string Number { get; set; } = default!;

        [Required, StringLength(5)]
        public string Symbol { get; set; } = default!;

        [Required]
        public CurrencySymbolOrientation SymbolOrientation { get; set; }

        [Required]
        public bool SpacedSymbol { get; set; }
    }
}
