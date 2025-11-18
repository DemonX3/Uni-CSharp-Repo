using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabLINQ
{
    class Company
    {
        public string Name { get; set; }
        public Employer Employer { get; set; }
        public President President { get; set; }
        public List<Manager> Managers { get; set; }
        public List<Worker> Workers { get; set; }

        public Company()
        {
            Name = "The Company";
            Employer = new Employer();
            President = new President();
            Managers = new List<Manager>();
            Workers = new List<Worker>();
        }

        public Company(string name, Employer employer, President president, List<Manager> managers, List<Worker> workers)
        {
            Name = name;
            Employer = employer;
            President = president;
            Managers = managers;
            Workers = workers;
        }
    }
}
