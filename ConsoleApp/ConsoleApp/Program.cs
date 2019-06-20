using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using System.IO;


namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = ClassLibrary.Class1.Change(@"D:\NET\Чистий#\Extension\Test.txt");
            using (StreamWriter strWr = new StreamWriter(new FileStream(@"D:\NET\Чистий#\Extension\Test.txt", FileMode.OpenOrCreate)))
            {
                for (int i = 0; i < list.Count; i++)
                {
                    strWr.WriteLine(list[i]);
                }
            }
            Console.WriteLine("All done successful");
            Console.ReadKey();
        }
    }
}
