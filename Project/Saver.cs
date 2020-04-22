using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Project
{
    class Saver
    {
         internal List<T> Load<T>() where T : class
        {
            var formatter = new BinaryFormatter();
            var fileName = typeof(T).Name;

            using var fs = new FileStream(fileName, FileMode.OpenOrCreate);
            if (fs.Length > 0 && formatter.Deserialize(fs) is List<T> items)
            {
                return items;
            }
            else
            {
                return new List<T>();
            }
        }
        internal void Save<T>(List<T> item) where T : class
        {
            var formatter = new BinaryFormatter();
            var fileName = typeof(T).Name;
            using var fs = new FileStream(fileName, FileMode.OpenOrCreate);
          formatter.Serialize(fs, item);
        }
    }
}
