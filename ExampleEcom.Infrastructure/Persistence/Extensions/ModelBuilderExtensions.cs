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
                var tableName = entity.ClrType.Name.Split("`").First();

                if (tableName == null) continue;
                entity.SetTableName(tableName.ToSnakeCase());

                foreach (var property in entity.GetProperties())
                {
                    property.SetColumnName(property.Name.ToSnakeCase());
                }
            }
        }
    }
}
