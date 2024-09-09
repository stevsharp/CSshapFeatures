
namespace AbstractFactoryConsole.Factory;

public interface IDbFactory
{
    IDbConnection CreateConnection();
}
