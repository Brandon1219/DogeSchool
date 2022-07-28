using DogeSchool.Models;

namespace DogeSchool.Repository.Repositories.TeacherRepository
{
    public interface ITeacherRepository
    {
        Task Create(TeacherModel model);
        Task<IList<TeacherModel>> ReadAll();
        Task<TeacherModel> Read(Guid id);


    }
}
