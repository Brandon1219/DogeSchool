using Dapper;
using DogeSchool.Models;
using DogeSchool.Repository.Infrastructure;
using SqlKata;
using SqlKata.Compilers;

namespace DogeSchool.Repository.Repositories.TeacherRepository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public TeacherRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }


        public async Task Create(TeacherModel model)
        {
            var data = new Dictionary<string, object>()
            {
                ["id"] = Guid.NewGuid(),
                ["firstname"] = model.FirstName,
                ["lastname"] = model.LastName
            };

            using var connection = _connectionFactory.GetConnection();

            var query = new Query("demongraphics.teacher");
            query.AsInsert(data);

            var SQL = new PostgresCompiler().Compile(query);
            await connection.ExecuteAsync(SQL.Sql, SQL.NamedBindings);
        }

        public Task<TeacherModel> Read(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<TeacherModel>> ReadAll()
        {
            throw new NotImplementedException();
        }
    }
}
