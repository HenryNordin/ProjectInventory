using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System;

namespace ProjectInventory
{
    // Manages reading and writing data to files
    class FileManager
    {
        // Constants for file version validation
        private const string fileVersionToken = "WIP";
        private const double fileVersionNr = 0;

        // Reads the item list from a file
        public bool ReadItemListFromFile(List<Item> itemList, string fileName)
        {
            bool ok = true;
            StreamReader reader = null;

            try
            {
                // Clear existing list or initialize if null
                if (itemList != null)
                {
                    itemList.Clear();
                }
                else
                    itemList = new List<Item>();

                reader = new StreamReader(fileName); // Reads the file

                // Reads then verifies the file based of the version
                string versionTest = reader.ReadLine();
                double version = double.Parse(reader.ReadLine());
                if ((versionTest == fileVersionToken) && (version == fileVersionNr))
                {
                    int count = int.Parse(reader.ReadLine());
                    for (int i = 0; i < count; i++)
                    {
                        // Creates Item
                        Item item = new Item();

                        // Reads and assigns Item data
                        item.Name = reader.ReadLine();
                        item.Description = reader.ReadLine();

                        itemList.Add(item);
                    }
                }
                else
                    ok = false; // File version missmatch
            }
            catch
            {
                ok = false; // Fail to read file
            }
            finally
            {
                if (reader != null)
                    reader.Close(); // Always close the file
            }
            return ok;
        }

        // Saves the item list to a file
        public bool SaveItemListToFile(List<Item> itemList, string fileName)
        {
            bool ok = true;
            StreamWriter writer = null;
            try
            {
                // Open file for writing
                writer = new StreamWriter(fileName);
                // Write file header and task count
                writer.WriteLine(fileVersionToken);
                writer.WriteLine(fileVersionNr);
                writer.WriteLine(itemList.Count);

                // Write each task to the file
                for (int i = 0; i < itemList.Count; i++)
                {
                    writer.WriteLine(itemList[i].Name);
                    writer.WriteLine(itemList[i].Description);
                }
            }
            catch
            {
                ok = false; // Error while writing
            }
            finally
            {
                if (writer != null)
                    writer.Close(); // Always close the file
            }
            return ok;
        }
    }
}