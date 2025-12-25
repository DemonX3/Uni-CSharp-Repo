using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGeneric
{
    public class PrinterQuery
    {
        public Person Person { get; set; }
        public TimeSpan Time { get; set; }
        public double Priority { get; set; }

        public PrinterQuery() 
        {
            Person = new Person();
            Time = new TimeSpan(0,0,15);
            Priority = 0;
        }

        public PrinterQuery(Person person, TimeSpan time, double priority)
        {
            Person = person;
            Time = time;
            Priority = priority;
        }
    }
}
