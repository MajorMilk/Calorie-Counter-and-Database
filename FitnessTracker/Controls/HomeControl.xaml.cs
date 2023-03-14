using FitnessTracker.Objects;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;

namespace FitnessTracker.Controls
{
    /// <summary>
    /// Interaction logic for HomeControl.xaml
    /// </summary>
    public partial class HomeControl : UserControl
    {
        public DayOfFood CurrentDay;
        private string date;

        public delegate void SwitchToEditMealDelegate(object sender, EventArgs e);
        public event SwitchToEditMealDelegate SwitchToEditMeal;


        public HomeControl(DayOfFood d, string date)
        {
            InitializeComponent();
            CurrentDay = d;
            LoadMeals();
            this.date = date;

        }



        public void LoadMeals()
        {
            HomeContent.Items.Clear();

            for (int i = 0; i < CurrentDay.Meals.Count; i++)
            {
                MealSlotControl mealSlot = new(CurrentDay.Meals[i], i+1);


                //tbh i really hate this method of cascading delegates to get the data back to this control, but its the best way I could think of
                mealSlot.UpdateCalories += (object sender, EventArgs e, bool ADD, int MealNum, int FoodNum) =>
                {
                    if(ADD)
                    {
                        CurrentDay.Meals[MealNum].Contents[FoodNum]++;
                        CurrentDay.SaveDay();
                    }
                    else
                    {
                        CurrentDay.Meals[MealNum].Contents[FoodNum]--;
                        if (CurrentDay.Meals[MealNum].Contents[FoodNum].Amount == 0)
                        {
                            CurrentDay.Meals[MealNum] -= CurrentDay.Meals[MealNum].Contents[FoodNum];
                        }
                        CurrentDay.SaveDay();
                    }
                    CurrentDay.CountCalories();
                    LoadMeals();
                };

                HomeContent.Items.Add(mealSlot);
            }
            CalBlock.Text = "Calories: " + CurrentDay.Calories.ToString();
        }


        private void AddMealButton_Click(object sender, RoutedEventArgs e)
        {
            //Add new row
            MealGrid.RowDefinitions.Add( new RowDefinition());
            CurrentDay += new Meal();

            LoadMeals();
        }

        private void EditMealButton_Click(object sender, RoutedEventArgs e)
        {
            if (HomeContent.SelectedIndex == -1) return;
            SwitchToEditMeal?.Invoke(sender, EventArgs.Empty);

        }

        private void LoadFoodButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new();
            dialog.Filter = "XML Files (*.xml)|*.xml";
            string path = Directory.GetCurrentDirectory();
            path += @"\DATA\MEALS\";
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            dialog.InitialDirectory = path;
            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                string selectedFilePath = dialog.FileName;
                Meal m; 
                if(!Helpers.TryLoadMeal(selectedFilePath, out m))
                {
                    MessageBox.Show("Failed to load meal");
                }
                else
                {
                    CurrentDay += m;
                    CurrentDay.CountCalories();
                    LoadMeals();
                }
            }

        }

        private void RemoveMealButton_Click(object sender, RoutedEventArgs e)
        {
            if (HomeContent.SelectedIndex == -1) return;
            CurrentDay -= HomeContent.SelectedIndex;
            CurrentDay.CountCalories();
            LoadMeals();
        }
    }
}
