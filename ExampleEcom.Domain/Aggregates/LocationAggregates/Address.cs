using System.ComponentModel.DataAnnotations;

namespace ExampleEcom.Domain.Aggregates.LocationAggregates
{
    public class Address
    {
        [StringLength(64)]
        public string? BuildingName { get; set; }

        [StringLength(9)]
        public string? BuildingNumber { get; set; }

        [Required, StringLength(128)]
        public string Street { get; set; }

        [Required, StringLength(128)]
        public string City { get; set; }

        [StringLength(64)]
        public string? Region { get; set; }

        [StringLength(64)]
        public string? Country { get; set; }

        [Required, StringLength(8)]
        public string PostCode { get; set; }
    }
}
