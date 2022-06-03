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
    /// Interaction logic for AirlinesWindow.xaml
    /// </summary>
    public partial class AirlinesWindow : Window
    {
        public static List<Airlines> airlines = new List<Airlines>();

        public AirlinesWindow()
        {
            InitializeComponent();

            //LINQ for initial appearance of items in the listbox
            var names = from airlines in airlines
                        select airlines.Name;

            lstAirlines.DataContext = names;
        }

        private void lstAirlines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int i = lstAirlines.SelectedIndex;

            //LINQ for puting items fields onto the textboxes from the listbox
            var selectedAirlines = from airlines in airlines
                                   where airlines.ID == i
                                   select airlines;

            foreach (var s in selectedAirlines)
            {
                tbName.Text = s.Name;            
                tbSeats.Text = s.SeatsAvailable.ToString();
   
                if (radioBtn1.Content.ToString() == s.Airplane)
                {
                    radioBtn1.IsChecked = true;
                }
                else if (radioBtn2.Content.ToString() == s.Airplane)
                {
                    radioBtn2.IsChecked = true;
                }
                else if (radioBtn3.Content.ToString() == s.Airplane)
                {
                    radioBtn3.IsChecked = true;
                }
                else if (radioBtn4.Content.ToString() == s.Airplane)
                {
                    radioBtn4.IsChecked = true;
                }
                else
                {
                    radioBtn5.IsChecked = true;
                }



                if (mealBtn1.Content.ToString() == s.MealAvailable)
                {
                    mealBtn1.IsChecked = true;
                }
                else if (mealBtn2.Content.ToString() == s.MealAvailable)
                {
                    mealBtn2.IsChecked = true;
                }
                else if (mealBtn3.Content.ToString() == s.MealAvailable)
                {
                    mealBtn3.IsChecked = true;
                }
                else if (mealBtn4.Content.ToString() == s.MealAvailable)
                {
                    mealBtn4.IsChecked = true;
                }
                else
                {
                    mealBtn5.IsChecked = true;
                }
            }
        }

        //Method to add an item
        private void addAirlines()
        {
            //if-else condition for superuser function limits
            if (LoginWindow.superUser == 1)
            {
                var temp = stackOne.Children.OfType<RadioButton>().FirstOrDefault(r => r.IsChecked == true);
                var temp2 = stackTwo.Children.OfType<RadioButton>().FirstOrDefault(r => r.IsChecked == true);

                //if-else condition if a user did not input anything in the textboxes
                if (tbName.Text == "" || tbSeats.Text == "" || temp == null || temp2 == null)
                {
                    MessageBox.Show("No text box can be empty", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    //getting the value of the checked radio button
                    var selectedAir = stackOne.Children.OfType<RadioButton>().FirstOrDefault(r => r.IsChecked == true);
                    var selectedMeal = stackTwo.Children.OfType<RadioButton>().FirstOrDefault(r => r.IsChecked == true);

                    string tempAirplane = selectedAir.Content.ToString();
                    string tempMeals = selectedMeal.Content.ToString();

                    //if-else condition to check invalid input for seats availability text box
                    if (IsTextAllowed(tbSeats.Text))
                    {
                        airlines.Add(new Airlines(airlines.Count, tbName.Text,
                                     tempAirplane, int.Parse(tbSeats.Text),
                                     tempMeals));

                        var names = from airlines in airlines
                                    select airlines.Name;

                        lstAirlines.DataContext = names;
                    }
                    else
                    {
                        MessageBox.Show("Incorrect input! Please enter an integer in the number of seats.", "Error",
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

        //Method to update an item
        private void updateAirlines()
        {
            //if-else condition for superuser function limits
            if (LoginWindow.superUser == 1)
            {
                var temp = stackOne.Children.OfType<RadioButton>().FirstOrDefault(r => r.IsChecked == true);
                var temp2 = stackTwo.Children.OfType<RadioButton>().FirstOrDefault(r => r.IsChecked == true);

                //if-else condition if a user did not input anything in the textboxes
                if (tbName.Text == "" || tbSeats.Text == "" || temp == null || temp2 == null)
                {
                    MessageBox.Show("No text box can be empty", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    //getting the value of the checked radio button
                    var selectedAir = stackOne.Children.OfType<RadioButton>().FirstOrDefault(r => r.IsChecked == true);
                    var selectedMeal = stackTwo.Children.OfType<RadioButton>().FirstOrDefault(r => r.IsChecked == true);

                    string tempAirplane = selectedAir.Content.ToString();
                    string tempMeals = selectedMeal.Content.ToString();

                    //if-else condition to check invalid input for seats availability text box
                    if (IsTextAllowed(tbSeats.Text))
                    {
                        Airlines c = new Airlines(lstAirlines.SelectedIndex, tbName.Text,
                                                  tempAirplane, int.Parse(tbSeats.Text), tempMeals);

                        airlines[lstAirlines.SelectedIndex] = c;


                        var names = from airlines in airlines
                                    select airlines.Name;

                        lstAirlines.DataContext = names;

                        MessageBox.Show("Successfully updated!", "Information",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Incorrect input! Please enter an integer in the number of seats.", "Error",
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

        //Method to delete an item
        private void deleteAirlines()
        {
            //if-else condition for superuser function limits
            if (LoginWindow.superUser == 1)
            {
                var temp = stackOne.Children.OfType<RadioButton>().FirstOrDefault(r => r.IsChecked == true);
                var temp2 = stackTwo.Children.OfType<RadioButton>().FirstOrDefault(r => r.IsChecked == true);

                //if-else condition if a user did not input anything in the textboxes or did not select anything from the list box
                if (tbName.Text == "" || tbSeats.Text == "" || temp == null || temp2 == null || lstAirlines.SelectedIndex == -1)
                {
                    MessageBox.Show("No Airline was selected! Please click an airline to delete.", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    airlines.RemoveAt(lstAirlines.SelectedIndex);

                    // reorder ID's - not good practise but needed to avoid breaking this app
                    for (int i = 0; i < airlines.Count; i++)
                        airlines[i].ID = i;

                    var names = from airline in airlines
                                select airline.Name;

                    lstAirlines.DataContext = names;

                    var selectedAir = stackOne.Children.OfType<RadioButton>().FirstOrDefault(r => r.IsChecked == true);
                    var selectedMeal = stackTwo.Children.OfType<RadioButton>().FirstOrDefault(r => r.IsChecked == true);

                    selectedAir.IsChecked = false;
                    selectedMeal.IsChecked = false;

                    tbName.Clear();
                    tbSeats.Clear();

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
            addAirlines();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e) //button click event for updating an item
        {
            if (MessageBox.Show("Do you want to update this item?", "Close Application", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                updateAirlines();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e) //button click event for deleting an item
        {
            if (MessageBox.Show("Do you want to delete this item?", "Close Application", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                deleteAirlines();
            }
        }

        private void menuInsert_Click(object sender, RoutedEventArgs e) //menu click event for adding an item
        {
            addAirlines();
        }

        private void menuUpdate_Click(object sender, RoutedEventArgs e) //menu click event for updating an item
        {
            if (MessageBox.Show("Do you want to update this item?", "Close Application", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                updateAirlines();
            }
        }

        private void menuDelete_Click(object sender, RoutedEventArgs e) //menu click event for deleting an item
        {
            if (MessageBox.Show("Do you want to delete this item?", "Close Application", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                deleteAirlines();
            }
        }

        private void menuHelp_Click(object sender, RoutedEventArgs e) //menu click event for opening the about page
        {
            AboutPage a = new AboutPage();
            a.ShowDialog();
        }

        private void menuQuit_Click(object sender, RoutedEventArgs e) //menu click event for closing this page
        {
            this.Close();
        }

        private void mnuWinClose_Click(object sender, RoutedEventArgs e) //context menu click event for closing this page
        {
            this.Close();
        }

        private void mnuWinDelete_Click(object sender, RoutedEventArgs e) //context menu click event for deleting an item
        {
            if (MessageBox.Show("Do you want to delete this item?", "Close Application", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                deleteAirlines();
            }
        }

        private void mnuWinUpdate_Click(object sender, RoutedEventArgs e) //context menu click event for updating an item
        {
            if (MessageBox.Show("Do you want to update this item?", "Close Application", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                updateAirlines();
            }
        }

        private void mnuWinInsert_Click(object sender, RoutedEventArgs e) //context menu click event for adding an item
        {
            addAirlines();
        }

        private void airlinesPage_Closing(object sender, System.ComponentModel.CancelEventArgs e) //message box for closing confirmation
        {
            if (MessageBox.Show("This will close down the Airlines page. Confirm?", "Close Application", MessageBoxButton.YesNo) == MessageBoxResult.No)
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
