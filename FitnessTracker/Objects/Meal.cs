using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FitnessTracker.Objects
{
    [Serializable()]
    public class Meal : ISerializable
    {
        public List<FoodItem> Contents = new List<FoodItem>();

        public int Calories { get; set; }

        public Meal(FoodItem f) 
        {
            Contents.Add(f);
            Calories = f.Calories;
        }

        public Meal() 
        {
            Calories = 0;
        }

        public static Meal operator +(Meal meal, FoodItem f)
        {
            
            meal.Contents.Add(f);
            meal.Calories += f.Calories;
            return meal;
        }
        public static Meal operator +(Meal meal, Meal f)
        {
            foreach (FoodItem item in f.Contents)
            {
                meal += f;
            }
            return meal;
        }
        public static Meal operator -(Meal meal, int i)
        {
            meal.Calories -= meal.Contents[i].Calories;
            if (meal.Contents[i].Amount > 1) meal.Contents[i].Amount--;
            else meal.Contents.RemoveAt(i);
            return meal;
        }
        public static Meal operator -(Meal meal, FoodItem f)
        {
            if (meal.Contents[meal.Contents.IndexOf(f)].Amount > 1)
            {
                meal.Calories -= f.Calories;
                meal.Contents[meal.Contents.IndexOf(f)].Amount--;
                return meal;
            }
            else
            {
                if (meal.Contents.Remove(f)) { meal.Calories -= f.Calories; return meal; }
                else return meal;
            }
            
        }
        public static Meal operator -(Meal meal, Meal f)
        {
            foreach(FoodItem item in f.Contents)
            {
                meal -= item;
            }
            return meal;
        }


        public override string ToString()
        {
            if (Contents.Count == 1) return this.Contents[0].ToString();
            else if(Contents.Count > 0)
            {
                string t = "";

                for (int i = 0; i < Contents.Count - 1; i++)
                {
                    t += Contents[i].ToString() + '\n';
                }
                t += Contents[Contents.Count - 1].ToString();
                return t;
            }

            return "";
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("FoodItems", Contents);
            info.AddValue("Calories", Calories);
        }
        public Meal(SerializationInfo info, StreamingContext context)
        {
            Contents = (List<FoodItem>)info.GetValue("FoodItems", typeof(List<FoodItem>));
            Calories = (int)info.GetValue("Calories", typeof(int));
        }
    }
}
