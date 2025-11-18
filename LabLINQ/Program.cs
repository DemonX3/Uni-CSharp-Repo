namespace LabLINQ
{
    public enum Education { Basic, Middle, High }

    internal class Program
    {
        static void Main(string[] args)
        {
            //var studentList = new List<Student>()
            //{
            //    new Student(1,"Sussurro",15),
            //    new Student(2,"Quercus", 18),
            //    new Student(3,"Hoederer", 23),
            //    new Student(4,"Myrtle", 18),
            //    new Student(5,"Adnachiel", 16),
            //    new Student(6,"Elysium", 16),
            //    new Student(7,"Thorns", 17),
            //    new Student(8,"Spot", 20)
            //};

            //var filteredResult = from s in studentList
            //                     where s.Age > 16 && s.Age < 20
            //                     select s.Name;
            //foreach (var el in filteredResult) { Console.WriteLine(el); }

            //Console.WriteLine();

            //var groupedResult = from s in studentList
            //                    group s by s.Age;

            //foreach (var ageGroup in groupedResult)
            //{
            //    Console.WriteLine($"Age Group: {ageGroup.Key}");
            //    foreach (Student s in ageGroup)
            //    {
            //        Console.WriteLine($"Student Name: {s.Name}");
            //    }
            //}

            //Console.WriteLine();

            //IList<String> strList = new List<String>() { "One", "Two", "Three", "Four", "Five" };
            //var commaSeparatedString = strList.Aggregate((s1, s2) => s1 + "," + s2);
            //Console.WriteLine(commaSeparatedString);

            //Console.WriteLine();

            //string studentListString = studentList.Aggregate<Student, string, string>(String.Empty, (str, s) => str += s.Name + ", ", str => str.Substring(0, str.Length - 1));
            //Console.WriteLine(studentListString);


            //task 1
            Console.WriteLine("\nStarting task 1\n");

            var firmList = new List<Firm>()
            {
                new Firm("Apex Food Solutions", new DateTime(1980, 6, 12), "Marketing", "John White", 200, "London"),
                new Firm("White Harvest Foods", new DateTime(2025, 5, 17), "Food", "John Black", 100, "Tokyo"),
                new Firm("Synergy Tech", new DateTime(2000, 3, 15), "IT", "David Lee", 270, "Sydney"),
                new Firm("Bright Marketing Group", new DateTime(1980, 6, 19), "Marketing", "Emily Carter", 300, "Rome"),
                new Firm("Global Reach Co.", new DateTime(1990, 8, 15), "Marketing", "James Wilson", 500, "New York"),
                new Firm("Fresh Delights Inc.", new DateTime(2015, 1, 10), "Food", "Jessica Brown", 700, "Berlin"),
                new Firm("Elite Marketing Services", new DateTime(2010, 9, 8), "Marketing", "Robert Garcia", 1400, "Toronto")
            };
            Console.WriteLine("\nAll firms: ");
            var filterResult = from s in firmList
                               select s.ToString();
            foreach (var el in filterResult) Console.WriteLine(el);

            Console.WriteLine("\nFirms with \"Food\" in name: ");
            filterResult = from s in firmList
                           where s.Name.Contains("Food")
                           select s.ToString();
            foreach (var el in filterResult) Console.WriteLine(el);

            Console.WriteLine("\nFirms with \"Marketing\" specialization: ");
            filterResult = from s in firmList
                           where s.Profile == "Marketing"
                           select s.ToString();
            foreach (var el in filterResult) Console.WriteLine(el);

            Console.WriteLine("\nFirms with \"Marketing\" or \"IT\" specialization: ");
            filterResult = from s in firmList
                           where s.Profile == "Marketing" || s.Profile == "IT"
                           select s.ToString();
            foreach (var el in filterResult) Console.WriteLine(el);

            Console.WriteLine("\nFirms with >100 workers: ");
            filterResult = from s in firmList
                           where s.WorkerCount > 100
                           select s.ToString();
            foreach (var el in filterResult) Console.WriteLine(el);

            Console.WriteLine("\nFirms with >=100 and <=300 workers: ");
            filterResult = from s in firmList
                           where s.WorkerCount >= 100 && s.WorkerCount <= 300
                           select s.ToString();
            foreach (var el in filterResult) Console.WriteLine(el);

            Console.WriteLine("\nFirms based in London: ");
            filterResult = from s in firmList
                           where s.Address == "London"
                           select s.ToString();
            foreach (var el in filterResult) Console.WriteLine(el);

            Console.WriteLine("\nFirms with director \"White\": ");
            filterResult = from s in firmList
                           where s.DirectorName.Contains("White")
                           select s.ToString();
            foreach (var el in filterResult) Console.WriteLine(el);

            Console.WriteLine("\nFirms over 2 years old: ");
            filterResult = from s in firmList
                           where DateTime.Now.Year - s.OpeningDate.Year > 2
                           select s.ToString();
            foreach (var el in filterResult) Console.WriteLine(el);

            Console.WriteLine("\nFirms over 150 days old: ");
            filterResult = from s in firmList
                           where (DateTime.Now.Year - s.OpeningDate.Year)
                           + (DateTime.Now.DayOfYear - s.OpeningDate.DayOfYear) > 150
                           select s.ToString();
            foreach (var el in filterResult) Console.WriteLine(el);

            Console.WriteLine("\nFirms with director \"Black\" in company with \"White\" in it's name: ");
            filterResult = from s in firmList
                           where s.DirectorName.Contains("Black") && s.Name.Contains("White")
                           select s.ToString();
            foreach (var el in filterResult) Console.WriteLine(el);


            //task 2
            Console.WriteLine("\nStarting task 2\n");

            var phoneList = new List<Phone>()
            {
                new Phone("iPhone 15 Pro Max", "Apple", 1199.99, new DateTime(2023, 9, 22)),
                new Phone("Galaxy S24 Ultra", "Samsung", 1299.00, new DateTime(2024, 1, 25)),
                new Phone("Pixel 8 Pro", "Google", 999.00, new DateTime(2023, 10, 12)),
                new Phone("OnePlus 12", "OnePlus", 799.99, new DateTime(2024, 1, 5)),
                new Phone("Xperia 1 V", "Sony", 1399.00, new DateTime(2023, 5, 11)),
                new Phone("Moto Edge 40 Pro", "Motorola", 899.00, new DateTime(2023, 4, 20)),
                new Phone("Redmi Note 13 Pro+", "Xiaomi", 459.99, new DateTime(2024, 2, 10)),
                new Phone("Galaxy Z Flip5", "Samsung", 999.99, new DateTime(2023, 7, 26)),
                new Phone("Asus ROG Phone 8", "ASUS", 1099.00, new DateTime(2024, 2, 1)),
                new Phone("iPhone SE (3rd Gen)", "Apple", 429.00, new DateTime(2022, 3, 18)),
                new Phone("Nothing Phone (2)", "Nothing", 699.00, new DateTime(2023, 7, 17)),
                new Phone("Honor Magic6 Pro", "Honor", 1199.00, new DateTime(2024, 1, 18)),
                new Phone("Vivo X100 Pro", "Vivo", 1099.00, new DateTime(2023, 11, 21)),
                new Phone("Oppo Find X7 Ultra", "Oppo", 1149.00, new DateTime(2024, 1, 8)),
                new Phone("Realme GT5 Pro", "Realme", 799.00, new DateTime(2023, 12, 7)),
                new Phone("Huawei P60 Pro", "Huawei", 999.00, new DateTime(2023, 4, 21)),
                new Phone("Fairphone 5", "Fairphone", 749.00, new DateTime(2023, 9, 14)),
                new Phone("Nokia G42 5G", "Nokia", 299.99, new DateTime(2023, 6, 28)),
                new Phone("Tecno Phantom V Fold", "Tecno", 1099.00, new DateTime(2023, 3, 1)),
                new Phone("ZTE Axon 50 Ultra", "ZTE", 899.00, new DateTime(2023, 5, 9))
            };

            var phoneQuery = from s in phoneList
                             select s;
            Console.WriteLine($"Phone amount: {phoneQuery.Count()}");

            phoneQuery = from s in phoneList
                         where s.Cost > 600
                         select s;
            Console.WriteLine($"Phone amount (cost above 600): {phoneQuery.Count()}");

            phoneQuery = from s in phoneList
                         where s.Cost > 400 && s.Cost < 700
                         select s;
            Console.WriteLine($"Phone amount (cost above 400 below 700): {phoneQuery.Count()}");

            phoneQuery = from s in phoneList
                         where s.Producer == "Apple"
                         select s;
            Console.WriteLine($"Phone amount (produced by Apple): {phoneQuery.Count()}");

            phoneQuery = from s in phoneList
                         orderby s.Cost descending
                         select s;
            Console.WriteLine($"Cheapest phone: {phoneQuery.Last().Name}, ${phoneQuery.Last().Cost}");
            Console.WriteLine($"Most expensive phone: {phoneQuery.First().Name}, ${phoneQuery.First().Cost}");

            phoneQuery = from s in phoneList
                         orderby s.ReleaseDate.Ticks descending
                         select s;
            Console.WriteLine($"Oldest phone: {phoneQuery.Last().Name}, released {phoneQuery.Last().ReleaseDate.ToShortDateString()}");
            Console.WriteLine($"Newest phone: {phoneQuery.First().Name}, released {phoneQuery.First().ReleaseDate.ToShortDateString()}");

            double phoneAveragePrice = Math.Round(phoneList.Average(s => s.Cost), 2);
            Console.WriteLine($"Average phone price: ${phoneAveragePrice}");

            phoneQuery = from s in phoneList
                         orderby s.Cost descending
                         select s;

            Console.WriteLine($"\n5 most expensive phones:");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{phoneQuery.ElementAt(i).Name}, ${phoneQuery.ElementAt(i).Cost}");
            }
            Console.Write($"\n5 cheapest phones:");
            for (int i = phoneQuery.Count() - 1; i > (phoneQuery.Count() - 6); i--)
            {
                Console.WriteLine($"{phoneQuery.ElementAt(i).Name}, ${phoneQuery.ElementAt(i).Cost}");
            }

            phoneQuery = from s in phoneList
                         orderby s.ReleaseDate.Ticks descending
                         select s;

            Console.WriteLine($"\n3 oldest phones:");
            for (int i = phoneQuery.Count() - 1; i > (phoneQuery.Count() - 4); i--)
            {
                Console.WriteLine($"{phoneQuery.ElementAt(i).Name}, {phoneQuery.ElementAt(i).ReleaseDate.ToShortDateString()}");
            }
            Console.WriteLine($"\n3 newest phones:");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"{phoneQuery.ElementAt(i).Name}, {phoneQuery.ElementAt(i).ReleaseDate.ToShortDateString()}");
            }

            var phoneGroupQuery = from s in phoneList
                                  group s by s.Producer;

            Console.WriteLine($"\nPhones by producer:");
            foreach (var producer in phoneGroupQuery)
            {
                Console.WriteLine($"{producer.Key} - {producer.Count()}");
            }

            Console.WriteLine($"\nPhones by model skipped because they're all different models, but principle is basically the same as other grouping.");

            var phoneAgeQuery = from s in phoneList
                                group s by s.ReleaseDate.Year;

            Console.WriteLine($"\nPhones by year:");
            foreach (var year in phoneAgeQuery)
            {
                Console.WriteLine($"{year.Key} - {year.Count()}");
            }



            //task 3
            Console.WriteLine("\n###Starting task 3");

            var workerList = new List<Worker>()
            {
                new Worker("Ivan Petrov", new DateTime(1985, 3, 20), 12, 25000, Education.High, "Sales"),
                new Worker("Olga Sidorova", new DateTime(1992, 7, 10), 5, 18000, Education.Middle, "Marketing"),
                new Worker("Andriy Kovalenko", new DateTime(1978, 11, 5), 20, 30000, Education.High, "Engineering"),
                new Worker("Tetiana Melnyk", new DateTime(1995, 4, 28), 3, 12000, Education.Basic, "HR"),
                new Worker("Mykola Lysenko", new DateTime(1980, 9, 15), 15, 25000, Education.High, "Finance"),
                new Worker("Svitlana Shevchenko", new DateTime(1998, 1, 22), 1, 18000, Education.Middle, "Operations"),
                new Worker("Dmytro Bondarenko", new DateTime(1975, 6, 8), 23, 30000, Education.High, "IT"),
                new Worker("Natalia Kravchenko", new DateTime(1990, 10, 17), 8, 15000, Education.Middle, "Customer Service"),
                new Worker("Oleksandr Hryhorenko", new DateTime(1982, 5, 3), 14, 28000, Education.High, "Engineering"),
                new Worker("Hanna Zaharenko", new DateTime(1997, 12, 12), 2, 20000, Education.Basic, "HR"),
                new Worker("Viktor Chernenko", new DateTime(1973, 2, 7), 21, 35000, Education.High, "IT"),
                new Worker("Iryna Ponomarenko", new DateTime(1988, 8, 25), 10, 10000, Education.Middle, "Operations"),
                new Worker("Serhiy Vorontsov", new DateTime(1979, 4, 16), 18, 15000, Education.High, "Finance"),
                new Worker("Kateryna Zubko", new DateTime(1993, 6, 30), 6, 29000, Education.Middle, "Marketing"),
                new Worker("Volodymyr Mazurenko", new DateTime(1984, 1, 19), 13, 17000, Education.High, "IT"),
                new Worker("Anastasiia Holub", new DateTime(1996, 9, 5), 4, 23000, Education.Basic, "HR"),
                new Worker("Yuriy Kovalchuk", new DateTime(1977, 7, 21), 22, 28000, Education.High, "Engineering"),
                new Worker("Oksana Sydorenko", new DateTime(1989, 3, 9), 9, 16000, Education.Middle, "Customer Service"),
                new Worker("Maksym Kostenko", new DateTime(1981, 11, 14), 16, 22000, Education.High, "Finance"),
                new Worker("Valentyna Petrenko", new DateTime(1994, 5, 1), 7, 8000, Education.Basic, "HR"),
                new Worker("Taras Hlibov", new DateTime(1976, 10, 27), 24, 33000, Education.High, "IT"),
                new Worker("Liudmyla Vasylyshyn", new DateTime(1983, 2, 11), 11, 22000, Education.Middle, "Operations"),
                new Worker("Bohdan Prylushkin", new DateTime(1999, 8, 18), 0, 9000, Education.Basic, "HR"),
                new Worker("Nadiia Zinko", new DateTime(1987, 6, 4), 12, 33000, Education.High, "Finance"),
                new Worker("Volodymyr Melnyk", new DateTime(1991, 9, 23), 5, 25000, Education.Middle, "Marketing"),
                new Worker("Halyna Kopytko", new DateTime(1974, 4, 10), 20, 32000, Education.High, "Engineering"),
                new Worker("Ihor Shvets", new DateTime(1986, 7, 17), 13, 26000, Education.High, "IT"),
                new Worker("Larysa Danylko", new DateTime(1997, 1, 29), 3, 11000, Education.Basic, "HR"),
                new Worker("Vadym Tkachuk", new DateTime(1982, 5, 6), 17, 24000, Education.High, "Engineering"),
                new Worker("Mariia Kolodii", new DateTime(1990, 10, 3), 8, 14000, Education.Middle, "Customer Service"),
                new Worker("Ihor Fedyk", new DateTime(1975, 6, 14), 23, 39000, Education.High, "IT"),
                new Worker("Yuliia Hrebeniuk", new DateTime(1998, 12, 2), 1, 14000, Education.Middle, "Operations"),
                new Worker("Anatoliy Zaytsev", new DateTime(1973, 2, 26), 21, 36000, Education.High, "Finance"),
                new Worker("Oksana Tsvirkun", new DateTime(1985, 8, 8), 10, 11000, Education.Middle, "Customer Service"),
                new Worker("Oleksii Lukianenko", new DateTime(1979, 4, 22), 18, 26000, Education.High, "Engineering"),
                new Worker("Khrystyna Melnyk", new DateTime(1993, 6, 15), 7, 18000, Education.Middle, "Marketing"),
                new Worker("Pavlo Shevchenko", new DateTime(1984, 1, 25), 14, 39000, Education.High, "IT"),
                new Worker("Volodymyr Bilyk", new DateTime(1996, 9, 13), 4, 14000, Education.Basic, "HR"),
                new Worker("Ruslan Hrytsenko", new DateTime(1977, 7, 5), 22, 37000, Education.High, "Finance"),
                new Worker("Vira Kravchuk", new DateTime(1988, 3, 16), 9, 17000, Education.Middle, "Customer Service"),
                new Worker("Mykhailo Kovalenko", new DateTime(1981, 11, 2), 16, 33000, Education.High, "Engineering"),
                new Worker("Sofia Klymenko", new DateTime(1994, 5, 20), 7, 12000, Education.Basic, "HR"),
                new Worker("Anton Kovalchuk", new DateTime(1976, 10, 28), 24, 32000, Education.High, "IT"),
                new Worker("Yevhenia Ponomarenko", new DateTime(1983, 2, 10), 11, 24000, Education.Middle, "Operations"),
                new Worker("Maksym Shevchuk", new DateTime(1999, 8, 17), 1, 17000, Education.Basic, "HR"),
                new Worker("Alina Danylko", new DateTime(1987, 6, 3), 12, 35500, Education.High, "IT"),
                new Worker("Viktor Holovatiuk", new DateTime(1991, 9, 22), 5, 14500, Education.Middle, "Customer Service"),
                new Worker("Olena Kravchenko", new DateTime(1974, 4, 9), 20, 33000, Education.High, "Engineering"),
            };

            var managerList = new List<Manager>()
            {
                new Manager("Ivan Petrov", new DateTime(1978, 3, 20), 15, 75000, Education.High, "Sales"),
                new Manager("Olga Sidorova", new DateTime(1985, 7, 10), 10, 65000, Education.Middle, "Marketing"),
                new Manager("Andriy Kovalenko", new DateTime(1972, 11, 5), 21, 90000, Education.High, "Engineering"),
                new Manager("Tetiana Melnyk", new DateTime(1987, 4, 28), 8, 55000, Education.Basic, "HR"),
                new Manager("Mykola Lysenko", new DateTime(1968, 9, 15), 23, 100000, Education.High, "Finance"),
                new Manager("Svitlana Shevchenko", new DateTime(1990, 1, 22), 6, 50000, Education.Middle, "Operations"),
                new Manager("Dmytro Bondarenko", new DateTime(1970, 6, 8), 25, 110000, Education.High, "IT"),
                new Manager("Natalia Kravchenko", new DateTime(1983, 10, 17), 12, 70000, Education.Middle, "Customer Service"),
                new Manager("Oleksandr Hryhorenko", new DateTime(1965, 5, 3), 27, 120000, Education.High, "Product Development"),
                new Manager("Hanna Zaharenko", new DateTime(1989, 12, 12), 7, 60000, Education.Basic, "Quality Assurance"),
            };

            Company company = new Company("Lobotomy Corporation",
                new Employer("Ayin", new DateTime(1018, 9, 13), 17863, 9999999, Education.High),
                new President("Angela", new DateTime(1035, 10, 22), 17832, 12, Education.High),
                managerList, workerList);

            var companyQuery1 = from s in company.Workers
                                select s;

            Console.WriteLine($"\nWorkers in {company.Name}: {companyQuery1.Count()}");

            double salarySum = 0;

            foreach (var item in companyQuery1)
            {
                salarySum += item.Salary;
            }

            Console.WriteLine($"\nTotal sum of all worker salaries: {salarySum}UAH");

            var companyQuery2First = from s in company.Workers
                                     orderby s.WorkYears descending
                                     select s;

            List<Worker> companyQuery2List = companyQuery2First.ToList();

            while (companyQuery2List.Count() > 10)
            {
                companyQuery2List.RemoveAt(companyQuery2List.Count() - 1);
            }

            var companyQuery2Final = from s in companyQuery2List
                                     orderby s.Birthday descending
                                     where s.Education == Education.High
                                     select s;

            Console.WriteLine($"\nYoungest experienced worker with High education: {companyQuery2Final.First().Name}");

            var companyQuery3 = from s in company.Managers
                                orderby (DateTime.Now - s.Birthday) descending
                                select s;

            Console.WriteLine($"\nYoungest manager: {companyQuery3.Last().Name}, {DateTime.Now.Year - companyQuery3.Last().Birthday.Year} years" +
                              $"\nOldest manager: {companyQuery3.First().Name}, {DateTime.Now.Year - companyQuery3.First().Birthday.Year} years");

            var companyQuery4 = from s in company.Workers
                                where s.Birthday.Month == 8
                                group s by s.Direction;

            Console.WriteLine($"\nWorkers born in October, counted by professional direction:");
            foreach (var direction in companyQuery4)
            {
                Console.WriteLine($"{direction.Key} - {direction.Count()}");
            }

            var companyQuery5 = from s in company.Workers
                                where s.Name.Contains("Volodymyr")
                                orderby s.Birthday ascending
                                select s;

            Console.WriteLine($"\nVolodymyrs working in the company:");
            foreach (var volodya in companyQuery5)
            {
                Console.WriteLine($"{volodya.Name}");
            }
            Console.WriteLine($"\nCongratulations, {companyQuery5.First().Name} as the youngest Volodymyr is granted {Math.Round(companyQuery5.First().Salary / 3)}UAH bonus!\nKeep up being Volodymyr and not Oleg!");
        }
    }
}
