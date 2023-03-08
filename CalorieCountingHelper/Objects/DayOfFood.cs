using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace CalorieCountingHelper.Objects
{


    [Serializable()]
    public class DayOfFood : ISerializable
    {
        public List<Meal> Meals = new List<Meal>();

        public int Calories { get; set; }
        public string FilePath { get; set; }

        public string Date { get; set; }

        public string Month { get; set; }

        public DayOfFood(string date)
        {
            this.Calories = 0;
            this.Date = date.Split(' ')[0];
            int dateIndex = int.Parse(date.Substring(0, 1)) - 1;
            this.Month = Helpers.months[dateIndex];
            this.FilePath = Helpers.FilePathFromDate(date);
        }
        public DayOfFood() 
        {
            this.Calories = 0;
            this.FilePath = "";
            this.Date = "";
            this.Month = "";
        }


        public int CountCalories()
        {
            int t = 0;
            foreach (Meal meal in Meals)
            {
                foreach (FoodItem fi in meal.Contents)
                {
                    t += fi.Calories;
                }
            }
            Calories = t;
            return t;
        }



        public static DayOfFood operator +(DayOfFood a, Meal m)
        {
            a.Meals.Add(m);
            a.Calories += m.Calories;
            a.SaveDay();
            return a;
        }
        public static DayOfFood operator -(DayOfFood a, Meal m)
        {
            a.Meals.Remove(m);
            a.Calories -= m.Calories;
            a.SaveDay();
            return a;
        }
        public static DayOfFood operator -(DayOfFood a, int i)
        {

            a.Calories -= a.Meals[i].Calories;
            a.Meals.RemoveAt(i);
            a.SaveDay();

            return a;
        }

        public override string ToString()
        {
            int it = 1;
            string str = $"{this.Date}\n";
            foreach (Meal m in Meals)
            {
                str += $"Meal {it++}: \n";
                str += m.ToString() + '\n';
            }
            return str;
        }


        public void SaveDay()
        {
            Helpers.TryWriteDay(this, FilePath);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Meals", Meals);
            info.AddValue("Date", Date);
            info.AddValue("Calories", Calories);
            info.AddValue("FilePath", FilePath);
            info.AddValue("Month", Month);
        }

        public DayOfFood(SerializationInfo info, StreamingContext context)
        {
            Meals = (List<Meal>)info.GetValue("Meals", typeof(List<Meal>));
            Date = (string)info.GetValue("Date", typeof(string));
            Calories = (int)info.GetValue("Calories", typeof(int));
            FilePath = (string)info.GetValue("FilePath", typeof(string));
            Month = (string)info.GetValue("Month", typeof(string));
        }

    } 
}
