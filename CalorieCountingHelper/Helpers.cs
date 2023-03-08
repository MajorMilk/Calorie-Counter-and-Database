using CalorieCountingHelper.Objects;
using System;
using System.Collections.Generic;
using System.Data;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CalorieCountingHelper
{
    public static class Helpers
    {
        public static readonly string[] months = new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        public static string[] ReadAllLinesFromFile(string filePath)
        {
            // Check if the file exists
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("File not found.", filePath);
            }

            // Read all lines from the file
            string[] lines = File.ReadAllLines(filePath);

            // Return the lines
            return lines;
        }

        public static string FilePathFromDate(string date)
        {
            int dateIndex = int.Parse(date.Substring(0, 1)) - 1;
            string Month = months[dateIndex];
            string workingDirectory = Environment.CurrentDirectory;
            //string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            return workingDirectory + $@"\DATA\{Month}\{date.Replace('/', '-').Split(' ')[0]}.xml";
        }

        public static bool DataExists(string date)
        {
            return File.Exists(FilePathFromDate(date));
        }


        public static bool TryWriteDay(DayOfFood day, string path)
        {
            if (File.Exists(path))
            {
                //File.Delete(path);
            }
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
                Console.WriteLine("ERROR: " + ex.Message);
                return false;
            }
        }

        public static bool TryLoadDay(string path, out DayOfFood day)
        {
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
                Console.WriteLine("ERROR: "+ ex.Message);

                day = null;
                return false;
            }
        }



    }
}
