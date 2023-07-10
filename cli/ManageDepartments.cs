

namespace warehouse
{
    class ManageDepartments
    {
        Warehouse warehouseDeps;
        public ManageDepartments(Warehouse w)
        {
            this.warehouseDeps = w;
        }

        public void manage()
        {

            int selectedIndex = 0;

            string[] options = { "Add Department", "Delete Department", "Delete Item from Department", "Exit" };

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
                        Console.WriteLine("Enter name of department to add: ");
                        string? s = Console.ReadLine();
                        if (s == null)
                            s = "";
                        Console.WriteLine("Enter size of department to add: ");
                        string? si = Console.ReadLine();
                        if (si == null)
                            si = "0";
                        int size = int.Parse( si);
                        
                        Console.Clear();
                        Department dep = new Department(size, s);

                        warehouseDeps.AddDepartment(dep);
                        Console.WriteLine("Press enter to go back");
                        Console.ReadLine();
                        break;
                    }
                    else if (selectedIndex == 1)
                    {                        
                        Console.Clear();
                        Department dep = selectDepartment();

                        warehouseDeps.RemoveDepartment(dep);
                        Console.WriteLine("Press enter to go back");
                        Console.ReadLine();
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Department dep = selectDepartment();
                        Item it = selectItems(dep);
                        dep.RemoveItem(it);
                        
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

            List<Department> deps = warehouseDeps.GetDepartments();

            List<string> options = new List<string>();
            int ind = 0;
            foreach (var item in deps)
            {
                options.Add(++ind + " | " + item.name + " | "  + item.size + "/" + item.maxSize);
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

        public Item selectItems(Department dep)
        {

            int selectedIndex = 0;

            List<Item> deps = dep.items;

            List<string> options = new List<string>();
            int ind = 0;
            foreach (var item in deps)
            {
                options.Add(++ind + " | "  + item.name + " | "  + item.size );
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Select Item:");

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