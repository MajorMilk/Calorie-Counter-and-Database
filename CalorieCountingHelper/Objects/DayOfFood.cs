using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCountingHelper.Objects
{
    public class DayOfFood
    {
        public List<Meal> Meals = new List<Meal>();

        public int Calories { get; private set; }
        public string FilePath { get; set; }

        public string Date { get; private set; }
        
        public string Month { get; private set; }

        public DayOfFood(string date)
        {
            this.Calories = 0;
            this.Date = date.Split(' ')[0];
            int dateIndex = int.Parse(date.Substring(0, 1)) - 1;
            this.Month = Helpers.months[dateIndex];
            this.FilePath = Helpers.FilePathFromDate(date);
        }


        public int CountCalories()
        {
            int t = 0;
            foreach (Meal meal in Meals)
            {
                foreach(FoodItem fi in meal.Contents)
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
            string[] lines = this.ToString().Split('\n');
            if(!Directory.Exists(Path.GetDirectoryName(this.FilePath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(this.FilePath));
            }
            File.WriteAllLines(this.FilePath, lines);
        }

        public DayOfFood(string[] FileData, string date)
        {
            DayOfFood temp = new DayOfFood(date);

            List<int> mealIndexs = new List<int>();

            for (int i = 0; i < FileData.Length; i++)
            {
                if (FileData[i].Contains(':'))
                    mealIndexs.Add(i);
            }

            FoodItem fi = new FoodItem();
            Meal m = new Meal();


            for (int i = 0; i < mealIndexs.Count; i++)
            {
                m = new Meal();
                if (i < mealIndexs.Count - 1)
                {
                    for (int j = mealIndexs[i] + 1; j < mealIndexs[i + 1]; j++)
                    {
                        fi = new FoodItem();
                        string line = FileData[j];
                        string[] brokenLine = line.Split('-');

                        string name = brokenLine[0].Trim();

                        string tempCal = brokenLine[1].Trim();
                        tempCal = tempCal.Split(' ')[0];
                        int calories = int.Parse(tempCal);
                        int ammount = int.Parse(brokenLine[2].Trim().Substring(1));
                        fi = new FoodItem(name, calories, ammount);
                        m += fi;
                    }
                    temp += m;
                }
                else
                {
                    for (int k = mealIndexs[mealIndexs.Count - 1] + 1; k < FileData.Length; k++)
                    {
                        fi = new FoodItem();
                        string line = FileData[k];
                        string[] brokenLine = line.Split('-');

                        string name = brokenLine[0].Trim();
                        if (brokenLine.Length < 2) continue;
                        string tempCal = brokenLine[1].Trim();
                        tempCal = tempCal.Split(' ')[0];
                        int calories = int.Parse(tempCal);
                        int ammount = int.Parse(brokenLine[2].Trim().Substring(1));
                        fi = new FoodItem(name, calories, ammount);
                        m += fi;
                    }
                    temp += m;
                }
            }
            this.Month = temp.Month;
            this.FilePath = temp.FilePath;
            this.Date = temp.Date.Split(' ')[0];
            this.Meals = temp.Meals;

        }
    }
}
