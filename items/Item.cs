using System;
using System.Collections.Generic;

namespace warehouse
{

    class Item
    {
        public string name;
        public int size;

        public Item(int size, string name)
        {
            this.size = size;
            this.name = name;
        }

        public void DisplayItem()
        {
            Console.WriteLine("Items in the Item:");
            Console.WriteLine(this.name);
        }
    }
}