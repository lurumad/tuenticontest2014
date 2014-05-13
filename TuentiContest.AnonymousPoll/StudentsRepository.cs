using System.Collections.Generic;

namespace TuentiContest.AnonymousPoll
{
    public class StudentsRepository : IRepository
    {
        private readonly List<Student> _result;

        public StudentsRepository()
        {
            _result = new List<Student>();
            var students = Resources.students.Split('\n');

            foreach (var student in students)
            {
                var data = student.Split(',');

                if (data.Length == 1)
                {
                    continue;
                }

                _result.Add(new Student
                {
                    Name = data[0],
                    Gender = data[1],
                    Age = int.Parse(data[2]),
                    Education = data[3],
                    AcademicYear = int.Parse(data[4])
                });
            }
        }

        public IList<Student> All()
        {
            return _result;
        }
    }
}