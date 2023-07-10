using System;
using System.Collections.Generic;

namespace warehouse
{

    class Department
    {
        public List<Item> items;
        public int maxSize;
        public int size;
        public string name;

        public Department(int maxSize, string name)
        {
            this.maxSize = maxSize;
            items = new List<Item>();
            this.name = name;
            size = 0;
        }

        ~Department()
        {
            items.Clear();
        }

        public void AddItem(Item item)
        {
            if (item.size >= maxSize)
            {
                Console.WriteLine("Item too big.");
            }
            else if (item.size + this.size <= maxSize)
            {
                size += item.size;
                items.Add(item);
                Console.WriteLine("Item added successfully.");
            }
            else
            {
                Console.WriteLine("Department is already full. Cannot add more items.");
            }
        }

        public void RemoveItem(Item item)
        {
            if (items.Contains(item))
            {
                size -= item.size;
                items.Remove(item);
                Console.WriteLine("Item removed successfully.");
            }
            else
            {
                Console.WriteLine("Item not found in the department.");
            }
        }

        public void DisplayItems()
        {
            Console.WriteLine("Items in the department:");
            int i = 0;
            foreach (Item item in items)
            {
                Console.WriteLine(++i + " | "  + item.name + " | "  + item.size);

            }
        }
    }
}