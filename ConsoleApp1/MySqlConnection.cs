
namespace AbstractFactoryConsole
{
    public class MySqlConnection : IDbConnection
    {
        public void Connect()
        {
            Console.WriteLine("Connecting to MySQL...");
            // Actual connection logic for MySQL
        }

        public void Disconnect()
        {
            Console.WriteLine("Disconnecting from MySQL...");
            // Actual disconnection logic for MySQL
        }
    }
}