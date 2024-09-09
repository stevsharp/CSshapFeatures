
using AbstractFactoryConsole.Factory;

namespace AbstractFactoryConsole;

public interface IDbConnection
{
    void Connect();
    void Disconnect();
}
