using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace ProjectInventory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ItemManager itemManager = new ItemManager();
        public MainWindow()
        {
            InitializeComponent();
            InitializeGUI();
        }

        // Sets the initial state of the GUI
        private void InitializeGUI()
        {
            txtName.Text = string.Empty;
            txtDescription.Text = string.Empty;
        }

        // Reads user input and creates an Item
        private Item ReadInput()
        {
            return new Item(txtName.Text, txtDescription.Text);
        }

        // Refreshes the ListBox with all items
        private void UpdateGUI()
        {
            lstItems.Items.Clear();
            foreach (Item item in itemManager.GetItems())
            {
                lstItems.Items.Add(item);
            }
        }

        // Adds a new item if name is not empty
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Item newItem = ReadInput();
            if (!(txtName.Text == string.Empty))
            {
                itemManager.Add(newItem);
                lstItems.Items.Add(newItem);
                UpdateGUI();
            }
            else
                MessageBox.Show("Please provide a name for the item before you add it!", "Error");
        }

        // Displays details of the selected item in the info box
        private void ShowItemDetails(Item item)
        {
            TxtBoxInfo.Clear();

            string output = "";
            output += $"Item: {item.Name}\n\n";
            output += $"Description: \n{item.Description}\n";

            TxtBoxInfo.Text = output;
        }

        // Handles selection change in the ListBox
        private void lstItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedIndex = lstItems.SelectedIndex;

            // If a valid Item is selected it calls ShowItemDetails and sends the 
            // item corresponding to the index
            if (selectedIndex >= 0 && itemManager.CheckIndex(selectedIndex))
            {
                Item selectedItem = itemManager.GetItem(selectedIndex);
                ShowItemDetails(selectedItem);
            }
            // Clears the TextBox if nothing selected
            else
            {
                TxtBoxInfo.Clear();
            }
        }

        // Deletes selected item from list and data
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int index = lstItems.SelectedIndex;

            if (index >= 0)
            {
                itemManager.DeleteItem(index);
                lstItems.Items.RemoveAt(index);
                UpdateGUI();
            }
            else
            {
                MessageBox.Show("Please select a Item from the list before you press the \"Delete\" button!");
            }
        }

        // Opens the save file dialog and saves data to a file
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string errMessage = "Something went wrong while trying to save data!";

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt";
            saveFileDialog.Title = "Save data File";
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.AddExtension = true;

            bool? result = saveFileDialog.ShowDialog();

            if (result == true)
            {
                string fileName = saveFileDialog.FileName;

                bool ok = itemManager.WriteDataToFile(fileName); // call on instance
                if (!ok)
                {
                    MessageBox.Show(errMessage);
                }
                else
                {
                    MessageBox.Show("Data saved to file:" + Environment.NewLine + fileName);
                }
            }
        }


        // Opens the open file dialog and loads data from a file
        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            string errMessage = "Something went wrong when opening the file";

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt";
            openFileDialog.Title = "Open data File";

            bool? result = openFileDialog.ShowDialog();
            if (result == true)
            {
                string fileName = openFileDialog.FileName;

                bool ok = itemManager.ReadDataFromFile(fileName);
                if (!ok)
                    MessageBox.Show(errMessage);
                else
                    UpdateGUI();
            }
        }
    }
}
