using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectInventory
{
    class ItemManager
    {
        private List<Item> itemList;
        public ItemManager() { 
            itemList = new List<Item>();
        }

        public List<Item> GetItems()
        {
            return itemList;
        }

        public int Count
        {
            get { return itemList.Count; }
        }

        internal void Add(Item newItem)
        {
            itemList.Add(newItem);
        }

        //public string[] ListToStringArray() // Converts all tasks into a string array - for display
        //{
        //    string[] taskArray = new string[Count];
        //    for (int i = 0; i < Count; i++)
        //        taskArray[i] = itemList[i].ToString();

        //    return taskArray;
        //}
    }
}
