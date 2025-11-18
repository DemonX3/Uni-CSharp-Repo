using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabSerialization
{
    [Serializable]
    public class DoctorAppointment
    {
        public string DocName { get; set; }
        public string DocQualification { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int RoomNumber { get; set; }
        public int AppointmentMinutes { get; set; }
        public List<Person> People { get; set; }

        public DoctorAppointment(string DocName, string DocQualification, DateTime AppointmentDate, int RoomNumber, int AppointmentMinutes, List<Person> People)
        {
            this.DocName = DocName;
            this.DocQualification = DocQualification;
            this.AppointmentDate = AppointmentDate;
            this.RoomNumber = RoomNumber;
            this.AppointmentMinutes = AppointmentMinutes;
            this.People = People;
        }

        public DoctorAppointment()
        {
            DocName = "John Medicine";
            DocQualification = "Therapist";
            AppointmentDate = new DateTime(2025,11,4);
            RoomNumber = 17;
            AppointmentMinutes = 20;
            People = new List<Person>();
        }
    }
}
