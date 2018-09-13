using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Task_1
{
    class Group
    {
        public int Id { get; set; }

        public List<Student> Students { get; set; }

        public double Avg_mark_group()
        {
            return Students.Select(s => s.Avg_Mark()).Average();
        }

        public double Avg_mark_student(int id)
        {
            if (id < 0 || id > 10)
            {
                throw new ArgumentOutOfRangeException();
            }

            var student = Students.FirstOrDefault(i => i.Id == id);

            if (student == null)
            {
                throw new ArgumentOutOfRangeException();
            }

            return student.Avg_Mark();
        }
    }
}