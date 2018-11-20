using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Mark> Marks { get; set; }

        public double Avg_Mark()
        {
            return Marks.Average(m => m.Value);
        }
    }
}
