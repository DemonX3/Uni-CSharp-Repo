using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabLINQ
{
    class Worker
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public int WorkYears { get; set; }
        public double Salary { get; set; }
        public Education Education { get; set; }
        public string Direction { get; set; }

        public Worker()
        {
            Name = "John Work";
            Birthday = new DateTime();
            WorkYears = 15;
            Salary = 18000;
            Education = Education.High;
            Direction = "Job";
        }

        public Worker(string name, DateTime birthday, int workYears, double salary, Education education, string direction)
        {
            Name = name;
            Birthday = birthday;
            WorkYears = workYears;
            Salary = salary;
            Education = education;
            Direction = direction;
        }
    }
}
