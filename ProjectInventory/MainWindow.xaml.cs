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

        private void InitializeGUI()
        {
            txtName.Text = string.Empty;
            txtDescription.Text = string.Empty;
        }
        private Item ReadInput()
        {
            return new Item(txtName.Text, txtDescription.Text);
        }

        private void ClearBoxesAndLists()
        {
            throw new NotImplementedException();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateGUI();
        }

        private void UpdateGUI()
        {
            lstItems.Items.Clear();
            foreach (Item item in itemManager.GetItems())
            {
                lstItems.Items.Add(item);
            }
        }

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
    }
}
