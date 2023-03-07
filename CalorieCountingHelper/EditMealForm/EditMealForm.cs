using CalorieCountingHelper.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace CalorieCountingHelper.EditDayForm
{
    public partial class EditMealForm : Form
    {
        private DayOfFood currentDayOfFood;
        private int SelectedMealIndex;

        //only used as a clean way to get currentDayOfFood.Meals[SelectedMealIndex]
        Meal SelectedMeal;

        public EditMealForm(DayOfFood dof, int selectedMeal)
        {
            InitializeComponent();
            currentDayOfFood = dof;
            SelectedMealIndex = selectedMeal;

            SelectedMeal = currentDayOfFood.Meals[SelectedMealIndex];
        }

        private void EditDayForm_Load(object sender, EventArgs e)
        {
            MealDataBox.Text = formatMeal();
        }

        private string formatMeal()
        {
            int it = 1;
            string t = "";

            foreach(FoodItem fi in SelectedMeal.Contents)
            {
                t += $"{it++}: {fi.ToString()}\n";
            }
            return t;
        }


        /// <summary>
        /// Tries to remove one from the amount of a food item, if its amount is already 1, remove it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveFoodButton_Click(object sender, EventArgs e)
        {
            try
            {
                int fooditem = int.Parse(FoodBox.Text) - 1;
                if (fooditem > SelectedMeal.Contents.Count - 1 || fooditem < 0) throw new Exception();
                else
                {
                    currentDayOfFood.Meals[SelectedMealIndex].Contents[fooditem]--;
                    if (currentDayOfFood.Meals[SelectedMealIndex].Contents[fooditem].Amount == 0)
                    {
                        currentDayOfFood.Meals[SelectedMealIndex].Contents.RemoveAt(fooditem);
                    }

                }
                int i = currentDayOfFood.CountCalories();
                currentDayOfFood.SaveDay();
                MealDataBox.Text = formatMeal();
            }
            catch (Exception)
            {
                MessageBox.Show("Error: Please enter the number associated with the piece of food you want to delete");
                return;
            }
        }

        /// <summary>
        /// Increases the amount of a food item by one
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddSingleFoodButton_Click(object sender, EventArgs e)
        {
            try
            {
                int fooditem = int.Parse(FoodBox.Text) - 1;
                if (fooditem > SelectedMeal.Contents.Count - 1 || fooditem < 0) throw new Exception();
                else
                {
                    currentDayOfFood.Meals[SelectedMealIndex].Contents[fooditem]++;
                    int i = currentDayOfFood.CountCalories();
                    currentDayOfFood.SaveDay();
                    MealDataBox.Text = formatMeal();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error: Please enter the number associated with the piece of food you want to delete");
                return;
            }
        }


        /// <summary>
        /// Creates a new food item object based on inputs from dialogue boxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddFoodButton_Click(object sender, EventArgs e)
        {
            string name = Microsoft.VisualBasic.Interaction.InputBox("Food Name:", "Input", "");

            bool success = false;

            while(!success)
            {
                string CaloriesStr = Microsoft.VisualBasic.Interaction.InputBox("how many calories?", "Input", "");
                try
                {
                    int Cals = int.Parse(CaloriesStr);
                    currentDayOfFood.Meals[SelectedMealIndex].Contents.Add(new FoodItem(name, Cals, 1));
                    success = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Error: Please enter A number");
                    return;
                }
            }
            int i = currentDayOfFood.CountCalories();
            currentDayOfFood.SaveDay();
            MealDataBox.Text = formatMeal();
        }

        private void EditMealForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((DailyCountForm)this.Owner).SetBoxes();
        }

       
    }
}


