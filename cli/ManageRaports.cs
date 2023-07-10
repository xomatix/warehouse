

namespace warehouse
{
    class ManageReports
    {
        Warehouse warehouse;
        public ManageReports(Warehouse w)
        {
            this.warehouse = w;
        }

        public void manage()
        {

            int selectedIndex = 0;

            string[] options = { "Get Warehouse Raport", "Get Specific Department Raport", "Exit" };

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Select an option:");

                for (int i = 0; i < options.Length; i++)
                {
                    if (i == selectedIndex)
                        Console.Write("=> ");
                    else
                        Console.Write("   ");
                    Console.WriteLine(options[i]);
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                ConsoleKey key = keyInfo.Key;

                if (key == ConsoleKey.UpArrow)
                {
                    selectedIndex = (selectedIndex - 1 + options.Length) % options.Length;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    selectedIndex = (selectedIndex + 1) % options.Length;
                }
                else if (key == ConsoleKey.Enter)
                {
                    if (selectedIndex == options.Length - 1)
                    {
                        Console.WriteLine("Exiting...");
                        break;
                    }
                    else if (selectedIndex == 0)
                    {
                        Console.Clear();
                        warehouse.DisplayDepartments();
                        Console.WriteLine("Press enter to go back");
                        Console.ReadLine();
                        break;
                    }
                    else
                    {
                        Department dep = selectDepartment();
                        Console.Clear();
                        dep.DisplayItems();
                        Console.WriteLine("Press enter to go back");
                        Console.ReadLine();
                        break;
                    }
                }
            }
        }

        public Department selectDepartment()
        {

            int selectedIndex = 0;

            List<Department> deps = warehouse.GetDepartments();

            List<string> options = new List<string>();
            int ind = 0;
            foreach (var item in deps)
            {
                options.Add(++ind + " | "  + item.name + " | "  + item.size + "/" + item.maxSize);
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Select Department:");

                for (int i = 0; i < options.Count(); i++)
                {
                    if (i == selectedIndex)
                        Console.Write("=> ");
                    else
                        Console.Write("   ");
                    Console.WriteLine(options.ElementAt(i));
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                ConsoleKey key = keyInfo.Key;

                if (key == ConsoleKey.UpArrow)
                {
                    selectedIndex = (selectedIndex - 1 + options.Count) % options.Count;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    selectedIndex = (selectedIndex + 1) % options.Count;
                }
                else if (key == ConsoleKey.Enter)
                {
                    return deps.ElementAt(selectedIndex);
                }
            }
        }



    }
}