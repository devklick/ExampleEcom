namespace ExampleEcom.Api.Configuration
{
    public class DatabaseConnections : Dictionary<string, DatabaseConnection>
    {
        public string? GetConnectionString(string connectionName)
        {
            if (!TryGetValue(connectionName, out var connection))
                return null;

            if (!string.IsNullOrEmpty(connection.Password))
            {
                return $"{connection.ConnectionString} Password={connection.Password};";
            }

            return connection.ConnectionString;
        }
    }
}