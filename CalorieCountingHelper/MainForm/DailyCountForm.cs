using CalorieCountingHelper.EditDayForm;
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

namespace CalorieCountingHelper
{
    public partial class DailyCountForm : Form
    {
        public DailyCountForm()
        {
            InitializeComponent();
            STARTUP();
        }

        public string currentDate = "";
        public DayOfFood currentDayOfFood;


        /// <summary>
        /// Sets the date and current day of food
        /// </summary>
        private void STARTUP()
        {
            currentDate = monthCalendar1.SelectionRange.Start.ToString();
            UpdateCurrentDayOfFood();
            
        }

        /// <summary>
        /// Seachers the data folder for todays data, if it cant be found make it
        /// </summary>
        private void UpdateCurrentDayOfFood()
        {
            if (Helpers.DataExists(currentDate))
            {
                string filepath = Helpers.FilePathFromDate(currentDate);
                string[] lines = Helpers.ReadAllLinesFromFile(filepath);
                currentDayOfFood = new DayOfFood(lines, currentDate);
                SetBoxes();
            }
            else
            {
                currentDayOfFood = new DayOfFood(currentDate);
                currentDayOfFood.SaveDay();
                SetBoxes();
            }
        }
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            STARTUP();
        }
        /// <summary>
        /// Updates Textboxes
        /// </summary>
        public void SetBoxes()
        {
            NumMealsBox.Text = currentDayOfFood.Meals.Count.ToString();
            TotalCalsBox.Text = currentDayOfFood.CountCalories().ToString();
            DataReadoutBox.Text = currentDayOfFood.ToString();
        }


        /// <summary>
        /// Essentially just calling .RemoveAt() on a list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveMealButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to proceed?, this is irreversable and could result in the loss of data.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    int meal = int.Parse(MealBox.Text) - 1;
                    if (meal > currentDayOfFood.Meals.Count - 1 || meal < 0) throw new Exception();
                    else
                    {
                        currentDayOfFood -= meal; 
                        SetBoxes();
                    }


                }
                catch (Exception)
                {
                    MessageBox.Show("Error: Please enter the number associated with the meal you want to delete");
                    return;
                }
            }
            else
                return;
            
        }
        /// <summary>
        /// Adds an empty meal to the day
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddMealButtom_Click(object sender, EventArgs e)
        {
            currentDayOfFood += new Meal();
            SetBoxes();
        }

        /// <summary>
        /// Opens a secondary form to edit the individual meals
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditMealButton_Click(object sender, EventArgs e)
        {
            try
            {
                int meal = int.Parse(MealBox.Text) - 1;
                if (meal > currentDayOfFood.Meals.Count - 1 || meal < 0) throw new Exception();
                else
                {
                    EditMealForm EMF = new EditMealForm(currentDayOfFood,meal);
                    EMF.Owner = this;
                    EMF.Show();
                }


            }
            catch (Exception)
            {
                MessageBox.Show("Error: Please enter the number associated with the meal you want to delete");
                return;
            }
            
        }

        private void DailyCountForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
