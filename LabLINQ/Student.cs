using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabLINQ
{

    [Serializable]
    public class Student
    {
        public int StudentID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Student(int studentId, string name, int age)
        {
            StudentID = studentId;
            Name = name;
            Age = age;
        }
    }
}
