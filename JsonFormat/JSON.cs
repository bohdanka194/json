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
        public static string FormatJson(string path, string tab = "")
        {
            DirectoryInfo mydir = new DirectoryInfo(path);
            string json = "";
            json += tab + "{\n";
            json += tab + "\t\"Name\": " + "\""+ mydir.Name+ "\",\n";
            json += tab + "\t\"DataCreated\": " + "\"" + mydir.CreationTime + "\",\n";
            json += tab + "\t\"Files\": " + "[" + GetInfoFiles(path,tab) + "],\n";
            json += tab + "\t\"Children\": " + "[" + GetInfoChildren(path,tab+"\t\t") + "]\n";
            json += tab + "}";

            return json; 
        }
        public static string GetInfoFiles(string path,string tab ="")
        {
            FileInfo[] files = new DirectoryInfo(path).GetFiles();
            if (files.Length == 0)
            {
                return " ";
            }
            else
            {
                string json = "";
                foreach (var file in files)
                {
                    json += "\n" + tab + "\t   {\n";
                    json += tab + "\t\t\"Name\": " + "\"" + file.Name + "\",\n";
                    json += tab + "\t\t\"Size\": " + "\"" + file.Length + " B\",\n";
                    json += tab + "\t\t\"Path\": " + "\"" + file.FullName + "\"\n";
                    json += tab + "\t   },";
                }
                json += "\n\t" + tab;
                return json;
            }
        }
        public static string GetInfoChildren(string path,string tab ="\t")
        {
            DirectoryInfo[] subdirectories = new DirectoryInfo(path).GetDirectories();
            if (subdirectories.Length == 0)
            {
                return " ";
            }
            else
            {
                string json = "\n";
                foreach (var subdir in subdirectories)
                {
                    json += FormatJson(subdir.FullName, tab);

                    json += ",\n";
                }
                string lessTab= tab.Substring(0, tab.Length - 1);
                json += lessTab;
                return json;
            }
        }
    }
}
