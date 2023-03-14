using System;
using System.Runtime.Serialization;

namespace FitnessTracker.Objects
{

    [Serializable()]
    public class FoodItem : ISerializable
    {
        public string Name { get; set; }
        public int Calories { get; set; }

        public int Amount = 0;

        public int Protein { get; set; }       // Protein in grams
        public int Carbohydrates { get; set; } // Carbohydrates in grams
        public int Fat { get; set; }           // Fat in grams
        public int Fiber { get; set; }         // Fiber in grams
        public int Sodium { get; set; }        // Sodium in milligrams
        public int Sugar { get; set; }         // Sugar in grams


        /// <summary>
        /// MegaConstructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="calories"></param>
        /// <param name="amount"></param>
        /// <param name="protein"></param>
        /// <param name="carbohydrates"></param>
        /// <param name="fat"></param>
        /// <param name="fiber"></param>
        /// <param name="sodium"></param>
        /// <param name="sugar"></param>
        public FoodItem(string name, int calories, int amount, int protein, int carbohydrates, int fat, int fiber, int sodium, int sugar) : this(name, calories, amount)
        {
            Protein = protein;
            Carbohydrates = carbohydrates;
            Fat = fat;
            Fiber = fiber;
            Sodium = sodium;
            Sugar = sugar;
        }

        public FoodItem(string name, int C, int amount) 
        {
            this.Name = name;
            this.Calories = C * amount;
            this.Amount = amount;
        }
        public FoodItem() 
        {
            this.Amount = 0;
            this.Name = "";
            this.Calories = 0;
        }
        public static FoodItem operator -(FoodItem f, int i)
        {
            f.Amount -= i;
            f.Calories -= (i * f.Calories);
            return f;
        }
        public static FoodItem operator +(FoodItem f, int i)
        {
            f.Amount += i;
            f.Calories += (i * f.Calories);
            return f;
        }

        public static FoodItem operator ++(FoodItem f)
        {
            if(f.Amount == 0)
            {
                f.Calories += f.Calories;
                f.Amount++;
                return f;
            }
            f.Calories += f.Calories / f.Amount;
            f.Amount++;
            return f;
        }
        public static FoodItem operator --(FoodItem f)
        {
            if (f.Amount <= 0) return f;
            f.Calories -= f.Calories / f.Amount;
            f.Amount--;
            return f;
        }

        public override string ToString()
        {
            return Name + $" - {this.Calories/this.Amount} Calories - x{this.Amount}";
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name);
            info.AddValue("Calories", Calories);
            info.AddValue("Amount", Amount);
            info.AddValue("Protein", Protein);
            info.AddValue("Carbohydrates", Carbohydrates);
            info.AddValue("Fat", Fat);
            info.AddValue("Fiber", Fiber);
            info.AddValue("Sodium", Sodium);
            info.AddValue("Sugar", Sugar);
            
        }
        public FoodItem(SerializationInfo info, StreamingContext context)
        {
            Name = (string)info.GetValue("Name", typeof(string));
            Calories = (int)info.GetValue("Calories", typeof(int));
            Amount = (int)info.GetValue("Amount", typeof(int));

            // Set values to 0 if data not found
            Protein = (int)info.GetValue("Protein", typeof(int));
            Carbohydrates = (int)info.GetValue("Carbohydrates", typeof(int));
            Fat = (int)info.GetValue("Fat", typeof(int));
            Fiber = (int)info.GetValue("Fiber", typeof(int));
            Sodium = (int)info.GetValue("Sodium", typeof(int));
            Sugar = (int)info.GetValue("Sugar", typeof(int));

            
        }
    }
}
