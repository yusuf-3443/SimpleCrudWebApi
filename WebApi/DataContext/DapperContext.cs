using Npgsql;

namespace WebApi.DataContext;

public class DapperContext
{
    private readonly string _connectionString =
        "Server=localhost;port=5432;Database=company_db;User Id=postgres;password=12345";

    public NpgsqlConnection Connection()
    {
        return new NpgsqlConnection(_connectionString);
    }
}