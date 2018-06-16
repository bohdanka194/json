using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonFormat
{
    // version 16.06.2018
    class JSON
    {
        public static string FormatJson(string path)
        {
            DirectoryInfo mydir = new DirectoryInfo(path);
            string json = "";
            json += "{\n";
            json += "\t\"Name\": "+ "\""+ mydir.Name+ "\",\n";
            json += "\t\"DataCreated\": " + "\"" + mydir.CreationTime + "\",\n";
            json += "\t\"Files\": " + "[" + GetInfoFiles(path) + "],\n";
            json += "\t\"Children\": " + "[" + GetInfoChildren(path) + "]\n";
            json += "}";

            return json; 
        }
        public static string GetInfoFiles(string path)
        {
            FileInfo[] files = new DirectoryInfo(path).GetFiles();

            // files.GetLength() or files.Length ???
            //
            // int[,,] a = new int[10, 11, 12];
            // Console.WriteLine(a.Length);           // 1320
            // Console.WriteLine(a.GetLength(0));     // 10
            // Console.WriteLine(a.GetLength(1));     // 11
            // Console.WriteLine(a.GetLength(2));     // 12

            if (files.Length == 0)
            {
                return " 444 ";
            }
            else
            {
                string json = "";
                foreach (var file in files)
                {
                    json += "\n" + "\t   {\n";
                    json += "\t\t\"Name\": " + "\"" + file.Name + "\",\n";
                    json += "\t\t\"Size\": " + "\"" + file.Length + " B\",\n";
                    json += "\t\t\"Path\": " + "\"" + file.FullName + "\"\n";
                    json += "\t   },\n";
                }
                json += "\t";
                return json;
            }
        }
        public static string GetInfoChildren(string path)
        {
            DirectoryInfo[] subdirectories = new DirectoryInfo(path).GetDirectories();
            if (subdirectories.Length == 0)
            {
                return " 555 ";
            }
            else
            {
                string json = "";
                //...
                return json;
            }
        }
    }
}
