using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonFormat
{
    //version 14.06
    class JsonHelp
    {
        public static string FormatJson(string str)
        {
            string tab = "\t";
            string json = "";
            DirectoryInfo mydir = new DirectoryInfo(str);

            json += GetInfoDirectory(mydir);
            json += GetFilesInDirectory(mydir);
            json += GetChildrenDirectoryInfo(mydir);

            json += "\n}";
            return json;
        }
        private static string GetInfoDirectory(DirectoryInfo mydir)
        {
            string json;
            string tab = "\t";
            json = "{\n";
            json += tab + "\"Name\": " + "\"" + mydir.Name + "\",\n";
            json += tab + "\"DateCreated\": " + "\"" + mydir.CreationTime + "\",\n";
            json += tab + "\"Files\":";
            return json;
        }
        private static string GetFilesInDirectory(DirectoryInfo directory)
        {
            string json="";
            FileInfo[] f = directory.GetFiles();
            foreach (FileInfo file in f)
            {
                json += "\n" + "\t{\n";
                json += "\t\t\"Name\": " + "\"" + file.Name + "\",\n";
                json += "\t\t\"Size\": " + "\"" + file.Length + " B\",\n";
                json += "\t\t\"Path\": " + "\"" + file.FullName + "\"\n";
                json += "\t},";
            }
            return json;
        }
        private static string GetChildrenDirectoryInfo(DirectoryInfo directory)
        {
            string json = "";
            DirectoryInfo[] d = directory.GetDirectories();
            foreach(var dir in d)
            {
                json += "\n"+"\t\"Children\":\n";
                json += GetInfoDirectory(dir);
                json += GetFilesInDirectory(dir);
                json += GetChildrenDirectoryInfo(dir);
            }

            return json;
        }
    }
}
