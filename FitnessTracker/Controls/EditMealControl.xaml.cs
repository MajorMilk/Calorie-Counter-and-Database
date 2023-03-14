using FitnessTracker.Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace FitnessTracker.Controls
{
    /// <summary>
    /// Interaction logic for EditMealControl.xaml
    /// </summary>
    public partial class EditMealControl : UserControl
    {

        public Meal meal;
        public delegate void EditMealDoneDelegate(object sender, EventArgs e);
        public event EditMealDoneDelegate EditMealDone;

        public EditMealControl(Meal m)
        {
            InitializeComponent();

            meal = m;
            LoadFood();
        }


        private void LoadFood()
        {
            FoodList.Items.Clear();
            int it = 0;
            foreach(FoodItem f in meal.Contents)
            {
                var FoodSlot = new FoodItemSlotControl(f, it++);
                FoodSlot.RemoveButtons();

                FoodList.Items.Add(FoodSlot);
            }

            CaloriesBlock.Text = "Calories: " +  meal.Calories.ToString();
        }


        private void AddFoodButton_Click(object sender, RoutedEventArgs e)
        {
            if(InputControl.ConstructFoodItem())
            {
                meal += InputControl.ConstructedFoodItem;
                LoadFood();
            }
        }

        private void SaveFoodButton_Click(object sender, RoutedEventArgs e)
        {
            if(InputControl.ConstructFoodItem())
            {
                InputControl.SaveFood();
            }
        }

        private void AddFromFileButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".xml"; // Default file extension
            dlg.Filter = "XML Files (.xml)|*.xml"; // Filter files by extension


            string path = Directory.GetCurrentDirectory() + $@"\DATA\FOOD";

            if(!Directory.Exists(path)) Directory.CreateDirectory(path);
            dlg.InitialDirectory = path;

            // Show open file dialog box
            bool? result = dlg.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                string filename = dlg.FileName;

                FoodItem t = null;
                if(Helpers.TryLoadFood(dlg.FileName, out t))
                {
                    meal += t;
                    LoadFood();
                }

            }
        }

        private void DelFoodButton_Click(object sender, RoutedEventArgs e)
        {
            int[] boxes = getBoxesChecked();
            Meal subMeal = new();
            int it = 0;
            foreach(int i in boxes)
            {
                if(i == 1)
                {
                    subMeal += meal.Contents[it];
                }
                it++;
            }
            meal -= subMeal;
            LoadFood();
        }

        private int[] getBoxesChecked()
        {
            List<int> boxes = new List<int>();

            boxes.Add((bool)Row1Box.IsChecked ? 1 : 0);
            boxes.Add((bool)Row2Box.IsChecked ? 1 : 0);
            boxes.Add((bool)Row3Box.IsChecked ? 1 : 0);
            boxes.Add((bool)Row4Box.IsChecked ? 1 : 0);
            boxes.Add((bool)Row5Box.IsChecked ? 1 : 0);
            boxes.Add((bool)Row6Box.IsChecked ? 1 : 0);
            boxes.Add((bool)Row7Box.IsChecked ? 1 : 0);
            boxes.Add((bool)Row8Box.IsChecked ? 1 : 0);

            return boxes.ToArray();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            EditMealDone?.Invoke(this, EventArgs.Empty);
        }
    }
}
