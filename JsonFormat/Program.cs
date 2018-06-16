using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonFormat
{
    class Program
    {
        static void Main(string[] args)
        {
            string mydir = @"C:\Users\bohda\Desktop\danya";

            string json = JsonHelper.FormatJson(mydir);
            Console.WriteLine(json);

            Console.ReadKey();
        }
        
    }
}
