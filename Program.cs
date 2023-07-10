using System;
using warehouse;

class Program
{
    static void Main()
    {
        Console.Clear();
        Console.WriteLine("Tests!");

        Warehouse warehouse = new Warehouse();
        Department department = new Department(5, "small department");
        Department department2 = new Department(100, "big department");


        warehouse.AddDepartment(department);
        warehouse.AddDepartment(department2);

        Item item1 = new Item(2, "Box small");
        Item item2 = new Item(7, "Box big");
        Item item3 = new Item(10, "TV");

        department.AddItem(item1);
        department.AddItem(item2);

        department2.AddItem(item2);
        department2.AddItem(item3);

        warehouse.DisplayDepartments();

        department2.DisplayItems();
//działa co ma
        Console.ReadLine();

        int selectedIndex = 0;
        string[] options = { "Manage Items", "Manage Departments", "Raport", "Exit" };

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
                else if(selectedIndex==0){
                    ManageItems m = new ManageItems(warehouse);
                    m.manage();
                }
                else if(selectedIndex==1){
                    ManageDepartments m = new ManageDepartments(warehouse);
                    m.manage();
                }
                else
                {
                    ManageReports m = new ManageReports(warehouse);
                    m.manage();
                }
            }
        }
    }
}