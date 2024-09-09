
namespace AbstractFactoryConsole
{
    public class SqlServerConnection : IDbConnection
    {
        public void Connect()
        {
            Console.WriteLine("Connecting to SQL Server...");
            // Actual connection logic for SQL Server
        }

        public void Disconnect()
        {
            Console.WriteLine("Disconnecting from SQL Server...");
            // Actual disconnection logic for SQL Server
        }
    }
}
