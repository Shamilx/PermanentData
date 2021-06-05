using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PermanentData
{
    /// <summary>
    /// This class will create a folder in project for working with data
    /// </summary>
    public static class LocalStorage
    {
        /// <summary>
        /// For saving data as string
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void Save(string key, string value)
        {
            string path = CreateFilesIfPossible();
            
            BasicMethods.WriteTextToFile(path,key + '\0' + value);
        }
        
        /// <summary>
        /// For saving data as string[]
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void Save(string key, string[] value)
        {
            string path = CreateFilesIfPossible();

            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.Write(key + '\0');

                foreach (var i in value)
                {
                    writer.Write(i + '\0');
                }
            }
        }
        
        /// <summary>
        /// For saving data as List<string>
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void Save(string key, List<string> value)
        {
            Save(key,value.ToArray());
        }
        
        /// <summary>
        /// For reading data from file with key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string[] Read(string key)
        {
            string path = Environment.CurrentDirectory + "/permdatabin/data.txt";
            string fileLine = "";
            
            using (StreamReader reader = new StreamReader(path))
            {
                while ((fileLine = reader.ReadLine()) != null)
                {
                    if (key == fileLine.Substring(0, fileLine.IndexOf('\0')))
                    {
                        string[] allLine = fileLine.Split('\0');
                        reader.Dispose();
                        return allLine.Where(x => x != key).ToArray();
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// For clearing whole data
        /// </summary>
        public static void Clear()
        {
            string path = Environment.CurrentDirectory + "/data.txt";
            
            File.WriteAllText(path, String.Empty);
        }

        public static bool Remove(string key)
        {
            string path = Environment.CurrentDirectory + "/permdatabin/data.txt";
            string fileLine = "";

            List<string> LineInFiles = File.ReadAllLines(path).ToList();

            int count = 0;
            bool found = false;
            
            using (StreamReader reader = new StreamReader(path))
            {
                while ((fileLine = reader.ReadLine()) != null)
                {
                    if (key == fileLine.Substring(0, fileLine.IndexOf('\0')))
                    {
                        reader.Dispose();
                        found = true;
                        break;
                    }
                    
                    count++;
                }
            }

            if (found == false) return false;
            
            LineInFiles.RemoveAt(count);
            File.WriteAllLines(path,LineInFiles);
            return true;
        }
        
        
        /// <summary>
        /// For creating necessary files
        /// </summary>
        private static string CreateFilesIfPossible()
        {
            string path = Environment.CurrentDirectory + "/permdatabin";
            
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (!File.Exists(path + "/data.txt"))
            {
                BasicMethods.CreateFileAndDispose(path + "/data.txt");
            }

            return (path + "/data.txt");
        }
        
        
    }
}