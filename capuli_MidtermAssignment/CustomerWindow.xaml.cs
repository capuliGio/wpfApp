using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace capuli_MidtermAssignment
{
    /// <summary>
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        public static List<Customer> people = new List<Customer>();
        public CustomerWindow()
        {
            InitializeComponent();

            //LINQ for initial appearance of items in the listbox
            var names = from peo in people
                        select peo.Name;

            lstCustomer.DataContext = names;
        }

        private void InsertCustomer()
        {
            //if-else condition for superuser function limits
            if (LoginWindow.superUser == 1)
            {
                //if-else condition if a user did not input anything in the textboxes
                if (tbName.Text == "" || tbAddress.Text == "" ||
                tbEmail.Text == "" || tbPhone.Text == "")
                {
                    MessageBox.Show("No text box can be empty", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    people.Add(new Customer(people.Count, tbName.Text,
                                tbAddress.Text, tbEmail.Text,
                                tbPhone.Text));

                    var names = from peo in people
                                select peo.Name;

                    lstCustomer.DataContext = names;
                }
            }
            else
            {
                MessageBox.Show("You are attempting to perform a restricted operation! User has only a SuperUser value of 0.", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void UpdateCustomer()
        {
            //if-else condition for superuser function limits
            if (LoginWindow.superUser == 1)
            {
                //if-else condition if a user did not input anything in the textboxes
                if (tbName.Text == "" || tbAddress.Text == "" ||
                tbEmail.Text == "" || tbPhone.Text == "")
                {
                    MessageBox.Show("No customer was selected! Please click a customer to update.", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    Customer c = new Customer(lstCustomer.SelectedIndex, tbName.Text,
                    tbAddress.Text, tbEmail.Text, tbPhone.Text);

                    people[lstCustomer.SelectedIndex] = c;

                    var names = from peo in people
                                select peo.Name;

                    lstCustomer.DataContext = names;

                    MessageBox.Show("Successfully updated!", "Information",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("You are attempting to perform a restricted operation! User has only a SuperUser value of 0.", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteCustomer()
        {
            //if-else condition for superuser function limits
            if (LoginWindow.superUser == 1)
            {
                //if-else condition if a user did not input anything in the textboxes or if the user did not select anything from the listbox
                if (tbName.Text == "" || tbAddress.Text == "" ||
                tbEmail.Text == "" || tbPhone.Text == "" || lstCustomer.SelectedIndex == -1)
                {
                    MessageBox.Show("No customer was selected! Please click a customer to delete.", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    people.RemoveAt(lstCustomer.SelectedIndex);

                    // reorder ID's - not good practise but needed to avoid breaking this app
                    for (int i = 0; i < people.Count; i++)
                        people[i].ID = i;

                    var names = from peo in people
                                select peo.Name;

                    lstCustomer.DataContext = names;
                    tbName.Clear();
                    tbAddress.Clear();
                    tbEmail.Clear();
                    tbPhone.Clear();

                    MessageBox.Show("Successfully deleted!", "Information",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }
            else
            {
                MessageBox.Show("You are attempting to perform a restricted operation! User has only a SuperUser value of 0.", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void lstCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int i = lstCustomer.SelectedIndex;

            //LINQ for puting items fields onto the textboxes from the listbox
            var selectedCustomer = from peo in people
                               where peo.ID == i
                               select peo;

            foreach (var s in selectedCustomer)
            {
                tbName.Text = s.Name;
                tbAddress.Text = s.Address;
                tbEmail.Text = s.Email;
                tbPhone.Text = s.Phone;
            }

        }

        private void btnInsert_Click(object sender, RoutedEventArgs e) //button click event handler for adding an item
        {
            InsertCustomer();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e) //button click event handler for updating an item
        {
            //Message box confirmation to update an item
            if (MessageBox.Show("Do you want to update this item?", "Close Application", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                UpdateCustomer();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e) //button click event handler for deleting an item
        {
            //Message box confirmation to delete an item
            if (MessageBox.Show("Do you want to delete this item?", "Close Application", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                DeleteCustomer();
            }

        }

        private void customerPage_Closing(object sender, System.ComponentModel.CancelEventArgs e) //message box for closing confirmation
        {
            if (MessageBox.Show("This will close down the Customer page. Confirm?", "Close Application", MessageBoxButton.YesNo) == MessageBoxResult.No)
            {
                e.Cancel = true;
                this.Activate();
            }
        }

        private void mnuWinInsert_Click(object sender, RoutedEventArgs e) //context menu event handler for adding an item
        {
            InsertCustomer();
        }

        private void mnuWinUpdate_Click(object sender, RoutedEventArgs e) //context menu event handler for updating an item
        {
            if (MessageBox.Show("Do you want to update this item?", "Close Application", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                UpdateCustomer();
            }
        }

        private void mnuWinDelete_Click(object sender, RoutedEventArgs e) //context menu event handler for deleting an item
        {
            if (MessageBox.Show("Do you want to delete this item?", "Close Application", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                DeleteCustomer();
            }
        }

        private void mnuWinClose_Click(object sender, RoutedEventArgs e) //context menu event handler for closing this page
        {
            this.Close();
        }

        private void menuInsert_Click(object sender, RoutedEventArgs e) //menu event handler for adding an item
        {
            InsertCustomer();
        }

        private void menuUpdate_Click(object sender, RoutedEventArgs e) //menu event handler for updating an item
        {
            if (MessageBox.Show("Do you want to update this item?", "Close Application", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                UpdateCustomer();
            }
        }

        private void menuDelete_Click(object sender, RoutedEventArgs e) //menu event handler for deleting an item
        {
            if (MessageBox.Show("Do you want to delete this item?", "Close Application", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                DeleteCustomer();
            }
        }

        private void menuHelp_Click(object sender, RoutedEventArgs e) //menu event handler for opening the about page
        {
            AboutPage a = new AboutPage();
            a.ShowDialog();
        }

        private void menuQuit_Click(object sender, RoutedEventArgs e) //menu event handler for closing this page
        {
            this.Close();
        }
    }
}
