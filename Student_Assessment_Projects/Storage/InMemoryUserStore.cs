using Student_Assessment_Projects.Models;

namespace Student_Assessment_Projects.Storage
{
    public class InMemoryUserStore
    {
        public static List<User> Users = new List<User>
        {
            new User { Username = "teacher1", Password = "teacherpass", Role = "Teacher" },
            new User { Username = "student1", Password = "studentpass", Role = "Student" }
        };
    }
}
