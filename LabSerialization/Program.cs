using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LabSerialization
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            /*
            Person person1 = new Person("Josh", 25);

            Console.WriteLine("Object created.");

            XmlSerializer serializer = new XmlSerializer(typeof(Person));

            using (FileStream fs = new FileStream("person.xml", FileMode.Create))
            {
                serializer.Serialize(fs, person1);
                Console.WriteLine($"Object serialized to {fs.Name}");
            }

            using (FileStream fs = new FileStream("person.xml", FileMode.Open))
            {
                Person? person2 = serializer.Deserialize(fs) as Person;
                Console.WriteLine($"Name: {person2.Name}\nAge: {person2.Age}");
            }
            */

            //Individual task, Variant 19.
            //Визначити КЛАС «ЗАПИС ДО ЛІКАРЯ» з полями: ПІБ лікаря; кваліфікація лікаря; дата відвідування; номер кабінету; час для огляду одного пацієнта; записані до лікаря пацієнти.
            //Створити масив об’єктів типу «ЗАПИС ДО ЛІКАРЯ». Записати пацієнтів до наявних лікарів, ураховуючи, що кожний другий (за порядком створення) лікар працює на другій зміні, а інші – на першій.
            Console.WriteLine($"\nStarting individual task, variant 19\n");

            List<Person> people = new List<Person>()
            {
                new Person("Dave",23),
                new Person("Julia",24),
                new Person("Sadrine",22),
                new Person("Soma",21),
                new Person("Gabriel",20),
                new Person("Lena",19),
                new Person("Lucia",18),
                new Person("Ishmael",20),
                new Person("Meursault",22),
                new Person("Ryoshu",21),
                new Person("Sinclair",18),
                new Person("Heathcliff",24),
                new Person("Dante",29),
                new Person("Roland",34),
                new Person("Netzach",28),
                new Person("Chesed",26),
                new Person("Malkuth",25),
                new Person("Hod",26),
                new Person("Tiphereth",19),
                new Person("Geburah",33),
                new Person("Hokma",56),
                new Person("Binah",30),
                new Person("Liam", 27),
                new Person("Emma", 34),
                new Person("Noah", 22),
                new Person("Olivia", 29),
                new Person("Mason", 31),
                new Person("Ava", 24),
                new Person("Ethan", 38),
                new Person("Isabella", 30),
                new Person("Logan", 26),
                new Person("Sophia", 28),
                new Person("Lucas", 35),
                new Person("Mia", 23),
                new Person("Jackson", 32),
                new Person("Charlotte", 27),
                new Person("Aiden", 29),
                new Person("Amelia", 33),
                new Person("Carter", 24),
                new Person("Harper", 31),
                new Person("Wyatt", 36),
                new Person("Evelyn", 25),
                new Person("Grayson", 28),
                new Person("Abigail", 30),
                new Person("Jaxon", 27),
                new Person("Emily", 34),
                new Person("Owen", 23),
                new Person("Luna", 32),
                new Person("Caleb", 26),

            };

            List<DoctorAppointment> appointments = new List<DoctorAppointment>()
            {
                new DoctorAppointment("John Health","Pharmacist",new DateTime(2025,11,5),21,45,new List<Person>()),
                new DoctorAppointment("Lucia Sussurro","Physician",new DateTime(2025,11,7),22,20,new List<Person>()),
                new DoctorAppointment("Olivia Silence","Ophthalmologist",new DateTime(2025,11,7),46,30,new List<Person>()),
                new DoctorAppointment("Siesta Ceylon","Pharmacist",new DateTime(2025,11,8),21,40,new List<Person>()),
                new DoctorAppointment("James Neurotrauma","Neurologist",new DateTime(2025,11,13),34,50,new List<Person>()),
            };

            XmlSerializer serializerPeople = new XmlSerializer(typeof(List<Person>));
            List<Person>? peopleDeserXml = new List<Person>();
            List<Person>? peopleDeserJson = new List<Person>();

            using (FileStream fs = new FileStream("people.xml", FileMode.Create))
            {
                serializerPeople.Serialize(fs, people);
                Console.WriteLine($"People serialized to {Path.GetFileName(fs.Name)}");
            }
            using (FileStream fs = new FileStream("people.json", FileMode.Create))
            {
                await JsonSerializer.SerializeAsync(fs, people, new JsonSerializerOptions { WriteIndented = true });
                Console.WriteLine($"People serialized to {Path.GetFileName(fs.Name)}");
            }

            using (FileStream fs = new FileStream("people.xml", FileMode.Open))
            {
                peopleDeserXml = serializerPeople.Deserialize(fs) as List<Person>;
                Console.WriteLine($"People deserialized from {Path.GetFileName(fs.Name)}");
            }
            using (FileStream fs = new FileStream("people.json", FileMode.Open))
            {
                peopleDeserJson = await JsonSerializer.DeserializeAsync<List<Person>>(fs);
                Console.WriteLine($"People deserialized from {Path.GetFileName(fs.Name)}\n");
            }

            List<Person> peopleDeserializedSum = new List<Person>(); //wholly unnecessary but lab requires me to do something to deserialized data, so I'm taking half from each and summing into one list to use

            while (peopleDeserXml.Count > (people.Count / 2))
            {
                peopleDeserializedSum.Add(peopleDeserXml[0]);
                peopleDeserXml.RemoveAt(0);
                peopleDeserJson.RemoveAt(0);
            }

            while (peopleDeserJson.Count > 0)
            {
                peopleDeserializedSum.Add(peopleDeserJson[0]);
                peopleDeserJson.RemoveAt(0);
            }

            int minutesPerShift; //had to make something up even if I don't get why shift matters, doctors work full hours in either, no?

            for (int i = 0; i < appointments.Count; i++)
            {
                if (peopleDeserializedSum.Count == 0) continue;
                if ((i % 2 == 0)) { minutesPerShift = 380; Console.WriteLine("First shift"); } else { minutesPerShift = 300; Console.WriteLine("Second shift"); } //нет ну реально, какая разница первая или вторая
                while (peopleDeserializedSum.Count > 0)
                {
                    if (minutesPerShift < appointments[i].AppointmentMinutes) break;
                    appointments[i].People.Add(peopleDeserializedSum[0]);
                    minutesPerShift = minutesPerShift - appointments[i].AppointmentMinutes;
                    Console.WriteLine($"{peopleDeserializedSum[0].Name} registered for appointment with {appointments[i].DocName}, {appointments[i].DocQualification} in room No.{appointments[i].RoomNumber}");
                    peopleDeserializedSum.RemoveAt(0);
                }
            }
            Console.WriteLine("All applicants were registered.\n");

            XmlSerializer serializerAppointment = new XmlSerializer(typeof(List<DoctorAppointment>)); //might as well serialize the appointments too
            List<DoctorAppointment>? appointmentsDeserXml = new List<DoctorAppointment>();
            List<DoctorAppointment>? appointmentsDeserJson = new List<DoctorAppointment>();

            using (FileStream fs = new FileStream("appointments.xml", FileMode.Create))
            {
                serializerAppointment.Serialize(fs, appointments);
                Console.WriteLine($"Appointments serialized to {Path.GetFileName(fs.Name)}");
            }
            using (FileStream fs = new FileStream("appointments.json", FileMode.Create))
            {
                await JsonSerializer.SerializeAsync(fs, appointments, new JsonSerializerOptions { WriteIndented = true });
                Console.WriteLine($"Appointments serialized to {Path.GetFileName(fs.Name)}");
            }

            using (FileStream fs = new FileStream("appointments.xml", FileMode.Open))
            {
                appointmentsDeserXml = serializerAppointment.Deserialize(fs) as List<DoctorAppointment>;
                Console.WriteLine($"Appointments deserialized from {Path.GetFileName(fs.Name)}");
            }
            using (FileStream fs = new FileStream("appointments.json", FileMode.Open))
            {
                appointmentsDeserJson = await JsonSerializer.DeserializeAsync<List<DoctorAppointment>>(fs);
                Console.WriteLine($"Appointments deserialized from {Path.GetFileName(fs.Name)}");
            }

            Console.WriteLine("\nDeserialized XML data:");
            foreach (var item in appointmentsDeserXml)
            {
                Console.WriteLine($"Doctor {item.DocName}, {item.DocQualification} in room No.{item.RoomNumber}, has {item.People.Count} appointments scheduled.");
            }

            Console.WriteLine("\nDeserialized Json data:");
            foreach (var item in appointmentsDeserJson)
            {
                Console.WriteLine($"Doctor {item.DocName}, {item.DocQualification} in room No.{item.RoomNumber}, has {item.People.Count} appointments scheduled.");
            }
        }
    }
}