using Canducci.SqlKata.Dapper.Extensions.Builder;
using Canducci.SqlKata.Dapper.Postgres;
using Dapper;
using DogeSchool.Models;
using DogeSchool.Repository.Infrastructure;
using SqlKata;
using SqlKata.Compilers;

namespace DogeSchool.Repository.Repositories.StudentRepository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public StudentRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }


        public async Task Create(StudentModel model)
        {
            var data = new Dictionary<string, object>()
            {
                ["id"] = Guid.NewGuid(),
                ["firstname"] = model.FirstName,
                ["lastname"] = model.LastName,
                ["birthday"] = model.BirthDate.ToUniversalTime()
            };

            using var connection = _connectionFactory.GetConnection();

            var query = new Query("demongraphics.student");
            query.AsInsert(data);

            var SQL = new PostgresCompiler().Compile(query);
            await connection.ExecuteAsync(SQL.Sql, SQL.NamedBindings);
        }

        private static readonly string[] columns = new string[]
        {
            $"id AS {nameof(StudentModel.ID)}",
            $"firstname AS {nameof(StudentModel.FirstName)}",
            $"lastname AS {nameof(StudentModel.LastName)}",
            $"birthday AS {nameof(StudentModel.BirthDate)}"
        };

        public async Task<StudentModel> Read(Guid id)
        {
            var Query = new Query("demongraphics.student");
            Query.Where("id", id);
            var SQL = new PostgresCompiler().Compile(Query);
            using var connection = _connectionFactory.GetConnection();
            var students = await connection.QueryFirstAsync<StudentModel>(SQL.Sql, SQL.NamedBindings);
            return students;
            
        }

        public async Task<IList<StudentModel>> ReadAll()
        {
           
            var Query = new Query("demongraphics.student");
            Query.Select(columns);
            var SQL = new PostgresCompiler().Compile(Query);
            using var connection = _connectionFactory.GetConnection();
            var students = await connection.QueryAsync<StudentModel>(SQL.Sql);
            return students.ToList();
        }

    }
}
