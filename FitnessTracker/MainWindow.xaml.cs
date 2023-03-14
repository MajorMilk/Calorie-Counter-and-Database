using FitnessTracker.Controls;
using FitnessTracker.Objects;
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

namespace FitnessTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HomeControl _home;
        private EditMealControl _editMeal = new EditMealControl(new Meal());
        private string _currentDate;
        private DayOfFood CurrentDayOfFood;
        public MainWindow()
        {
            InitializeComponent();
            MainCal.SelectedDate = DateTime.Today;
            _currentDate = MainCal.SelectedDate.ToString();

            LOAD(_currentDate);
           
        }

        private void ShowEditMealWindow(Meal m, int index)
        {
            _editMeal = new EditMealControl(m);
            _editMeal.EditMealDone += (sender, e) =>
            {
                MaintContent.Content = _home;
                _home.CurrentDay.Meals[index] = _editMeal.meal;
                _home.CurrentDay.CountCalories();
                _home.CurrentDay.SaveDay();
                _home.LoadMeals();
                _editMeal = null;
            };
            MaintContent.Content = _editMeal;
        }


        private void LOAD(string date)
        {
            _currentDate = date;
            string path = Helpers.FilePathFromDateDay(_currentDate);

            if (Helpers.TryLoadDay(path, out DayOfFood dayOfFood))
            {
                CurrentDayOfFood = dayOfFood;
            }
            else
            {
                CurrentDayOfFood = new DayOfFood(_currentDate);
            }
            _home = new HomeControl(CurrentDayOfFood, _currentDate);
            MaintContent.Content = _home;

            _home.SwitchToEditMeal += (sender, e) =>
            {
                ShowEditMealWindow(_home.CurrentDay.Meals[_home.HomeContent.SelectedIndex], _home.HomeContent.SelectedIndex);
            };
        }



        //does everything the constructor does.
        public void UpdateDate(object sender, RoutedEventArgs e)
        {
            LOAD(MainCal.SelectedDate.ToString());
        }

        private void CustomFoodButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
