using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabLINQ
{
    class Phone
    {
        public string Name { get; set; }
        public string Producer {  get; set; }
        public double Cost { get; set; }
        public DateTime ReleaseDate { get; set; }

        public Phone(string name, string producer, double cost, DateTime releaseDate)
        {
            Name = name;
            Producer = producer;
            Cost = cost;
            ReleaseDate = releaseDate;
        }
    }
}
