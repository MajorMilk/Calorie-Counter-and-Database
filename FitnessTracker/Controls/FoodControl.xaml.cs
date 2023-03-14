using FitnessTracker.Objects;
using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace FitnessTracker.Controls
{
    /// <summary>
    /// Interaction logic for FoodControl.xaml
    /// </summary>
    public partial class FoodControl : UserControl
    {
        public FoodControl()
        {
            InitializeComponent();
        }


        public FoodItem ConstructedFoodItem = null;

        public bool ConstructFoodItem()
        {
            if(ReadFields())
            {
                ConstructedFoodItem = new FoodItem(_name, _cals, 1, _protein, _carbs, _fat, _fiber, _sodium, _sugar);
                return true;
            }
            return false;
        }




        public void SaveFood()
        {
            if(ConstructFoodItem())
            {
                Microsoft.Win32.SaveFileDialog saveDialogue = new();

                string path = Directory.GetCurrentDirectory() + $@"\DATA\FOOD";

                if(!Directory.Exists(path)) Directory.CreateDirectory(path);

                saveDialogue.InitialDirectory = path;
                saveDialogue.Filter = "XML files (*.xml)|*.xml";
                saveDialogue.AddExtension = true;
                saveDialogue.FileName = "FoodName";


                bool? result = saveDialogue.ShowDialog();

                if(result == true)
                {
                    if(Helpers.TryWriteFood(saveDialogue.FileName, ConstructedFoodItem)) MessageBox.Show("Success!");
                    else
                    {
                        MessageBox.Show("Failed To write Food");
                    }
                }
            }
        }









        //calsbox
        //carbsbox
        //fat
        //fiber sodium
        //sugar protein

        private int _cals, _carbs, _fat, _fiber, _sodium, _protein, _sugar;

        private string? _name;

        private bool ReadFields()
        {
            if (!int.TryParse(CalsBox.Text, out _cals))
            {
                MessageBox.Show("Failed to parse Calories Please enter a number such as 123, no decimals");
                return false;
            }
            if (!int.TryParse(CarbsBox.Text, out _carbs))
            {
                MessageBox.Show("Failed to parse Carbs Please enter a number such as 123, no decimals");
                return false;
            }

            if (!int.TryParse(FatBox.Text, out _fat))
            {
                MessageBox.Show("Failed to parse Fat Please enter a number such as 123, no decimals");
                return false;
            }

            if (!int.TryParse(FiberBox.Text, out _fiber))
            {
                MessageBox.Show("Failed to parse Fiber Please enter a number such as 123, no decimals");
                return false;
            }

            if (!int.TryParse(SodiumBox.Text, out _sodium))
            {
                MessageBox.Show("Failed to parse Sodium Please enter a number such as 123, no decimals");
                return false;
            }

            if (!int.TryParse(ProteinBox.Text, out _protein))
            {
                MessageBox.Show("Failed to parse Protein Please enter a number such as 123, no decimals");
                return false;
            }
            if(!int.TryParse(SugarBox.Text, out _sugar))
            {
                MessageBox.Show("Failed to parse Sugar Please enter a number such as 123, no decimals");
                return false;
            }

            _name = NameBox.Text;
            return true;
        }
    }
}
