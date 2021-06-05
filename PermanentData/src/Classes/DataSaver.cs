using System;
using System.Collections.Generic;
using System.IO;

namespace PermanentData
{
    /// <summary>
    /// For saving data in storage with simplified methods.
    /// </summary>
    public class DataSaver
    {
        private string _path;
        private string _key;

        public DataSaver(string key, string path = null)
        {
            _key = key;
            _path = path ?? @"C:\permanentData.txt";

            if (!File.Exists(_path) && path == null)
                BasicMethods.CreateFileAndDispose(_path);
        }

        /// <summary>
        /// For saving data
        /// </summary>
        /// <param name="line"></param>
        public void Save(string line)
        {
            BasicMethods.WriteTextToFile(_path, line);
        }

        /// <summary>
        /// For saving data if it is string[]
        /// </summary>
        /// <param name="lines"></param>
        public void Save(string[] lines)
        {
            BasicMethods.WriteTextToFile(_path, lines);
        }

        /// <summary>
        /// For saving data if it is List<string>
        /// </summary>
        /// <param name="lines"></param>
        public void Save(List<string> lines)
        {
            Save(lines.ToArray());
        }

        /// <summary>
        /// Reads file and returns as string[]
        /// </summary>
        /// <returns>string[]</returns>
        public string[] Read()
        {
            return BasicMethods.ReadFromFile(_path);
        }

        /// <summary>
        /// Reads file and returns all lines as list
        /// </summary>
        /// <returns>List</returns>
        public List<string> ReadAsList()
        {
            return BasicMethods.ReadFromFileReturnList(_path);
        }

        /// <summary>
        /// For checking if file created in directory
        /// </summary>
        /// <returns>If file exsists then true</returns>
        public bool Exists()
        {
            return File.Exists(_path);
        }

        /// <summary>
        /// For returning key
        /// </summary>
        /// <returns>string</returns>
        public string GetKey()
        {
            return _key;
        }

        /// <summary>
        /// For returning path
        /// </summary>
        /// <returns>string</returns>
        public string GetPath()
        {
            return _path;
        }

        /// <summary>
        /// For clearing whole file
        /// </summary>
        public void Clear()
        {
            File.WriteAllText(_path, String.Empty);
        }
    }
}