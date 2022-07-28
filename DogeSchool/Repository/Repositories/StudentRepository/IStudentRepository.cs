using DogeSchool.Models;

namespace DogeSchool.Repository.Repositories.StudentRepository
{
    public interface IStudentRepository
    {
        Task Create(StudentModel model);
        Task<IList<StudentModel>> ReadAll();
        Task<StudentModel> Read(Guid id);


    }
}
