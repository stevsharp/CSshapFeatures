
namespace AbstractFactoryConsole.Factory
{

    // Concrete Factory - MySQL Factory
    public class MySqlFactory : IDbFactory
    {
        public IDbConnection CreateConnection()
        {
            return new MySqlConnection();
        }
    }
}