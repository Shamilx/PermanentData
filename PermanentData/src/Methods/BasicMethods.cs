using System;
using System.IO;
using System.Collections.Generic;


namespace PermanentData
{
    internal static class BasicMethods
    {
        public static void CreateFileAndDispose(string path) => File.Create(path).Dispose();
        public static FileStream CreateFileReturnFileStream(string path) => File.Create(path);


        public static void WriteTextToFile(string path, string line)
        {
            using (StreamWriter obj = new StreamWriter(path,true))
            {
                obj.WriteLine(line);
            }
        }

        public static void WriteTextToFile(string path, string[] lines)
        {
            using (StreamWriter obj = new StreamWriter(path,true))
            {
                foreach (var i in lines)
                {
                    obj.WriteLine(i);
                }
            }
        }

        public static string[] ReadFromFile(string path) => File.ReadAllLines(path);
        public static List<string> ReadFromFileReturnList(string path) => new List<string>(ReadFromFile(path));
        
    }
}