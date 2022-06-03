using System;
using System.Collections;
using System.Collections.Generic;
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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public static Dictionary<string, Logins> myDictionary = new Dictionary<string, Logins>();
        public static int superUser;

        public LoginWindow()
        {
            InitializeComponent();

            //Adding users into the dictionary collection
            myDictionary.Add("Gio Capuli", new Logins(0, "Gio Capuli", "Admin", 1));
            myDictionary.Add("Abdullah Abdullah", new Logins(1, "Abdullah Abdullah", "Employee1", 0));
            myDictionary.Add("Lucas Carvalho", new Logins(2, "Lucas Carvalho", "Employee2", 0));
            myDictionary.Add("Ian Capuli", new Logins(3, "Ian Capuli", "Employee3", 0));
            myDictionary.Add("Coline Capuli", new Logins(3, "Ian Capuli", "Employee4", 0));

            //Adding preloaded data to all classes
            HomePage.addCustomer();
            HomePage.addAirlines();
            HomePage.addFlights();
            HomePage.addPassenger();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            //Getting the fields value using username as key
            myDictionary.TryGetValue(tbUser.Text, out Logins value);

            //if-else condition for login security
            if ((myDictionary.ContainsKey(tbUser.Text)) && (value.Password == pbPass.Password))
            {
                superUser = value.SuperUser;
                HomePage h = new HomePage();
                h.ShowDialog();
            }
            else
            {
                MessageBox.Show("Incorrect Username or Password", "Login Failed",
                                MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e) //button click event handler for closing this page
        {
            this.Close();
        }

        private void loginPage_Closing(object sender, System.ComponentModel.CancelEventArgs e) //message box for closing confirmation

        {
            if (MessageBox.Show("This will close down the Login page. Confirm?", "Close Application", MessageBoxButton.YesNo) == MessageBoxResult.No)
            {
                e.Cancel = true;
                this.Activate();
            }
        }
    }
}
