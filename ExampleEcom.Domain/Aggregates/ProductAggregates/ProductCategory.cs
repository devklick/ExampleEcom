using System.ComponentModel.DataAnnotations;

namespace ExampleEcom.Domain.Aggregates.ProductAggregates
{
    public class ProductCategory
    {
        [Required]
        public int Id { get; set; }

        public int? ParentCategoryId { get; set; }

        [Required, StringLength(64)]
        public string Name { get; set; } = default!;

        public ProductCategory? ParentCategory { get; set; }
        public List<ProductCategory>? ChildCategories { get; set; }
    }
}
