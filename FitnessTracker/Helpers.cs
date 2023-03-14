using System;
using System.IO;
using System.Windows;
using System.Xml.Serialization;
using FitnessTracker.Objects;

namespace FitnessTracker
{
    public static class Helpers
    {
        public static readonly string[] months = new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };


        public static string FilePathFromDateDay(string date)
        {
            DateTime dt = DateTime.Parse(date);
            int monthIndex = dt.Month - 1;
            string month = months[monthIndex];
            string workingDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            return Path.Combine(workingDirectory, $@"DATA\{month}\{date.Replace('/', '-').Split(' ')[0]}.xml");
        }

        public static string FilePathFood(string filename)
        {
            
            string workingDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            if (!Directory.Exists(workingDirectory + @"\DATA\FOOD\")) Directory.CreateDirectory(workingDirectory + @"\DATA\MEALS\");
                return workingDirectory + $@"\DATA\FOOD\{filename}.xml";
        }
        public static string FilePathMEAL(string filename)
        {
            string workingDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            if (!Directory.Exists(workingDirectory + @"\DATA\MEALS\")) Directory.CreateDirectory(workingDirectory + @"\DATA\MEALS\");
            return workingDirectory + $@"\DATA\MEALS\{filename}.xml";
        }

        public static bool DataExists(string date)
        {
            return File.Exists(FilePathFromDateDay(date));
        }


        public static bool TryWriteDay(DayOfFood day, string path)
        {
            if(!Directory.Exists(Path.GetDirectoryName(path))) Directory.CreateDirectory(Path.GetDirectoryName(path));
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(DayOfFood));
                using(TextWriter tw = new StreamWriter(path)) 
                {
                    serializer.Serialize(tw, day);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static bool TryLoadDay(string path, out DayOfFood day)
        {
            if (!Directory.Exists(Path.GetDirectoryName(path))) { day = null; return false; }
            try
            {
                XmlSerializer deserializer = new XmlSerializer (typeof(DayOfFood));

                using(StreamReader sr = new StreamReader(path))
                {
                    day = (DayOfFood)deserializer.Deserialize(sr);
                    sr.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                day = null;
                return false;
            }
        }

        public static bool TryWriteMeal(string path, Meal meal)
        {
            if (!Directory.Exists(Path.GetDirectoryName(path))) Directory.CreateDirectory(Path.GetDirectoryName(path));
            try
            {
                XmlSerializer serializer= new XmlSerializer(typeof(Meal));
                using(TextWriter tw = new StreamWriter(path))
                {
                    serializer.Serialize(tw, meal);
                }
                return true;

            }
            catch (Exception e)  
            {
                MessageBox.Show(e.Message);
                return false;
            }

        }

        public static bool TryLoadMeal(string path, out Meal meal)
        {
            if (!Directory.Exists(Path.GetDirectoryName(path))) { meal = null; return false; }

            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(Meal));

                using(StreamReader sr = new StreamReader(path))
                {
                    meal = (Meal)deserializer.Deserialize(sr);
                    sr.Close();
                    return true;
                }
            }
            catch(Exception e)
            {
                meal = null;
                MessageBox.Show(e.Message);
                return false;
            }
        }

        public static bool TryWriteFood(string path, FoodItem fi)
        {
            if (!Directory.Exists(Path.GetDirectoryName(path))) Directory.CreateDirectory(Path.GetDirectoryName(path));
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(FoodItem));

                using(TextWriter tw = new StreamWriter(path))
                {
                    serializer.Serialize(tw, fi);
                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }

        }

        public static bool TryLoadFood(string path, out FoodItem foodItem)
        {
            if (!Directory.Exists(Path.GetDirectoryName(path))) { foodItem = null; return false; }

            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(FoodItem));

                using (StreamReader sr = new StreamReader(path))
                {
                    foodItem = (FoodItem)deserializer.Deserialize(sr);
                    sr.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                foodItem = null;
                MessageBox.Show(e.Message);
                return false;
            }
        }





    }
}
