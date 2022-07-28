using System.Data;

namespace DogeSchool.Repository.Infrastructure
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection();
    }
}
