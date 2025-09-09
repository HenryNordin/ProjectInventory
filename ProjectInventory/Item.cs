using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInventory
{
    // Represents an inventory item with a name and description
    class Item
    {
        private string name;
        private string description;

        // Default constructor
        public Item() { }

        // Constructor with parameters
        public Item(string name, string description)
        {
            this.name = name;
            this.description = description;
        }

        // Property for item name
        public string Name { 
            get { return name; } 
            set { name = value; }
        }

        // Property for item description
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        // Returns the item name when displayed
        public override string ToString()
        {
            return name;
        }
    }
}
