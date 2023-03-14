using FitnessTracker.Objects;
using System;
using System.Windows;
using System.Windows.Controls;

namespace FitnessTracker.Controls
{
    /// <summary>
    /// Interaction logic for FoodItemSlotControl.xaml
    /// </summary>
    public partial class FoodItemSlotControl : UserControl
    {

        public FoodItem CurrentItem { get; set; }
        public int ItemIndex { get; set; }

        public delegate void AddOneDelegate(object sender, EventArgs e);
        public event  AddOneDelegate AddOne;
        public delegate void RemoveOneDelegate(object sender, EventArgs e);
        public event RemoveOneDelegate RemoveOne;

        public FoodItemSlotControl(FoodItem fi, int itemIndex)
        {
            InitializeComponent();
            CurrentItem = fi;
            UpdateFields();
            ItemIndex = itemIndex;
        }

        private void UpdateFields()
        {
            NameBlock.Text = "Name: " + CurrentItem.Name;
            CaloriesBlock.Text = "Calories: " + CurrentItem.Calories;
            AmountBlock.Text = "Amount: " + CurrentItem.Amount;
        }

        private void AddOneButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateFields();
            AddOne.Invoke(sender, e);
        }

        private void RemoveOneButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateFields();
            RemoveOne.Invoke(sender, e);
        }

        internal void RemoveButtons()
        {
            AddOneButton.IsEnabled = false;
            RemoveOneButton.IsEnabled = false;
        }
    }
}
