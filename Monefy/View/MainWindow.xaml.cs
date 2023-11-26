using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using Monefy.Model.Holders;
using Monefy.Services.FileServices;
using Monefy.ViewModel;

namespace Monefy.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UserViewModel userViewModel;
        Storyboard storyboard;


        public MainWindow()
        {
            InitializeComponent();

            userViewModel = new UserViewModel(new XmlFileService());
            DataContext = userViewModel;

            dateLabel.Content = "All Period";

            ExpencesHolder eh = new ExpencesHolder();

            AssignImageSources();
        }

    




        // Used to assign all default image sources from 'Images' folder 
        private void AssignImageSources()
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
        }   



        #region intervalDateStackPanel Activator Events


        private void intervalDateLabel_MouseDown(object sender, MouseButtonEventArgs e)
        {

            // Open animation
            if (intervalDateLabel.Content.ToString() == "≡")
            {
                intervalDateLabel.Content = "←";

                storyboard = new Storyboard();

                DoubleAnimation da = new DoubleAnimation();

                da.From = 0;
                da.To = 120;

                da.AutoReverse = false;
                da.DecelerationRatio = 1;
                da.Duration = new Duration(TimeSpan.FromSeconds(0.3));

                storyboard.Children.Add(da);
                Storyboard.SetTargetName(da, intervalDateStackPanel.Name);
                Storyboard.SetTargetProperty(da, new PropertyPath(StackPanel.WidthProperty));

                storyboard.Begin(this);

                intervalDateStackPanel.BeginAnimation(StackPanel.WidthProperty, da);
            }


            // Close animation
            else if (intervalDateLabel.Content.ToString() == "←")
            {
                intervalDateLabel.Content = "≡";

                storyboard = new Storyboard();

                DoubleAnimation da = new DoubleAnimation();

                da.From = 120;
                da.To = 0;

                da.AutoReverse = false;
                da.DecelerationRatio = 1;
                da.Duration = new Duration(TimeSpan.FromSeconds(0.3));

                storyboard.Children.Add(da);
                Storyboard.SetTargetName(da, intervalDateStackPanel.Name);
                Storyboard.SetTargetProperty(da, new PropertyPath(StackPanel.WidthProperty));

                storyboard.Begin(this);

                intervalDateStackPanel.BeginAnimation(StackPanel.WidthProperty, da);
            }

        }


        private void mainAppGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (intervalDateStackPanel.Width > 0)
            {
                intervalDateLabel.Content = "≡";

                storyboard = new Storyboard();

                DoubleAnimation da = new DoubleAnimation();

                da.From = 120;
                da.To = 0;

                da.AutoReverse = false;
                da.DecelerationRatio = 1;
                da.Duration = new Duration(TimeSpan.FromSeconds(0.3));

                storyboard.Children.Add(da);
                Storyboard.SetTargetName(da, intervalDateStackPanel.Name);
                Storyboard.SetTargetProperty(da, new PropertyPath(StackPanel.WidthProperty));

                storyboard.Begin(this);

                intervalDateStackPanel.BeginAnimation(StackPanel.WidthProperty, da);
            }
        }



        #endregion


        #region NewExpenceButton and NewIncomeButton Click


        private void expenceButton_Click(object sender, RoutedEventArgs e)
        {
            NewExpenceWindow newExpenceWindow = new NewExpenceWindow(userViewModel);

            newExpenceWindow.ShowDialog();
        }

        private void incomeButton_Click(object sender, RoutedEventArgs e)
        {
            NewIncomeWindow newIncomeWindow = new NewIncomeWindow(userViewModel);

            newIncomeWindow.ShowDialog();
        }

        #endregion






        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            userViewModel.SaveUserExpences();
            userViewModel.SaveUserIncomes();
        }


        private void chooseDayButton_Click(object sender, RoutedEventArgs e)
        {
            dateLabel.Content = DateTime.Today;
        }

        private void chooseWeekButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime d1 = DateTime.Today.AddDays(-7);
            dateLabel.Content = $"{d1.Month}/{d1.Day}/{d1.Year} - {DateTime.Today.Month}/{DateTime.Today.Day}/{DateTime.Today.Year}";
        }

        private void chooseMonthButton_Click(object sender, RoutedEventArgs e)
        {
            double days = DateTime.Today.AddDays(-1).Day;
            DateTime d1 = DateTime.Today.AddDays(-days);
            dateLabel.Content = $"{d1.Month}/{d1.Day}/{d1.Year} - {DateTime.Today.Month}/{DateTime.Today.Day}/{DateTime.Today.Year}";
        }

        private void chooseYearButton_Click(object sender, RoutedEventArgs e)
        {
            double days = DateTime.Today.AddDays(-1).DayOfYear;
            DateTime d1 = DateTime.Today.AddDays(-days);
            dateLabel.Content = $"{d1.Month}/{d1.Day}/{d1.Year} - {DateTime.Today.Month}/{DateTime.Today.Day}/{DateTime.Today.Year}";
        }

        private void chooseAllIntervalButton_Click(object sender, RoutedEventArgs e)
        {
            dateLabel.Content = "All Period";
        }

        private void chooseAnyDateButton_Click(object sender, RoutedEventArgs e)
        {
            dateLabel.Content = datePicker.SelectedDate;
        }
    }
}
