
namespace AbstractFactoryConsole.Factory
{
    public class SqlServerFactory : IDbFactory
    {
        public IDbConnection CreateConnection()
        {
            return new SqlServerConnection();
        }
    }
}
