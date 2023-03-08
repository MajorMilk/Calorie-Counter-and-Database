using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCountingHelper.Objects
{
    public class FoodItem : ISerializable
    {
        public string Name { get; set; }
        public int Calories { get; set; }

        public int Amount = 0;

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
            f.Calories += f.Calories / f.Amount;
            f.Amount++;
            return f;
        }
        public static FoodItem operator --(FoodItem f)
        {
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
        }
        public FoodItem(SerializationInfo info, StreamingContext context)
        {
            Name = (string)info.GetValue("Name", typeof(string));
            Calories = (int)info.GetValue("Calories", typeof(int));
            Amount = (int)info.GetValue("Amount", typeof(int));
        }
    }
}
