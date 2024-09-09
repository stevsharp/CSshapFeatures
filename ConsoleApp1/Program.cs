using AbstractFactoryConsole.Factory;
using AbstractFactoryConsole;

class Program
{
    static void Main(string[] args)
    {
        // Create SQL Server connection
        IDbFactory sqlFactory = new SqlServerFactory();
        DatabaseClient sqlClient = new DatabaseClient(sqlFactory);
        sqlClient.Connect();
        sqlClient.Disconnect();

        Console.WriteLine();

        // Create MySQL connection
        IDbFactory mySqlFactory = new MySqlFactory();
        DatabaseClient mySqlClient = new DatabaseClient(mySqlFactory);
        mySqlClient.Connect();
        mySqlClient.Disconnect();
    }
}