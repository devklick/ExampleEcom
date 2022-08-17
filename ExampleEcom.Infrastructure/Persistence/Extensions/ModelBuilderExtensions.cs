using ExampleEcom.Domain.Extensions;
using Microsoft.EntityFrameworkCore;

namespace ExampleEcom.Infrastructure.Persistence.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void ApplySingularizedSnakeCaseNamingConvention(this ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.DisplayName().ToSnakeCase());
            }
        }
    }
}
