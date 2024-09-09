
using AbstractFactoryConsole.Factory;

namespace AbstractFactoryConsole;

public class DatabaseClient
{
    private readonly IDbConnection _connection;

    public DatabaseClient(IDbFactory factory)
    {
        // Create the database connection using the factory
        _connection = factory.CreateConnection();
    }

    public void Connect()
    {
        _connection.Connect();
    }

    public void Disconnect()
    {
        _connection.Disconnect();
    }
}