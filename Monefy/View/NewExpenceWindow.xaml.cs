using Monefy.ViewModel;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace Monefy.View
{
    /// <summary>
    /// Interaction logic for NewExpenceWindow.xaml
    /// </summary>
    public partial class NewExpenceWindow : Window
    {
        UserViewModel userViewModel;
        Storyboard storyboard;

        public NewExpenceWindow(UserViewModel userViewModel)
        {
            InitializeComponent();
            this.userViewModel = userViewModel;
            DataContext = userViewModel;

            AssignPhotoSources();

            dateLabel.Content = DateTime.Now.DayOfWeek + ", " + DateTime.Now.Day + " " + GetMonth(DateTime.Now.Month);
        }


        private string GetMonth(int m)
        {
            if (m == 1)
                return "January";
            else if (m == 2)
                return "February";
            else if (m == 3)
                return "March";
            else if (m == 4)
                return "April";
            else if (m == 5)
                return "May";
            else if (m == 6)
                return "June";
            else if (m == 7)
                return "July";
            else if (m == 8)
                return "August";
            else if (m == 9)
                return "September";
            else if (m == 10)
                return "October";
            else if (m == 11)
                return "November";
            else if (m == 12)
                return "December";

            return String.Empty;
        }


        private void backLabel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }



        #region Categories Stack Panel Button Events


        private void categoryButton_MouseClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        #endregion


        #region Categories Stack Panel Activator Events


        private void chooseCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(sumLabel.Content as String))
            {
                storyboard = new Storyboard();

                DoubleAnimation da = new DoubleAnimation();

                da.From = 10;
                da.To = 400;



                da.AutoReverse = false;

                da.Duration = new Duration(TimeSpan.FromSeconds(0.5));

                storyboard.Children.Add(da);
                Storyboard.SetTargetName(da, categoriesStackPanel.Name);
                Storyboard.SetTargetProperty(da, new PropertyPath(StackPanel.HeightProperty));

                storyboard.Begin(this);

                categoriesStackPanel.BeginAnimation(StackPanel.HeightProperty, da);
            }
        }

        private void sumGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (categoriesStackPanel.Height > 0)
            {
                storyboard = new Storyboard();

                DoubleAnimation da = new DoubleAnimation();

                da.From = 400;
                da.To = 0;



                da.AutoReverse = false;

                da.Duration = new Duration(TimeSpan.FromSeconds(0.5));

                storyboard.Children.Add(da);
                Storyboard.SetTargetName(da, categoriesStackPanel.Name);
                Storyboard.SetTargetProperty(da, new PropertyPath(StackPanel.HeightProperty));

                storyboard.Begin(this);

                categoriesStackPanel.BeginAnimation(StackPanel.HeightProperty, da);
            }
        }

        #endregion



        #region Calculator

        string fullEquation = String.Empty;

        bool dotAvailable = false;
        bool isFirstNumber = true;
        bool newNumber = true;


        private void NumericButton_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;


            if (!String.IsNullOrEmpty(fullEquation))
            {
                if (newNumber)
                {
                    fullEquation += b.Content;
                    newNumber = false;
                }

                else if (fullEquation.Length >= 2 && fullEquation[fullEquation.Length - 2] != '0')
                {
                    fullEquation += b.Content;
                }
                else if (fullEquation[fullEquation.Length - 1] != '0')
                    fullEquation += b.Content;


                if (isFirstNumber)
                {
                    isFirstNumber = false;
                    dotAvailable = true;
                }
            }

            else
            {
                fullEquation += b.Content;
                newNumber = false;
            }


            if (!String.IsNullOrEmpty(fullEquation))
            {
                sumLabel.Content = fullEquation;
            }

        }



        private void SignButton_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;

            if (String.IsNullOrEmpty(fullEquation)) return;

            char sign = fullEquation[fullEquation.Length - 1];

            if (sign != '+' && sign != '-' && sign != 'x' && sign != '/' && sign != '.')
                fullEquation += b.Content;

            dotAvailable = true;

            newNumber = true;


            sumLabel.Content = String.Empty;
        }



        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            string eq = fullEquation;

            if (eq[eq.Length - 1] == '+' || eq[eq.Length - 1] == '/' || eq[eq.Length - 1] == 'x' || eq[eq.Length - 1] == '-')
                return;
            if (String.IsNullOrEmpty(eq)) return;


            if (!String.IsNullOrEmpty(eq))
            {
                Double res = 0;

                try
                {
                    string currNumStr = "";
                    String sign = String.Empty;

                    bool first = true;

                    for (int i = 0; i < eq.Length; i++)
                    {
                        if (eq[i] == '+' || eq[i] == '-' || eq[i] == 'x' || eq[i] == '/')  // takes sign
                        {
                            if (sign != String.Empty)
                            {
                                if (sign == "+")
                                    res += Double.Parse(currNumStr);

                                else if (sign == "-")
                                    res -= Double.Parse(currNumStr);

                                else if (sign == "x")
                                    res *= Double.Parse(currNumStr);

                                else if (sign == "/")
                                    res /= Double.Parse(currNumStr);

                                currNumStr = String.Empty;
                            }


                            sign = eq[i].ToString();

                            if (first)
                            {
                                first = false;
                                res = Double.Parse(currNumStr);
                                currNumStr = String.Empty;
                            }
                        }

                        else // takes number
                        {
                            currNumStr += eq[i];
                        }
                    }


                    if (sign != String.Empty)
                    {
                        if (sign == "+")
                            res += Double.Parse(currNumStr);

                        else if (sign == "-")
                            res -= Double.Parse(currNumStr);

                        else if (sign == "x")
                            res *= Double.Parse(currNumStr);

                        else if (sign == "/")
                            res /= Double.Parse(currNumStr);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Message: {ex.Message}\n\nStack Trace: {ex.StackTrace}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                res = Math.Round(res, 2);

                sumLabel.Content = res.ToString();
                fullEquation = res.ToString();
            }
        }



        private void DotButton_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(fullEquation)) return;

            char c = fullEquation[fullEquation.Length - 1];  // previoues to dot character

            if ((c == '0' || c == '1' || c == '2' || c == '3' ||
                c == '4' || c == '5' || c == '6' ||
                c == '7' || c == '8' || c == '9') && dotAvailable)
            {
                fullEquation += ".";
                dotAvailable = false;
                sumLabel.Content = fullEquation;
            }
        }



        private void deleteLabel_MouseDown(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(fullEquation)) return;

            int equationLength = fullEquation.Length;
            char lastChar = 'n';
            char prevToLastChar = 'n';


            if (equationLength >= 1)
                lastChar = fullEquation[fullEquation.Length - 1];  // char to delete

            if (equationLength >= 2)
                prevToLastChar = fullEquation[fullEquation.Length - 2];


            if (lastChar == '.')
            {
                dotAvailable = true;
                if (prevToLastChar == '0')
                    newNumber = false;
            }

            else if (prevToLastChar == '+' || prevToLastChar == '-' || prevToLastChar == 'x' || prevToLastChar == '/')
            {
                newNumber = true;
            }

            fullEquation = fullEquation.Remove(fullEquation.Length - 1, 1);

            if (String.IsNullOrEmpty(fullEquation))
            {
                newNumber = true;
                isFirstNumber = true;
                sumLabel.Content = String.Empty;
            }
            else sumLabel.Content = (sumLabel.Content as String).Remove((sumLabel.Content as String).Length - 1, 1);


        }



        #endregion

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            sumLabel.Content = String.Empty;
        }


        private void AssignPhotoSources()
        {
            sportsIconImage.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + System.IO.Path.DirectorySeparatorChar + "Images/sportsIcon.png"));
            toiletryImage.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + System.IO.Path.DirectorySeparatorChar + "Images/toiletryIcon.png"));
            transportImage.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + System.IO.Path.DirectorySeparatorChar + "Images/transportIcon.png"));
            eatingOutImage.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + System.IO.Path.DirectorySeparatorChar + "Images/eatingOutIcon.png"));
            taxiImage.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + System.IO.Path.DirectorySeparatorChar + "Images/taxiIcon.png"));
            houseImage.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + System.IO.Path.DirectorySeparatorChar + "Images/houseIcon.png"));
            clothesImage.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + System.IO.Path.DirectorySeparatorChar + "Images/clothesIcon.png"));
            foodImage.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + System.IO.Path.DirectorySeparatorChar + "Images/foodIcon.png"));
            giftsImage.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + System.IO.Path.DirectorySeparatorChar + "Images/giftsIcon.png"));
            entertainmentImage.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + System.IO.Path.DirectorySeparatorChar + "Images/entertainmentIcon.png"));
            petImage.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + System.IO.Path.DirectorySeparatorChar + "Images/petIcon.png"));
            communicationsImage.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + System.IO.Path.DirectorySeparatorChar + "Images/communicationsIcon.png"));
            carImage.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + System.IO.Path.DirectorySeparatorChar + "Images/carIcon.png"));
            healthImage.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + System.IO.Path.DirectorySeparatorChar + "Images/healthIcon.png"));

            cashImage.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + System.IO.Path.DirectorySeparatorChar + "Images/cashIcon.png"));
        }

  
    }
}
