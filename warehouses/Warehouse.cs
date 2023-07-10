using System;
using System.Collections.Generic;

namespace warehouse
{

    class Warehouse
    {
        private List<Department> items;

        public Warehouse()
        {
            items = new List<Department>();
        }
        // TODO: add remove display all with sizes b
        public void AddDepartment(Department item)
        {
            items.Add(item);
            Console.WriteLine("Department added successfully.");
        }

        public void RemoveDepartment(Department item)
        {
            if (items.Contains(item))
            {
                items.Remove(item);
                Console.WriteLine("Department removed successfully.");
            }
            else
            {
                Console.WriteLine("Department not found in the department.");
            }
        }

        public void DisplayDepartments()
        {
            Console.WriteLine("Departments in the warehouse:");
            int i  = 0;
            foreach (Department item in items)
            {
                Console.WriteLine(++i + " | " + item.name + " | " 
                + item.size + "/" + item.maxSize );
            }
        }

        public string FindItem(string name){
            string ans = "";
            int i = 0;
            foreach (Department dep in items)
            {
                foreach (Item item in dep.items)
                {
                    if (item.name == name)
                    {
                        ans += ++i + " | "  + dep.name + " | "  + item.name 
                        + " | "  + item.size + "\n";
                    }
                }
            }
            if(ans == "")
                ans = "No items found";

            return ans;
        }

        public List<Department> GetDepartments() {
            return items;
        }
    }
}