using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabLINQ
{
    class President
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public int WorkYears { get; set; }
        public double Salary { get; set; }
        public Education Education { get; set; }

        public President()
        {
            Name = "John President";
            Birthday = new DateTime();
            WorkYears = 15;
            Salary = 70000;
            Education = Education.High;
        }

        public President(string name, DateTime birthday, int workYears, double salary, Education education)
        {
            Name = name;
            Birthday = birthday;
            WorkYears = workYears;
            Salary = salary;
            Education = education;
        }
    }
}
