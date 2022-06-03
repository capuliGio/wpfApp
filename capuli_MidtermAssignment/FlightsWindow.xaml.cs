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
    /// Interaction logic for FlightsWindow.xaml
    /// </summary>
    public partial class FlightsWindow : Window
    {
        public static List<Flights> flights = new List<Flights>();

        public FlightsWindow()
        {
            InitializeComponent();

            //LINQ for initial appearance of items in the listbox
            var names = from flights in flights
                        select flights.DestinationCity;

            lstFlights.DataContext = names;
        }

        private void lstFlights_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int i = lstFlights.SelectedIndex;

            //LINQ for puting items fields onto the textboxes from the listbox
            var selectedFlight = from flights in flights
                                 where flights.ID == i
                                 select flights;

            foreach (var s in selectedFlight)
            {
                tbAirlineID.Text = s.AirlineID.ToString();
                tbDeparture.Text = s.DepartureCity;
                tbDestination.Text = s.DestinationCity;
                tbTime.Text = s.FlightTime.ToString();
                tbDate.Text = s.DepartureDate;
            }

            var airlineID = from airlines in AirlinesWindow.airlines
                            join flights in flights on airlines.ID equals flights.AirlineID
                            where flights.ID == i
                            orderby flights.DepartureDate
                            select new
                            {
                                airlines.ID,
                                airlines.Airplane,
                                airlines.Name,
                                airlines.SeatsAvailable,
                                airlines.MealAvailable
                            };

            lstairlineID.DataContext = airlineID;
        }

        private void addFlights()
        {
            //if-else condition for superuser function limits
            if (LoginWindow.superUser == 1)
            {
                //if-else condition if a user did not input anything in the textboxes
                if (tbDeparture.Text == "" || tbDestination.Text == "" ||
                tbDate.Text == "" || tbTime.Text == "" || tbAirlineID.Text == "")
                {
                    MessageBox.Show("No text box can be empty", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    //if-else condition to check incorrect input
                    if (IsTextAllowed(tbTime.Text) && IsTextAllowed(tbAirlineID.Text))
                    {
                        //LINQ for getting the airline information using airlineID as foreign key
                        var airlineID = from airlines in AirlinesWindow.airlines
                                        join flights in flights on airlines.ID equals flights.AirlineID
                                        where airlines.ID == int.Parse(tbAirlineID.Text)
                                        orderby flights.DepartureDate
                                        select new
                                        {
                                            airlines.ID,
                                            airlines.Airplane,
                                            airlines.Name,
                                            airlines.SeatsAvailable,
                                            airlines.MealAvailable
                                        };

                        //if-else condition to know if the inputted key is existing
                        if (!airlineID.Any())
                        {
                            MessageBox.Show("Incorrect input! AirlineID does not exist.", "Error",
                                            MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else
                        {
                            lstairlineID.DataContext = airlineID.Distinct();

                            flights.Add(new Flights(flights.Count, int.Parse(tbAirlineID.Text), tbDeparture.Text,
                                                    tbDestination.Text, tbDate.Text,
                                                    double.Parse(tbTime.Text)));

                            var names = from flights in flights
                                        select flights.DestinationCity;

                            lstFlights.DataContext = names;
                        }                            
                    }
                    else
                    {
                        MessageBox.Show("Incorrect input! Please enter a number in the flight time or AirlineID.", "Error",
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

        private void updateFlights()
        {
            //if-else condition for superuser function limits
            if (LoginWindow.superUser == 1)
            {
                //if-else condition if a user did not input anything in the textboxes
                if (tbDeparture.Text == "" || tbDestination.Text == "" ||
                tbDate.Text == "" || tbTime.Text == "" || tbAirlineID.Text == "")
                {
                    MessageBox.Show("No text box can be empty", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    //if-else condition to check incorrect input
                    if (IsTextAllowed(tbTime.Text) && IsTextAllowed(tbAirlineID.Text))
                    {
                        //LINQ for getting the airline information using airlineID as foreign key
                        var airlineID = from airlines in AirlinesWindow.airlines
                                        join flights in flights on airlines.ID equals flights.AirlineID
                                        where airlines.ID == int.Parse(tbAirlineID.Text)
                                        orderby flights.DepartureDate
                                        select new
                                        {
                                            airlines.ID,
                                            airlines.Airplane,
                                            airlines.Name,
                                            airlines.SeatsAvailable,
                                            airlines.MealAvailable
                                        };

                        //if-else condition to know if the inputted key is existing
                        if (!airlineID.Any())
                        {
                            MessageBox.Show("Incorrect input! AirlineID does not exist.", "Error",
                                            MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else
                        {
                            lstairlineID.DataContext = airlineID.Distinct();

                            Flights c = new Flights(lstFlights.SelectedIndex, int.Parse(tbAirlineID.Text), tbDeparture.Text,
                                                    tbDestination.Text, tbDate.Text, double.Parse(tbTime.Text));

                            flights[lstFlights.SelectedIndex] = c;

                            var names = from flights in flights
                                        select flights.DestinationCity;

                            lstFlights.DataContext = names;

                            MessageBox.Show("Successfully updated!", "Information",
                                MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Incorrect input! Please enter a number in the flight time or AirlineID.", "Error",
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

        private void deleteFlights()
        {
            //if-else condition for superuser function limits
            if (LoginWindow.superUser == 1)
            {
                //if-else condition if a user did not input anything in the textboxes of if user did not select anything from the listbox
                if (tbDeparture.Text == "" || tbDestination.Text == "" ||
                tbDate.Text == "" || tbTime.Text == "" || tbAirlineID.Text == "" ||lstFlights.SelectedIndex == -1)
                {
                    MessageBox.Show("No flight was selected! Please click a flight to delete.", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    flights.RemoveAt(lstFlights.SelectedIndex);

                    // reorder ID's - not good practise but needed to avoid breaking this app
                    for (int i = 0; i < flights.Count; i++)
                        flights[i].ID = i;

                    var names = from flights in flights
                                select flights.DestinationCity;

                    lstFlights.DataContext = names;
                    tbAirlineID.Clear();
                    tbDeparture.Clear();
                    tbDestination.Clear();
                    tbDate.Clear();
                    tbTime.Clear();
                    lstairlineID.DataContext = null;

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

        private void btnInsert_Click(object sender, RoutedEventArgs e) //button click event for adding an item
        {
            addFlights();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e) //button click event for updating an item
        {
            //Message box confirmation to update an item
            if (MessageBox.Show("Do you want to update this item?", "Close Application", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                updateFlights();
            }

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e) //button click event for delete an item
        {
            //Message box confirmation to delete an item
            if (MessageBox.Show("Do you want to delete this item?", "Close Application", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                deleteFlights();
            }

        }

        private void menuHelp_Click(object sender, RoutedEventArgs e) //menu click event handler for opening about page
        {
            AboutPage a = new AboutPage();
            a.ShowDialog();
        }

        private void menuDelete_Click(object sender, RoutedEventArgs e) //menu click event handler for deleting an item
        {
            //Message box confirmation to delete an item
            if (MessageBox.Show("Do you want to delete this item?", "Close Application", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                deleteFlights();
            }
        }

        private void menuUpdate_Click(object sender, RoutedEventArgs e) //menu click event handler for updating an item
        {
            //Message box confirmation to update an item
            if (MessageBox.Show("Do you want to update this item?", "Close Application", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                updateFlights();
            }
        }

        private void menuInsert_Click(object sender, RoutedEventArgs e) //menu click event handler for adding an item
        {
            addFlights();
        }

        private void menuQuit_Click(object sender, RoutedEventArgs e) //menu click event handler for closing this page
        {
            this.Close();
        }

        private void mnuWinInsert_Click(object sender, RoutedEventArgs e) //context menu click event handler for adding an item
        {
            addFlights();
        }

        private void mnuWinUpdate_Click(object sender, RoutedEventArgs e) //context menu click event handler for updating an item
        {
            //Message box confirmation to update an item
            if (MessageBox.Show("Do you want to update this item?", "Close Application", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                updateFlights();
            }
        }

        private void mnuWinDelete_Click(object sender, RoutedEventArgs e) //context menu click event handler for deleting an item
        {
            //Message box confirmation to delete an item
            if (MessageBox.Show("Do you want to delete this item?", "Close Application", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                deleteFlights();
            }
        }

        private void mnuWinClose_Click(object sender, RoutedEventArgs e) //context menu click event handler for closing this page
        {
            this.Close();
        }

        private void flightsPage_Closing(object sender, System.ComponentModel.CancelEventArgs e) //message box for closing confirmation
        {
            if (MessageBox.Show("This will close down the Flights page. Confirm?", "Close Application", MessageBoxButton.YesNo) == MessageBoxResult.No)
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
