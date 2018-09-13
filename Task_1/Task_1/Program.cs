using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//  1. Есть несколько студентов которые работают в одной группе
//  2.	У каждого студента есть несколько оценок
//  3.	Есть возможность считать средний балл отдельного студента
//  4.	Есть возможность считать средний балл всей группы
//  5.	Данные можно захардкодать или вводить с консоли

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Group one = new Group
            {
                Id = 1,
                Students = new List<Student>
                {
                    new Student
                    {
                        Id = 1,
                        Name = "Alex",
                        Marks = new List<Mark>
                        {
                            new Mark {Value = 10},
                            new Mark {Value = 8},
                            new Mark {Value = 5}
                        }
                    },
                    new Student
                    {
                        Id = 2,
                        Name = "Andrey",
                        Marks = new List<Mark>
                        {
                            new Mark {Value = 8},
                            new Mark {Value = 9},
                            new Mark {Value = 6}
                        }
                    },
                    new Student
                    {
                        Id = 3,
                        Name = "Evgeny",
                        Marks = new List<Mark>
                        {
                            new Mark {Value = 4},
                            new Mark {Value = 9},
                            new Mark {Value = 7}
                        }
                    },
                    new Student
                    {
                        Id = 5,
                        Name = "Valery",
                        Marks = new List<Mark>
                        {
                            new Mark {Value = 6},
                            new Mark {Value = 10},
                            new Mark {Value = 7}
                        }
                    }
                }
            };

            var student_id = 3;
            var mark_border = 4;

            var group_avg = one.Avg_mark_group();
            var student_avg = one.Avg_mark_student(student_id);

            Console.WriteLine($"Group average is {group_avg}");
            Console.WriteLine($"Student average is {student_avg}");

            if (student_avg < mark_border)
            {
                Console.WriteLine($"Student with id = {student_id} have bad marks");
            }
        }
    }
}
