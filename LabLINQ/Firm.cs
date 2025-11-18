using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabLINQ
{
    public class Firm
    {
        public string Name { get; set; }
        public DateTime OpeningDate { get; set; }
        public string Profile { get; set; }
        public string DirectorName { get; set; }
        public int WorkerCount { get; set; }
        public string Address { get; set; }

        public Firm(string name, DateTime openingDate, string profile, string directorName, int workerCount, string address)
        {
            Name = name;
            OpeningDate = openingDate;
            Profile = profile;
            DirectorName = directorName;
            WorkerCount = workerCount;
            Address = address;
        }

        public override string ToString()
        {
            return $"{Name}, {OpeningDate.ToShortDateString()}, {Profile}, {DirectorName}, {WorkerCount} workers, {Address}";
        }
    }
}
