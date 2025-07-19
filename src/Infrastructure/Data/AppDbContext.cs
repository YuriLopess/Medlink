using Microsoft.Extensions.Configuration;
using Npgsql;

public class AppDbContext : IDisposable
{
    public NpgsqlConnection Connection { get; }

    public AppDbContext(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        Connection = new NpgsqlConnection(connectionString);
        Connection.Open();
    }

    public void Dispose()
    {
        Connection.Dispose();
    }
}