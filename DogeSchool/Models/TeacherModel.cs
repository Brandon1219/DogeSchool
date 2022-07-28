using System.ComponentModel;

namespace DogeSchool.Models
{
    public class TeacherModel
    {
        public Guid ID { get; set; }

        [DisplayName("FirstName")]
        public string FirstName { get; set; }

        [DisplayName("LastName")]
        public string LastName { get; set; }



    }
}
