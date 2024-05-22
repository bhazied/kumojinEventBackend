using System.Data;

namespace Kumojin.Events.Application.interfaces;
public interface IDbContext
{
    public IDbConnection CreateConnection();

}
