using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectInventory
{
    // Manages a collection of Item objects
    class ItemManager
    {
        private List<Item> itemList;

        // Initializes the item list
        public ItemManager() { 
            itemList = new List<Item>();
        }

        // Returns all items
        public List<Item> GetItems()
        {
            return itemList;
        }

        // Returns number of items
        public int Count
        {
            get { return itemList.Count; }
        }

        // Adds a new item to the list
        internal void Add(Item newItem)
        {
            itemList.Add(newItem);
        }

        // Checks if the given index is valid
        public bool CheckIndex(int index)
        {
            bool okIndex = false;
            if ((index >= 0) && index <= Count)
                okIndex = true;
            return okIndex;
        }

        // Returns an item at the given index
        public Item GetItem(int selectedIndex)
        {
            return itemList[selectedIndex];
        }

        // Deletes an item at the given index (if valid)
        public bool DeleteItem(int index)
        {
            bool delete = true;
            if (CheckIndex(index))
                itemList.RemoveAt(index);
            else
                delete = false;
            return delete;
        }
    }
}
