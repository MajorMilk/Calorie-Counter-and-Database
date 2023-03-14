using FitnessTracker.Objects;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace FitnessTracker.Controls
{
    /// <summary>
    /// Interaction logic for MealSlotControl.xaml
    /// </summary>
    public partial class MealSlotControl : UserControl
    {

        public delegate void UpdateCaloriesDelegate(object sender, EventArgs e, bool ADD, int MealNum, int FoodNum);
        public event UpdateCaloriesDelegate UpdateCalories;


        public int MealNumber { get; set; }

        public Meal CurrentMeal { get; set; }

        public MealSlotControl(Meal meal)
        {
            InitializeComponent();
            MealNumber = 1;
            MealTextBox.Text += MealNumber.ToString();
            CurrentMeal = meal;
            LoadFood();
        }
        public MealSlotControl(Meal meal, int mealNum)
        {
            InitializeComponent();
            MealNumber = mealNum;
            MealTextBox.Text += MealNumber.ToString();
            CurrentMeal = meal;
            LoadFood();
        }



        public void LoadFood()
        {
            FoodListBox.Items.Clear();
            int it = 0;
            foreach(FoodItem fi in CurrentMeal.Contents)
            {
                //Places food item into the new slot
                FoodItemSlotControl itemSlot = new FoodItemSlotControl(fi, it++);

                itemSlot.AddOne += (object sender, EventArgs e) =>
                {
                    LoadFood();
                    UpdateCalories.Invoke(sender, e, true, MealNumber-1, itemSlot.ItemIndex);
                };

                itemSlot.RemoveOne += (object sender, EventArgs e) =>
                {
                    LoadFood();
                    UpdateCalories.Invoke(sender, e, false, MealNumber-1, itemSlot.ItemIndex);
                };

                FoodListBox.Items.Add(itemSlot);

            }
        }


        //Save button
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.Filter = "XML Files (*.xml)|*.xml";
            string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\DATA\MEALS\";
            if(!Directory.Exists(path)) Directory.CreateDirectory(path);
            dialog.InitialDirectory = path;
            dialog.FileName = "MyFile.xml";

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                string filePath = dialog.FileName;
                if(!Helpers.TryWriteMeal(filePath, CurrentMeal))
                {
                    MessageBox.Show("Failed to write Meal");
                }
            }
        }
    }
}
