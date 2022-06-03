using System;
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
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Window
    {

        public HomePage()
        {
            InitializeComponent();
        }

        private void homePage_Closing(object sender, System.ComponentModel.CancelEventArgs e) //message box for closing confirmation

        {
            if (MessageBox.Show("This will close down the Homepage window. Confirm?", "Close Application", MessageBoxButton.YesNo) == MessageBoxResult.No)
            {
                e.Cancel = true;
                this.Activate();
            }
        }

        private void btnCustomer_Click(object sender, RoutedEventArgs e) //button click event handler for showing customer page
        {
            CustomerWindow c = new CustomerWindow();
            c.ShowDialog();
        }

        private void btnFlights_Click(object sender, RoutedEventArgs e)//button click event handler for showing flights page
        {
            FlightsWindow f = new FlightsWindow();
            f.ShowDialog();
        }

        private void btnAirlines_Click(object sender, RoutedEventArgs e) //button click event handler for showing airlines page
        {
            AirlinesWindow a = new AirlinesWindow();
            a.ShowDialog();
        }

        private void btnPassengers_Click(object sender, RoutedEventArgs e) //button click event handler for showing passenger page
        {
            PassengersWindow p = new PassengersWindow();
            p.ShowDialog();
        }

        private void menuCustomers_Click(object sender, RoutedEventArgs e) //menu click event handler for showing customer page
        {
            CustomerWindow c = new CustomerWindow();
            c.ShowDialog();
        }

        private void menuPassengers_Click(object sender, RoutedEventArgs e) //menu click event handler for showing passenger page
        {
            PassengersWindow p = new PassengersWindow();
            p.ShowDialog();
        }

        private void menuAirlines_Click(object sender, RoutedEventArgs e) //menu click event handler for showing airlines page
        {
            AirlinesWindow a = new AirlinesWindow();
            a.ShowDialog();
        }

        private void menuFlights_Click(object sender, RoutedEventArgs e) //menu click event handler for showing flights page
        {
            FlightsWindow f = new FlightsWindow();
            f.ShowDialog();
        }

        private void menuQuit_Click(object sender, RoutedEventArgs e) //menu click event handler for closing this page
        {
            this.Close();
        }

        private void menuHelp_Click(object sender, RoutedEventArgs e) //menu click event handler for showing about page
        {
            AboutPage a = new AboutPage();
            a.ShowDialog();
        }

        private void mnuWinClose_Click(object sender, RoutedEventArgs e) //context menu click event handler for closing this page
        {
            this.Close();
        }

        public static void addCustomer() // method for adding preloaded data for customers
        {
            CustomerWindow.people.Add(new Customer(0, "Jean Gunnhildr",
                        "101 Millside Drive Ontario, Canada",
                        "jean_gunnhildr@gmail.com",
                        "9050000000"));

            CustomerWindow.people.Add(new Customer(1, "Diluc Ragnvindr",
                                    "102 Millside Drive Ontario, Canada",
                                    "diluc_ragnvindr@gmail.com",
                                    "9051111111"));

            CustomerWindow.people.Add(new Customer(2, "Lisa Minci",
                                    "103 Millside Drive Ontario, Canada",
                                    "lisa_minci@gmail.com",
                                    "9052222222"));

            CustomerWindow.people.Add(new Customer(3, "Kaeya Alberich",
                                    "104 Millside Drive Ontario, Canada",
                                    "kaeya_alberich@gmail.com",
                                    "9053333333"));

            CustomerWindow.people.Add(new Customer(4, "Barbara Page",
                                    "105 Millside Drive Ontario, Canada",
                                    "barbara_page@gmail.com",
                                    "9054444444"));
        }

        public static void addFlights() // method for adding preloaded data for flights
        {

            FlightsWindow.flights.Add(new Flights(0, 0,
                                    "Toronto", "Manila",
                                    "11/02/20", 16.5));

            FlightsWindow.flights.Add(new Flights(1, 1,
                                    "Toronto", "Tokyo",
                                    "11/03/20", 17.5));

            FlightsWindow.flights.Add(new Flights(2, 2,
                                    "Toronto", "Hongkong",
                                    "11/04/20", 15.5));

            FlightsWindow.flights.Add(new Flights(3, 3,
                                    "Toronto", "Beijing",
                                    "11/05/20", 14.5));

            FlightsWindow.flights.Add(new Flights(4, 4,
                                    "Toronto", "Seoul",
                                    "11/06/20", 18.5));
        }

        public static void addAirlines() // method for adding preloaded data for airlines
        {
            AirlinesWindow.airlines.Add(new Airlines(0, "Philippine Airlines",
                                        "Airbus2001", 160,
                                        "Chicken"));

            AirlinesWindow.airlines.Add(new Airlines(1, "Air Canada",
                        "Boeing7878", 200,
                        "Hamburger"));

            AirlinesWindow.airlines.Add(new Airlines(2, "Sunwing Airlines",
                        "Skylink7001", 160,
                        "Beef Teriyaki"));

            AirlinesWindow.airlines.Add(new Airlines(3, "Westjet",
                        "Starlink8001", 160,
                        "Sushi"));

            AirlinesWindow.airlines.Add(new Airlines(4, "Flair Airlines",
                        "Voyager3001", 160,
                        "Bibimbap"));
        }
        public static void addPassenger() // method for adding preloaded data for passengers
        {
            PassengersWindow.passenger.Add(new Passenger(0, 0, 0));
            PassengersWindow.passenger.Add(new Passenger(1, 1, 1));
            PassengersWindow.passenger.Add(new Passenger(2, 2, 2));
            PassengersWindow.passenger.Add(new Passenger(3, 3, 3));
            PassengersWindow.passenger.Add(new Passenger(4, 4, 4));
        }

    }
}
