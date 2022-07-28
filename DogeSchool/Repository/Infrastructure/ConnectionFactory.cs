using BuildingManager.Repository.IoC;
using DogeSchool.Repository.Infrastructure;
using Microsoft.Extensions.Options;
using Npgsql;
using System.Data;

namespace DogeSchool.Repository.Infrastructure
{
    public class ConnectionFactory: IConnectionFactory
    {
        private readonly IOptions<RepositoryConfiguration> _ConnectionString;

        public ConnectionFactory(IOptions<RepositoryConfiguration> ConnectionString)
        {
            _ConnectionString = ConnectionString;
        }

        public IDbConnection GetConnection()
        {
            return new NpgsqlConnection(_ConnectionString.Value.ConnectionString);
        }
    }
}
