using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ClassLibrary
{
    public class Class1
    {
        public static Dictionary<string, string> dictionary = new Dictionary<string, string>();
        
        public static List<string> Change(string path)
        {
            FullDictionary(ref dictionary);
            List<string> lines = new List<string>();
            using (StreamReader strRead = new StreamReader(new FileStream(path, FileMode.OpenOrCreate)))
            {
                string str;
                while((str = strRead.ReadLine()) != null)
                {
                    lines.Add(str);
                }
            }
            for (int i = 0; i < lines.Count; i++)
            {
                string[] mass = lines[i].Split(' ');
                for (int j = 0; j < mass.Length; j++)
                {
                    if (dictionary.ContainsKey(mass[j]))
                    {
                        mass[j] = UnicToChar(dictionary[mass[j]]);
                    }
                }
                lines[i] = "";
                for(int j = 0; j < mass.Length; j++)
                {
                    lines[i] += " " + mass[j];
                }
            }
            for (int i = 0; i < lines.Count; i++)
            {
                foreach(KeyValuePair<string, string> keyValue in dictionary)
                {
                    lines[i].Replace(keyValue.Value, keyValue.Key);
                }
            }
            return lines;
        }
        public static void FullDictionary(ref Dictionary<string, string> dictionary)
        {
            using (StreamReader strRead = new StreamReader(new FileStream(@"D:\NET\Чистий#\Extension\FullDict.txt", FileMode.OpenOrCreate)))
            {
                string str;
                while((str = strRead.ReadLine()) != null)
                {
                    string[] mass = str.Split(' ');
                    dictionary.Add(mass[1], mass[0]);
                }
            }
        }
        public static string UnicToChar(string hex)
        {
            int code = int.Parse(hex, System.Globalization.NumberStyles.HexNumber);
            string unicodeStr = char.ConvertFromUtf32(code);
            return unicodeStr;
        }
    }
}
