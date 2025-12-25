using System.Xml.Serialization;

namespace LabGeneric
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task 1: (Use List<> on lab 1(I already do but ig I have to copy-paste anyway))
            Console.WriteLine("Starting task 1. Generic collection usage");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey(true);

            var people = new List<Person>()
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
                new DoctorAppointment("Olivia Silence","Oculist",new DateTime(2025,11,7),46,30,new List<Person>()),
                new DoctorAppointment("Siesta Ceylon","Pharmacist",new DateTime(2025,11,8),21,40,new List<Person>()),
                new DoctorAppointment("James Neurotrauma","Neurologist",new DateTime(2025,11,13),34,50,new List<Person>()),
            };

            int minutesPerShift;
            var task1People = new List<Person>();
            foreach (var item in people)
            {
                task1People.Add(item);
            }

            for (int i = 0; i < appointments.Count; i++)
            {
                if (i % 2 == 0) minutesPerShift = 380; else minutesPerShift = 300;
                while (task1People.Count > 0)
                {
                    if (minutesPerShift < appointments[i].AppointmentMinutes) break;
                    appointments[i].People.Add(task1People[0]);
                    minutesPerShift = minutesPerShift - appointments[i].AppointmentMinutes;
                    //Console.WriteLine($"{task1People[0].Name} registered for appointment with {appointments[i].DocName}, {appointments[i].DocQualification} in room No.{appointments[i].RoomNumber}");
                    task1People.RemoveAt(0);
                }
            }
            Console.WriteLine("\nAll applicants were registered.");

            XmlSerializer serializer2 = new XmlSerializer(typeof(DoctorAppointment));

            using (FileStream fs = new FileStream("appointments.xml", FileMode.OpenOrCreate))
            {
                foreach (var item in appointments)
                {
                    serializer2.Serialize(fs, item);
                }
                Console.WriteLine($"Appointments serialized to {Path.GetFileName(fs.Name)}");
            }

            //Task 2
            //I am genuinely at a loss at what I'm supposed to do
            //nvm I think I have conceived an idea most ingenious
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey(true);
            Console.Clear();
            Console.WriteLine("Starting task 2. Text word counter");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey(true);

            Dictionary<string, int> analysis;
            Dictionary<int, string> selector;
            string selection;
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Files:\n");
                selector = MakeListSelector(GetWordFiles().ToList());
                selector.Add(0, "Cancel selection and go to next task");
                foreach (var item in selector)
                {
                    Console.WriteLine($"{item.Key}. {item.Value}");
                }
                Console.WriteLine("\nSelect option:");

                selection = TryParseCommand(selector, Console.ReadLine());
                if (selection == null || selection.Length == 0 || selection.Equals(String.Empty)) // WHY IS EMPTY READLINE CAUSING EXCEPTION?? WHAT KINDA NULLCHECK YOU WANT???
                {
                    Console.WriteLine("Wrong input.");

                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey(true);

                    continue;
                }

                if (selection == selector[0] || !selector.ContainsValue(selection)) break;

                analysis = AnalyzeWordFile(selection);
                Console.WriteLine("Word, Amount:\n");

                for (int i = 0, j = 1; i < analysis.Count; i++)
                {
                    if (j < 6)
                    {
                        Console.Write($"{analysis.ElementAt(i).Key}, {analysis.ElementAt(i).Value} | ");
                        j++;
                    }
                    else if (j == 6)
                    {
                        Console.Write($"{analysis.ElementAt(i).Key}, {analysis.ElementAt(i).Value}\n");
                        j = 1;
                    }
                }

                Console.WriteLine("\n\nPress any key to continue...");
                Console.ReadKey(true);
            }//Most ideal

            //Task 3: Printer queue
            Console.Clear();
            Console.WriteLine("\nStarting task 3. Printer queue");

            List<PrinterQuery> printerQueue = new List<PrinterQuery>();

            Random random = new Random();
            for (int i = 0; i < people.Count(); i++)
            {
                printerQueue.Add(new PrinterQuery(people[i], new TimeSpan(0, random.Next(0, 5), random.Next(7, 59)), random.Next(0, 10)));
            }
            printerQueue.Sort((x, y) => x.Priority.CompareTo(y.Priority));
            Console.WriteLine("Order. Person, Time to print, Priority:");
            for (int i = 0; i < printerQueue.Count; i++)
            {
                Console.WriteLine($"{i}. {printerQueue[i].Person.Name}, {printerQueue[i].Time.ToString()}, {printerQueue[i].Priority}");
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey(true);

            //Task 4: Word dictionary
            Console.Clear();
            Console.WriteLine("\nStarting task 4. Word dictionary manager");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey(true);

            bool dictionaryOn = true;
            string command, input1, input2;
            List<string> resultList;
            List<string> commandList = new List<string>();
            Dictionary<int, string> commandSelector;

            while (dictionaryOn)
            {
                Console.Clear();
                //ReformatDictionaries();
                Console.WriteLine("Dictionaries:");
                resultList = GetDictionaries(true);
                foreach (var item in resultList)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine(
                    "\n1. Open dictionary" +
                    "\n2. Create dictionary" +
                    "\n3. Delete dictionary" +
                    "\n0. Close program"
                    );
                Console.WriteLine("\nSelect option:");
                commandList.Clear();
                commandList.AddRange(["opendict", "createdict", "deletedict"]);
                commandSelector = MakeListSelector(commandList);
                commandSelector.Add(0, "stop");

                command = TryParseCommand(commandSelector, Console.ReadLine());
                if (command == null || command.Length == 0)
                {
                    Console.WriteLine("Wrong input.");

                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey(true);

                    continue;
                }


                switch (command)
                {
                    case "opendict":
                        Console.Clear();
                        Console.WriteLine("Dictionaries:");
                        commandSelector = MakeListSelector(GetDictionaries(false));
                        commandSelector.Add(0, "Cancel selection");
                        foreach (var item in commandSelector)
                        {
                            Console.WriteLine($"{item.Key}. {item.Value}");
                        }
                        Console.WriteLine("\nSelect dictionary:");

                        command = TryParseCommand(commandSelector, Console.ReadLine());
                        if (command == null || command.Length == 0)
                        {
                            Console.WriteLine("Wrong input.");

                            Console.WriteLine("\nPress any key to continue...");
                            Console.ReadKey(true);

                            break;
                        }

                        if (command == commandSelector[0] || !commandSelector.ContainsValue(command)) break;

                        string selectedDictionary = command;
                        bool insideDictionary = true;
                        while (insideDictionary)
                        {
                            Console.Clear();
                            Console.WriteLine(
                                $"{selectedDictionary}/\n" +
                                $"\n1. Open word" +
                                $"\n2. Add word" +
                                $"\n3. Delete word" +
                                $"\n0. Return"
                                );
                            Console.WriteLine("\nSelect option:");
                            commandList.Clear();
                            commandList.AddRange(["openword", "addword", "deleteword"]);
                            commandSelector = MakeListSelector(commandList);
                            commandSelector.Add(0, "stop");

                            command = TryParseCommand(commandSelector, Console.ReadLine());
                            if (command == null || command.Length == 0)
                            {
                                Console.WriteLine("Wrong input.");

                                Console.WriteLine("\nPress any key to continue...");
                                Console.ReadKey(true);

                                continue;
                            }

                            switch (command)
                            {
                                case "openword":
                                    Console.Clear();
                                    Console.WriteLine($"{selectedDictionary}/\n" +
                                        $"\nWords:\n");
                                    commandSelector = MakeListSelector(GetWords(selectedDictionary));

                                    if (commandSelector.Count == 0)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("No words in the dictionary, returning...");

                                        Console.WriteLine("\nPress any key to continue...");
                                        Console.ReadKey(true);
                                        break;
                                    }

                                    commandSelector.Add(0, "Cancel selection");
                                    foreach (var item in commandSelector)
                                    {
                                        Console.WriteLine($"{item.Key}. {item.Value}");
                                    }
                                    Console.WriteLine("\nSelect word:");

                                    command = TryParseCommand(commandSelector, Console.ReadLine());
                                    if (command == null || command.Length == 0)
                                    {
                                        Console.WriteLine("Wrong input.");

                                        Console.WriteLine("\nPress any key to continue...");
                                        Console.ReadKey(true);

                                        break;
                                    }

                                    if (command == commandSelector[0] || !commandSelector.ContainsValue(command)) break;

                                    string selectedWord = command;
                                    bool insideWord = true;
                                    while (insideWord)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"{selectedDictionary}/{selectedWord}/\n" +
                                            $"\n1. Add translation" +
                                            $"\n2. Change translation" +
                                            $"\n3. Delete translation" +
                                            $"\n4. Change word" +
                                            $"\n5. Export translations" +
                                            $"\n0. Return");
                                        Console.WriteLine("\nSelect option:");
                                        commandList.Clear();
                                        commandList.AddRange(["addtrans", "changetrans", "deletetrans", "changeword", "export"]);
                                        commandSelector = MakeListSelector(commandList);
                                        commandSelector.Add(0, "stop");

                                        command = TryParseCommand(commandSelector, Console.ReadLine());
                                        if (command == null || command.Length == 0)
                                        {
                                            Console.WriteLine("Wrong input.");

                                            Console.WriteLine("\nPress any key to continue...");
                                            Console.ReadKey(true);

                                            continue;
                                        }

                                        Console.Clear();
                                        Console.WriteLine($"{selectedDictionary}/{selectedWord}/");
                                        switch (command)
                                        {
                                            case "addtrans":
                                                Console.WriteLine("\nExisting translations:");
                                                resultList = GetWordTranslations(selectedDictionary, selectedWord);
                                                for (int i = 0, j = 1; i < resultList.Count; i++)
                                                {
                                                    if (j < 6)
                                                    {
                                                        Console.Write($"{resultList[i]}, ");
                                                        j++;
                                                    }
                                                    else if (j == 6)
                                                    {
                                                        Console.Write($"{resultList[i]}\n");
                                                        j = 1;
                                                    }
                                                }
                                                Console.WriteLine("\nEnter 1 or multiple (separate with \",\") translations (leave empty to cancel):");
                                                input1 = Console.ReadLine();
                                                if (input1 == null || input1.Length == 0)
                                                {
                                                    Console.WriteLine("Empty input.");

                                                    Console.WriteLine("\nPress any key to continue...");
                                                    Console.ReadKey(true);
                                                    break;
                                                }

                                                AddWordToDictionary(selectedDictionary, selectedWord, input1);

                                                if (input1.Contains(','))
                                                {
                                                    string[] parts = input1.Split(',');
                                                    foreach (var item in parts)
                                                    {
                                                        item.Trim();
                                                    }
                                                    Console.WriteLine($"Added \"{parts.Length}\" translations to \"{selectedWord}\" word");
                                                }
                                                else
                                                {
                                                    Console.WriteLine($"Added \"{input1}\" translation to \"{selectedWord}\" word");
                                                }

                                                Console.WriteLine("\nPress any key to continue...");
                                                Console.ReadKey(true);
                                                break;

                                            case "deletetrans":
                                                Console.WriteLine("\nExisting translations:");
                                                commandSelector = MakeListSelector(GetWordTranslations(selectedDictionary, selectedWord));

                                                if (commandSelector.Count == 0)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("No translations in the dictionary, returning...");

                                                    Console.WriteLine("\nPress any key to continue...");
                                                    Console.ReadKey(true);
                                                    break;
                                                }

                                                commandSelector.Add(0, "stop");
                                                Console.WriteLine("0. Cancel selection");
                                                for (int i = 1, j = 1; i < commandSelector.Count; i++)
                                                {
                                                    if (j < 6)
                                                    {
                                                        Console.Write($"{i}. {commandSelector[i]}  ");
                                                        j++;
                                                    }
                                                    else if (j == 6)
                                                    {
                                                        Console.Write($"{i}. {commandSelector[i]}\n");
                                                        j = 1;
                                                    }
                                                }
                                                Console.WriteLine("\nSelect translation:");

                                                command = TryParseCommand(commandSelector, Console.ReadLine());
                                                if (command == null || command.Length == 0)
                                                {
                                                    Console.WriteLine("Wrong input.");

                                                    Console.WriteLine("\nPress any key to continue...");
                                                    Console.ReadKey(true);

                                                    break;
                                                }

                                                if (command == commandSelector[0] || !commandSelector.ContainsValue(command)) break;

                                                DeleteTranslationFromDictionary(selectedDictionary, selectedWord, command);

                                                Console.Clear();
                                                Console.WriteLine($"Translation \"{command}\" has been deleted from word \"{selectedWord}\"");

                                                Console.WriteLine("\nPress any key to continue...");
                                                Console.ReadKey(true);
                                                break;

                                            case "changetrans":
                                                Console.WriteLine("\nExisting translations:");
                                                commandSelector = MakeListSelector(GetWordTranslations(selectedDictionary, selectedWord));

                                                if (commandSelector.Count == 0)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("No translations in the dictionary, returning...");

                                                    Console.WriteLine("\nPress any key to continue...");
                                                    Console.ReadKey(true);
                                                    break;
                                                }

                                                commandSelector.Add(0, "stop");
                                                Console.WriteLine("0. Cancel selection");
                                                for (int i = 1, j = 1; i < commandSelector.Count; i++)
                                                {
                                                    if (j < 6)
                                                    {
                                                        Console.Write($"{i}. {commandSelector[i]}  ");
                                                        j++;
                                                    }
                                                    else if (j == 6)
                                                    {
                                                        Console.Write($"{i}. {commandSelector[i]}\n");
                                                        j = 1;
                                                    }
                                                }
                                                Console.WriteLine("\nSelect translation:");

                                                command = TryParseCommand(commandSelector, Console.ReadLine());
                                                if (command == null || command.Length == 0)
                                                {
                                                    Console.WriteLine("Wrong input.");

                                                    Console.WriteLine("\nPress any key to continue...");
                                                    Console.ReadKey(true);

                                                    break;
                                                }

                                                if (command == commandSelector[0] || !commandSelector.ContainsValue(command)) break;

                                                Console.Clear();
                                                Console.WriteLine($"{selectedDictionary}/{selectedWord}/{command}/" +
                                                    $"\n\nEnter new translation (leave empty to cancel):");
                                                input1 = Console.ReadLine();
                                                if (input1 == null || input1.Length == 0)
                                                {
                                                    Console.WriteLine("Empty input.");

                                                    Console.WriteLine("\nPress any key to continue...");
                                                    Console.ReadKey(true);
                                                    break;
                                                }
                                                ChangeTranslationInDictionary(selectedDictionary, selectedWord, command, input1);

                                                if (input1.Contains(','))
                                                {
                                                    string[] parts = input1.Split(',');
                                                    foreach (var item in parts)
                                                    {
                                                        item.Trim();
                                                    }
                                                    Console.WriteLine($"Added \"{parts.Length}\" translations to \"{selectedWord}\" word");
                                                }
                                                else
                                                {
                                                    Console.WriteLine($"Added \"{input1}\" translation to \"{selectedWord}\" word");
                                                }

                                                Console.WriteLine("\nPress any key to continue...");
                                                Console.ReadKey(true);
                                                break;

                                            case "changeword":
                                                Console.WriteLine("Enter new word (leave empty to cancel):");
                                                input1 = Console.ReadLine().ToLower();
                                                if (input1 == null || input1.Length == 0)
                                                {
                                                    Console.WriteLine("Empty input.");

                                                    Console.WriteLine("\nPress any key to continue...");
                                                    Console.ReadKey(true);
                                                    break;
                                                }
                                                ChangeWordInDictionary(selectedDictionary, selectedWord, input1);


                                                Console.WriteLine($"Changed \"{selectedWord}\" to \"{input1}\"");
                                                selectedWord = input1;

                                                Console.WriteLine("\nPress any key to continue...");
                                                Console.ReadKey(true);
                                                break;

                                            case "export":
                                                Console.WriteLine("\nEnter file name (leave empty to cancel):");

                                                input1 = Console.ReadLine().Trim();

                                                if (input1 == null || input1.Length == 0)
                                                {
                                                    Console.WriteLine("Empty input.");

                                                    Console.WriteLine("\nPress any key to continue...");
                                                    Console.ReadKey(true);
                                                    break;
                                                }

                                                if (Path.GetInvalidFileNameChars().Any(c => input1.Contains(c)))
                                                {
                                                    Console.WriteLine("File name contains disallowed symbols.");

                                                    Console.WriteLine("\nPress any key to continue...");
                                                    Console.ReadKey(true);
                                                    break;
                                                }

                                                ExportTranslations(selectedDictionary, selectedWord, input1);

                                                Console.WriteLine($"Exported translations of {selectedWord} to {input1}.txt");

                                                Console.WriteLine("\nPress any key to continue...");
                                                Console.ReadKey(true);
                                                break;

                                            case "stop":
                                                insideWord = false;
                                                break;

                                            default:
                                                Console.WriteLine("Wrong input.");

                                                Console.WriteLine("\nPress any key to continue...");
                                                Console.ReadKey(true);
                                                break;
                                        }
                                    }
                                    break;

                                case "addword":
                                    Console.Clear();
                                    Console.WriteLine($"{selectedDictionary}/\n" +
                                        $"\nWords:\n");
                                    resultList = GetWords(selectedDictionary);
                                    foreach (var item in resultList)
                                    {
                                        Console.WriteLine(item);
                                    }
                                    Console.WriteLine("Enter word:");

                                    input1 = Console.ReadLine().ToLower();

                                    if (input1 == null || input1.Length == 0)
                                    {
                                        Console.WriteLine("Empty input.");

                                        Console.WriteLine("\nPress any key to continue...");
                                        Console.ReadKey(true);
                                        break;
                                    }

                                    input1 = input1.ToLower();

                                    Console.Clear();
                                    Console.WriteLine("\nEnter 1 or multiple (separate with \",\") translations:");

                                    input2 = Console.ReadLine();

                                    if (input1 == null || input1.Length == 0)
                                    {
                                        Console.WriteLine("Empty input.");

                                        Console.WriteLine("\nPress any key to continue...");
                                        Console.ReadKey(true);
                                        break;
                                    }

                                    AddWordToDictionary(selectedDictionary, input1, input2);

                                    if (input2.Contains(','))
                                    {
                                        string[] parts = input2.Split(',');
                                        foreach (var item in parts)
                                        {
                                            item.Trim();
                                        }
                                        Console.WriteLine($"Added word \"{input1}\" with {parts.Length} translations to {selectedDictionary} dictionary");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Added word \"{input1}\" with \"{input2}\" translation to {selectedDictionary} dictionary");
                                    }

                                    Console.WriteLine("\nPress any key to continue...");
                                    Console.ReadKey(true);
                                    break;

                                case "deleteword":
                                    Console.Clear();
                                    commandSelector = MakeListSelector(GetWords(selectedDictionary));

                                    if (commandSelector.Count == 0)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("No words in the dictionary, returning...");

                                        Console.WriteLine("\nPress any key to continue...");
                                        Console.ReadKey(true);
                                        break;
                                    }

                                    commandSelector.Add(0, "Cancel selection");
                                    foreach (var item in commandSelector)
                                    {
                                        Console.WriteLine($"{item.Key}. {item.Value}");
                                    }
                                    Console.WriteLine("\nSelect word:");

                                    command = TryParseCommand(commandSelector, Console.ReadLine());
                                    if (command == null || command.Length == 0)
                                    {
                                        Console.WriteLine("Wrong input.");

                                        Console.WriteLine("\nPress any key to continue...");
                                        Console.ReadKey(true);

                                        break;
                                    }

                                    if (command == commandSelector[0] || !commandSelector.ContainsValue(command)) break;

                                    DeleteWordFromDictionary(selectedDictionary, command);

                                    Console.Clear();
                                    Console.WriteLine($"{command} has been deleted from {selectedDictionary} dictionary");

                                    Console.WriteLine("\nPress any key to continue...");
                                    Console.ReadKey(true);
                                    break;

                                case "stop":
                                    insideDictionary = false;
                                    break;

                                default:
                                    Console.WriteLine("Wrong input.");

                                    Console.WriteLine("\nPress any key to continue...");
                                    Console.ReadKey(true);
                                    break;
                            }
                        }
                        break;

                    case "createdict":
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("Dictionaries:\n");
                            resultList = GetDictionaries(false);
                            foreach (var item in resultList)
                            {
                                Console.WriteLine(item);
                            }

                            Console.WriteLine("\nEnter new dictionary name (or leave empty to return):");
                            input1 = Console.ReadLine().Trim();

                            if (input1 == null || input1.Length == 0)
                            {
                                Console.WriteLine("Empty input.");

                                Console.WriteLine("\nPress any key to continue...");
                                Console.ReadKey(true);
                                break;
                            }

                            if (Path.GetInvalidFileNameChars().Any(c => input1.Contains(c)))
                            {
                                Console.WriteLine("File name contains disallowed symbols.");

                                Console.WriteLine("\nPress any key to continue...");
                                Console.ReadKey(true);
                                continue;
                            }

                            if (CreateWordDictionary(input1))
                            {

                                Console.WriteLine($"Created new dictionary at \"{input1} dictionary.txt\"");
                            }
                            else
                            {
                                Console.WriteLine($"Dictionary with this name already exists.");

                                Console.WriteLine("\nPress any key to continue...");
                                Console.ReadKey(true);
                                continue;
                            }

                            Console.WriteLine("\nPress any key to continue...");
                            Console.ReadKey(true);
                            break;
                        }
                        break;

                    case "deletedict":
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("Dictionaries:");
                            commandSelector = MakeListSelector(GetDictionaries(false));

                            if (commandSelector.Count == 0)
                            {
                                Console.Clear();
                                Console.WriteLine("No dictionaries, returning...");

                                Console.WriteLine("\nPress any key to continue...");
                                Console.ReadKey(true);
                                break;
                            }

                            commandSelector.Add(0, "Cancel selection");
                            foreach (var item in commandSelector)
                            {
                                Console.WriteLine($"{item.Key}. {item.Value}");
                            }
                            Console.WriteLine("\nSelect dictionary:");


                            command = TryParseCommand(commandSelector, Console.ReadLine());
                            if (command == null || command.Length == 0)
                            {
                                Console.WriteLine("Wrong input.");

                                Console.WriteLine("\nPress any key to continue...");
                                Console.ReadKey(true);

                                continue;
                            }
                            break;
                        }

                        if (command == commandSelector[0] || !commandSelector.ContainsValue(command)) break;

                        input1 = command;
                        commandSelector.Clear();
                        commandSelector.Add(1, "Yes");
                        commandSelector.Add(0, "No");

                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine($"Are you certain that you wish to delete \"{input1} dictionary.txt\"?\n");

                            foreach (var item in commandSelector)
                            {
                                Console.WriteLine($"{item.Key}. {item.Value}");
                            }

                            Console.WriteLine("Select option:");
                            command = TryParseCommand(commandSelector, Console.ReadLine());

                            if (command == commandSelector[0] || !commandSelector.ContainsValue(command)) break;
                            if (!commandSelector.ContainsValue(command))
                            {
                                Console.WriteLine("Wrong input");
                                continue;
                            }

                            DeleteWordDictionary(input1);

                            Console.Clear();
                            Console.WriteLine($"\"{input1} dictionary.txt\" has been deleted");

                            break;
                        }

                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey(true);
                        break;

                    case "stop":
                        Console.WriteLine("Stopping dictionary program.");
                        dictionaryOn = false;
                        break;

                    default:
                        Console.WriteLine("Wrong input.");

                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey(true);
                        break;
                }
            }
        }

        // METHODS
        //Word file task methods

        static public string[] GetWordFiles()
        {
            StreamReader sR = new StreamReader("firstFile.txt");
            List<string> files = new List<string>();
            while (!sR.EndOfStream)
            {
                files.Add(sR.ReadLine());
            }
            sR.Close();

            return files.ToArray();
        }

        static public Dictionary<string, int> AnalyzeWordFile(string file)
        {
            var sR = new StreamReader($"{file}.txt");
            var words = new Dictionary<string, int>();
            while (!sR.EndOfStream)
            {
                List<string> line = sR.ReadLine().Split([',', '.', ' ']).ToList<string>();
                for (int i = 0; i < line.Count;)
                {
                    if (!line[i].Any())
                    {
                        line.RemoveAt(i);
                    }
                    else
                    {
                        line[i].Trim();
                        i++;
                    }
                }
                while (line.Count > 0)
                {
                    if (words.ContainsKey(line[0]))
                    {
                        words[line[0]]++;
                    }
                    else
                    {
                        words.Add(line[0], 1);
                    }
                    line.RemoveAt(0);
                }
            }
            sR.Close();

            return words;
        }

        //Dictionary task methods

        /*
        static public void ReformatDictionaries() //Just making sure everything is lowercase etc.
        {
            List<string> dictionaries = GetDictionaries(true);

            foreach (var dict in dictionaries)
            {
                StreamReader sR = new StreamReader(dict); //Get dictionary into a variable to remove
                var lineList = new List<string>();

                while (!sR.EndOfStream)
                {
                    string[] parts = sR.ReadLine().ToLower().Split(',');
                    lineList.Add($"{parts[0].Trim()},{parts[1].Trim()}");
                }
                sR.Close();

                StreamWriter sW = new StreamWriter(dict); //Overwrite dictionary with new one, removing related word
                foreach (var line in lineList)
                {
                    sW.WriteLine(line);
                }
                sW.Close();
            }
        }
        */

        static public bool CreateWordDictionary(string name)
        {
            if (File.Exists($"{name} dictionary.txt"))
            {
                return false;
            }
            File.Create($"{name} dictionary.txt").Close();
            return true;
        }

        static public void DeleteWordDictionary(string name)
        {
            if (!File.Exists($"{name} dictionary.txt"))
            {
                return;
            }
            File.Delete($"{name} dictionary.txt");
        }

        static public List<string> GetDictionaries(bool addExtension)
        {
            string[] files = Directory.GetFiles(Environment.CurrentDirectory);
            List<string> fileList = files.ToList<string>();
            var result = new List<string>();

            for (int i = 0; i < fileList.Count;)
            {
                if (!fileList.ElementAt(i).Contains("dictionary.txt"))
                {
                    fileList.RemoveAt(i);
                }
                else i++;
            }

            foreach (var item in fileList)
            {
                if (addExtension == false)
                {
                    string[] parts = Path.GetFileNameWithoutExtension(item).Split(' ');
                    result.Add(parts[0]);
                }
                else
                {
                    result.Add(Path.GetFileName(item));
                }
            }

            return result;
        }

        // Method to get words from a dictionary (with overload in case we need words AND translations in one
        static public List<string> GetWords(string dictionary)
        {
            List<string> result = new List<string>();
            StreamReader sR = new StreamReader($"{dictionary} dictionary.txt");
            while (!sR.EndOfStream)
            {
                string[] parts = sR.ReadLine().Split(',');
                result.Add(parts[0]);
            }
            sR.Close();
            result = result.Distinct().ToList();
            return result;
        }
        static public List<string> GetWords(string dictionary, bool getTranslations)
        {
            List<string> result = new List<string>();
            StreamReader sR = new StreamReader($"{dictionary} dictionary.txt");
            while (!sR.EndOfStream)
            {
                string[] parts = sR.ReadLine().Split(',');
                if (getTranslations)
                {
                    string word = parts[0];
                    List<string> translations = GetWordTranslations(dictionary, parts[0]);
                    string line = $"{word}: ";

                    for (int i = 0, j = 1; i < translations.Count; i++, j++)
                    {
                        if (i == 0 || j == 1) line += $"{translations[i]}";
                        else
                            line += $", {translations[i]}";
                        if (j == 8)
                        {
                            line += $",\n";
                            j = 0;
                        }
                    }

                    result.Add(line);
                }
                else
                {
                    result.Add(parts[0]);
                }
            }
            sR.Close();
            result = result.Distinct().ToList();
            return result;
        }

        //Method to get translations of a word in a dictionary
        static public List<string> GetWordTranslations(string dictionary, string word)
        {
            List<string> result = new List<string>();
            StreamReader sR = new StreamReader($"{dictionary} dictionary.txt");
            while (!sR.EndOfStream)
            {
                string[] parts = sR.ReadLine().Split(',');
                if (!parts.Contains(word)) continue;
                result.Add(parts[1]);
            }
            sR.Close();
            return result;
        }

        //Method to add word and it's translations to a dictionary
        static public void AddWordToDictionary(string dictionary, string word, string translation)
        {
            List<string> translationList = GetWordTranslations(dictionary, word);
            StreamWriter sW = new StreamWriter($"{dictionary} dictionary.txt", true);
            if (translation.Contains(","))
            {
                List<string> translations = translation.Split(",").ToList();
                foreach (var item in translations)
                {
                    if (translationList.Contains(item) || item == null || item.Length == 0) continue;
                    sW.WriteLine($"{word.ToLower().Trim()},{item.ToLower().Trim()}");
                }
            }
            else
            {
                if (!translationList.Contains(translation))
                    sW.WriteLine($"{word.ToLower().Trim()},{translation.ToLower().Trim()}");
            }

            sW.Close();
        }

        static public void ChangeWordInDictionary(string dictionary, string word, string newWord)
        {
            StreamReader sR = new StreamReader($"{dictionary} dictionary.txt"); //Get dictionary into a variable to remove
            var lineList = new List<string>();

            newWord = newWord.ToLower().Trim();
            if (newWord.Contains(',')) newWord = newWord.Remove(',');

            while (!sR.EndOfStream)
            {
                string[] parts = sR.ReadLine().Split(',');
                if (parts[0].Equals(word))
                {
                    lineList.Add($"{newWord},{parts[1]}");
                }
                else
                    lineList.Add($"{parts[0]},{parts[1]}");
            }
            sR.Close();

            StreamWriter sW = new StreamWriter($"{dictionary} dictionary.txt"); //Overwrite dictionary with new one, removing related word
            foreach (var item in lineList)
            {
                sW.WriteLine(item);
            }
            sW.Close();
        }

        static public void ChangeTranslationInDictionary(string dictionary, string word, string translation, string newTranslation)
        {
            StreamReader sR = new StreamReader($"{dictionary} dictionary.txt"); //Get dictionary into a variable to remove
            var lineList = new List<string>();

            newTranslation = newTranslation.ToLower().Trim();
            if (newTranslation.Contains(',')) newTranslation = newTranslation.Remove(',');

            while (!sR.EndOfStream)
            {
                string[] parts = sR.ReadLine().Split(',');
                if (parts[0].Equals(word) && parts[1].Equals(translation))
                {
                    lineList.Add($"{parts[0]},{newTranslation}");
                }
                else
                    lineList.Add($"{parts[0]},{parts[1]}");
            }
            sR.Close();

            StreamWriter sW = new StreamWriter($"{dictionary} dictionary.txt"); //Overwrite dictionary with new one, removing related word
            foreach (var item in lineList)
            {
                sW.WriteLine(item);
            }
            sW.Close();
        }

        //Method to delete a word from a dictionary
        static public void DeleteWordFromDictionary(string dictionary, string word)
        {
            StreamReader sR = new StreamReader($"{dictionary} dictionary.txt"); //Get dictionary into a variable to remove
            var lineList = new List<string>();

            while (!sR.EndOfStream)
            {
                string[] parts = sR.ReadLine().Split(',');
                if (parts[0].Equals(word)) continue;
                lineList.Add($"{parts[0]},{parts[1]}");
            }
            sR.Close();

            StreamWriter sW = new StreamWriter($"{dictionary} dictionary.txt"); //Overwrite dictionary with new one, removing related word
            foreach (var item in lineList)
            {
                sW.WriteLine(item);
            }
            sW.Close();
        }

        //Method to delete a translation from a word from a dictionary
        static public void DeleteTranslationFromDictionary(string dictionary, string word, string translation)
        {
            StreamReader sR = new StreamReader($"{dictionary} dictionary.txt"); //Get dictionary into a variable to remove
            var lineList = new List<string>();

            while (!sR.EndOfStream)
            {
                string[] parts = sR.ReadLine().Split(',');
                if (parts[0].Equals(word) && parts[1].Equals(translation)) continue;
                lineList.Add($"{parts[0]},{parts[1]}");
            }
            sR.Close();

            StreamWriter sW = new StreamWriter($"{dictionary} dictionary.txt"); //Overwrite dictionary with new one, removing related word
            foreach (var item in lineList)
            {
                sW.WriteLine(item);
            }
            sW.Close();
        }

        //Method to export all translations of a word from a dictionary into a file.
        static public void ExportTranslations(string dictionary, string word, string fileName)
        {
            List<string> translations = GetWordTranslations(dictionary, word);

            StreamWriter sW = new StreamWriter($"{fileName}.txt");
            sW.WriteLine($"{word}\n");

            foreach (var item in translations)
            {
                sW.WriteLine(item);
            }

            sW.Close();
        }

        //Methods to simplify console command selection
        static public Dictionary<int, string> MakeListSelector(List<string> list)
        {
            var resultDict = new Dictionary<int, string>();
            for (int i = 0; i < list.Count; i++)
            {
                resultDict.Add(i + 1, list[i]);
            }
            return resultDict;
        }

        static public string SelectFromListSelector(Dictionary<int, string> dictionarySelector, int selection)
        {
            return dictionarySelector[selection];
        }
        /*
        if (int.TryParse(Console.ReadLine(), out commandInt))
            {
                if (commandSelector.ContainsKey(commandInt))
                    command = SelectFromListSelector(commandSelector, commandInt);
                else
                {
                        Console.WriteLine("Wrong input.");

                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey(true);
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Wrong input.");

                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey(true);
                    break;
                }
        */

        static public string TryParseCommand(Dictionary<int, string> dictionarySelector, string input)
        {
            int commandInt = 0;

            if (input == null || input.Length == 0 || input.Equals(String.Empty)) return null;

            if (int.TryParse(input, out commandInt))
            {
                if (dictionarySelector.ContainsKey(commandInt))
                    return SelectFromListSelector(dictionarySelector, commandInt);
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

    }
}
