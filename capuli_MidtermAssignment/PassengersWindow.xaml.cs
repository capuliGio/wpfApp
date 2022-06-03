using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for PassengersWindow.xaml
    /// </summary>
    public partial class PassengersWindow : Window
    {
        public static List<Passenger> passenger = new List<Passenger>();
        public PassengersWindow()
        {
            InitializeComponent();

            //LINQ for initial appearance of items in the listbox
            var names = from passenger in passenger
                        select passenger.ID;

            lstPassenger.DataContext = names;
        }

        private void lstPassenger_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int i = lstPassenger.SelectedIndex;

            //LINQ for puting items fields onto the textboxes from the listbox
            var selectedPassenger = from passenger in passenger
                                 where passenger.ID == i
                                 select passenger;

            foreach (var s in selectedPassenger)
            {
                tbCustID.Text = s.CustomerID.ToString();
                tbFlightID.Text = s.FlightID.ToString();
            }

            var custID = from people in CustomerWindow.people
                            join passenger in passenger on people.ID equals passenger.CustomerID
                            where passenger.ID == i
                            orderby people.Name
                            select new
                            {
                                people.ID,
                                people.Name,
                                people.Address,
                                people.Email,
                                people.Phone

                            };

            var flightID = from flights in FlightsWindow.flights
                           join passenger in passenger on flights.ID equals passenger.FlightID
                           where passenger.ID == i
                           orderby flights.DepartureCity
                           select new
                           {
                               flights.ID,
                               flights.AirlineID,
                               flights.DepartureCity,
                               flights.DestinationCity,
                               flights.DepartureDate,
                               flights.FlightTime
                           };

            lstCustomerPass.DataContext = custID;
            lstFlightPass.DataContext = flightID;
        }

        private void addPassenger()
        {
            //if-else condition for superuser function limits
            if (LoginWindow.superUser == 1)
            {
                //if-else condition if a user did not input anything in the textboxes
                if (tbCustID.Text == "" || tbFlightID.Text == "")
                {
                    MessageBox.Show("No text box can be empty", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    //if-else condition to check incorrect input
                    if (IsTextAllowed(tbCustID.Text) && IsTextAllowed(tbFlightID.Text))
                    {
                        //Two LINQ in getting customer and flight information respectively using custID and flightID
                        var custID = from people in CustomerWindow.people
                                     join passenger in passenger on people.ID equals passenger.CustomerID
                                     where people.ID == int.Parse(tbCustID.Text) 
                                     orderby people.Name
                                     select new
                                     {
                                         people.ID,
                                         people.Name,
                                         people.Address,
                                         people.Email,
                                         people.Phone

                                     };

                        var flightID = from flights in FlightsWindow.flights
                                     join passenger in passenger on flights.ID equals passenger.FlightID
                                     where flights.ID == int.Parse(tbFlightID.Text)
                                     orderby flights.DepartureCity
                                     select new
                                     {
                                         flights.ID,
                                         flights.AirlineID,
                                         flights.DepartureCity,
                                         flights.DestinationCity,
                                         flights.DepartureDate,
                                         flights.FlightTime
                                     };

                        //if-else condition to know if the inputted key is existing
                        if (!custID.Any())
                        {
                            MessageBox.Show("Incorrect input! CustomerID does not exist.", "Error",
                                            MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else if (!flightID.Any())
                        {
                            MessageBox.Show("Incorrect input! FlightID does not exist.", "Error",
                                            MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else
                        {
                            lstCustomerPass.DataContext = custID.Distinct();
                            lstFlightPass.DataContext = flightID.Distinct();

                            passenger.Add(new Passenger(passenger.Count, int.Parse(tbCustID.Text),
                                                           int.Parse(tbFlightID.Text)));

                            var names = from passenger in passenger
                                        select passenger.ID;

                            lstPassenger.DataContext = names;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Incorrect input! Please enter a number in the CustomerID or FlightID.", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("You are attempting to perform a restricted operation! User has only a SuperUser value of 0.", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void updatePassenger()
        {
            //if-else condition for superuser function limits
            if (LoginWindow.superUser == 1)
            {
                //if-else condition if a user did not input anything in the textboxes
                if (tbCustID.Text == "" || tbFlightID.Text == "")
                {
                    MessageBox.Show("No text box can be empty", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    //if-else condition to check incorrect input
                    if (IsTextAllowed(tbCustID.Text) && IsTextAllowed(tbFlightID.Text))
                    {
                        //Two LINQ in getting customer and flight information respectively using custID and flightID
                        var custID = from people in CustomerWindow.people
                                     join passenger in passenger on people.ID equals passenger.CustomerID
                                     where people.ID == int.Parse(tbCustID.Text)
                                     orderby people.Name
                                     select new
                                     {
                                         people.ID,
                                         people.Name,
                                         people.Address,
                                         people.Email,
                                         people.Phone

                                     };

                        var flightID = from flights in FlightsWindow.flights
                                       join passenger in passenger on flights.ID equals passenger.FlightID
                                       where flights.ID == int.Parse(tbFlightID.Text)
                                       orderby flights.DepartureCity
                                       select new
                                       {
                                           flights.ID,
                                           flights.AirlineID,
                                           flights.DepartureCity,
                                           flights.DestinationCity,
                                           flights.DepartureDate,
                                           flights.FlightTime
                                       };

                        //if-else condition to know if the inputted key is existing
                        if (!custID.Any())
                        {
                            MessageBox.Show("Incorrect input! CustomerID does not exist.", "Error",
                                            MessageBoxButton.OK, MessageBoxImage.Error);
                        }else if (!flightID.Any())
                        {
                            MessageBox.Show("Incorrect input! FlightID does not exist.", "Error",
                                            MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else
                        {
                            lstCustomerPass.DataContext = custID.Distinct();
                            lstFlightPass.DataContext = flightID.Distinct();

                            Passenger c = new Passenger(lstPassenger.SelectedIndex, int.Parse(tbCustID.Text),
                                                           int.Parse(tbFlightID.Text));

                            passenger[lstPassenger.SelectedIndex] = c;

                            var names = from passenger in passenger
                                        select passenger.ID;

                            lstPassenger.DataContext = names;

                            MessageBox.Show("Successfully updated!", "Information",
                                MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Incorrect input! Please enter a number in the CustomerID or FlightID.", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("You are attempting to perform a restricted operation! User has only a SuperUser value of 0.", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void deletePassenger()
        {
            //if-else condition for superuser function limits
            if (LoginWindow.superUser == 1)
            {
                //if-else condition if a user did not input anything in the textboxes or if user did not select anything from the listbox
                if (tbCustID.Text == "" || tbFlightID.Text == "" || lstPassenger.SelectedIndex == -1)
                {
                    MessageBox.Show("No passenger ID was selected! Please click a passenger ID to delete.", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    passenger.RemoveAt(lstPassenger.SelectedIndex);

                    // reorder ID's - not good practise but needed to avoid breaking this app
                    for (int i = 0; i < passenger.Count; i++)
                        passenger[i].ID = i;

                    var names = from passenger in passenger
                                select passenger.ID;

                    lstPassenger.DataContext = names;
                    tbCustID.Clear();
                    tbFlightID.Clear();
                    lstCustomerPass.DataContext = null;
                    lstFlightPass.DataContext = null;

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

        private void btnDelete_Click(object sender, RoutedEventArgs e) //button click event handler for deleting an item
        {
            if (MessageBox.Show("Do you want to delete this item?", "Close Application", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                deletePassenger();
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e) //button click event handler for updating an item
        {
            if (MessageBox.Show("Do you want to update this item?", "Close Application", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                updatePassenger();
            }
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e) //button click event handler for adding an item
        {
            addPassenger();
        }

        private void menuDelete_Click(object sender, RoutedEventArgs e) //menu click event handler for deleting an item
        {
            if (MessageBox.Show("Do you want to delete this item?", "Close Application", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                deletePassenger();
            }
        }

        private void menuUpdate_Click(object sender, RoutedEventArgs e) //menu click event handler for updating an item
        {
            if (MessageBox.Show("Do you want to update this item?", "Close Application", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                updatePassenger();
            }
        }

        private void menuInsert_Click(object sender, RoutedEventArgs e) //menu click event handler for adding an item
        {
            addPassenger();
        }

        private void menuHelp_Click(object sender, RoutedEventArgs e) //menu click event handler for opening the about page
        {
            AboutPage a = new AboutPage();
            a.ShowDialog();
        }

        private void menuQuit_Click(object sender, RoutedEventArgs e) //menu click event handler for closing this page
        {
            this.Close();
        }

        private void mnuWinInsert_Click(object sender, RoutedEventArgs e) //context menu click event handler for adding an item
        {
            addPassenger();
        }

        private void mnuWinUpdate_Click(object sender, RoutedEventArgs e) //context menu click event handler for updating an item
        {
            if (MessageBox.Show("Do you want to update this item?", "Close Application", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                updatePassenger();
            }
        }

        private void mnuWinDelete_Click(object sender, RoutedEventArgs e) //context menu click event handler for deleting an item
        {
            if (MessageBox.Show("Do you want to delete this item?", "Close Application", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                deletePassenger();
            }
        }

        private void mnuWinClose_Click(object sender, RoutedEventArgs e) //context menu click event handler for closing this page
        {
            this.Close();
        }

        private void passengerPage_Closing(object sender, System.ComponentModel.CancelEventArgs e) //message box for closing confirmation
        {
            if (MessageBox.Show("This will close down the Passenger page. Confirm?", "Close Application", MessageBoxButton.YesNo) == MessageBoxResult.No)
            {
                e.Cancel = true;
                this.Activate();
            }
        }

        private static readonly Regex _regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }
    }
}
