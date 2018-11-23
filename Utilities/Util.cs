using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitiess;

namespace Utilities
{
    public static class Util
    {
        /// <summary>
        /// Method to split each word in line
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static string[] SplitLineBySpace(string line)
        {
            var eachLine = line.Split(Constants.SPACE);
            return eachLine;
        }

        public static int ToInt(string integer)
        {
            return Convert.ToInt32(integer);
        }


        public static double ToDouble(string integer)
        {
            return Convert.ToDouble(integer);
        }

        public static bool ToBoolean(string str)
        {
            return Convert.ToBoolean(str);
        }

        public static string[] ReadFile(string path)
        {
            try
            {
                var inputData = File.ReadAllLines(path);
                return inputData;
            }
            catch
            {
                throw new Exception();
            }
            
        }

        public static void WriteFile(string data, string path)
        {
            try
            {
                File.WriteAllText(path, data);
            }
            catch
            {
                throw new Exception();
            }
        }

   

        public static bool FileExists(string path)
        {
            return File.Exists(path);
        }

        public static string AsString(this int str)
        {
            return str.ToString();
        }

        public static string AsString(this double str)
        {
            return str.ToString();
        }

        public static string AsString(this bool str)
        {
            return str.ToString();
        }

        public static string AsString(this char str)
        {
            return str.ToString();
        }
    }
}
