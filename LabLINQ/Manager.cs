using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabLINQ
{
    class Manager
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public int WorkYears { get; set; }
        public double Salary { get; set; }
        public Education Education { get; set; }
        public string Department { get; set; }

        public Manager()
        {
            Name = "John Manage";
            Birthday = new DateTime();
            WorkYears = 15;
            Salary = 30000;
            Education = Education.High;
            Department = "Management";
        }

        public Manager(string name, DateTime birthday, int workYears, double salary, Education education, string department)
        {
            Name = name;
            Birthday = birthday;
            WorkYears = workYears;
            Salary = salary;
            Education = education;
            Department = department;
        }
    }
}
