using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonFormat
{
    // version 13.06 changed
    class JsonHelper
    {
        public static string FormatJson(string str, string tab = "\t")
        {
            DirectoryInfo mydir = new DirectoryInfo(str);
            string json = "";
            json += GetDirectoryInfo(tab, mydir);
            
            json += GetFilesInfo(tab, mydir);
            json += "\n";
            json += GetSubDirectoriesInfo(tab, mydir);

            json += "\n\t]";
            json += "\n}";
            return json;

        }

        private static string GetSubDirectoriesInfo(string tab, DirectoryInfo mydir)
        {
            string json = "";
            json += tab + "\"Children\": [";

            DirectoryInfo[] d = mydir.GetDirectories();
            foreach (var directory in d)
            {
                json += "\n\t\t";
                json += GetDirectoryInfo(tab, directory);

                json += GetFilesInfo(tab, directory);
                
                json += "\n";
                
                json += GetSubDirectoriesInfo(tab+"\t5555", directory);
                //Console.WriteLine(directory);
                //json += "\n" + tab + JsonHelper.FormatJson(directory.FullName, tab = "\t\t");
                //when subfolder == null!!!! 
                //write ] ] ] ...]
            }
            return json;
        }

        private static string GetFilesInfo(string tab, DirectoryInfo mydir)
        {
            string json = "";
            // getting the files in the directory, their names and size
            FileInfo[] f = mydir.GetFiles();
            json += tab + "\"Files\": [";
            if (f.Length > 0)
            {
                foreach (FileInfo file in f)
                {
                    json += "\n" + tab + "\t{\n";
                    json += tab + "\t\t\"Name\": " + "\"" + file.Name + "\",\n";
                    json += tab + "\t\t\"Size\": " + "\"" + file.Length + " B\",\n";
                    json += tab + "\t\t\"Path\": " + "\"" + file.FullName + "\"\n";
                    json += tab + "\t},";
                }
                json += "\n";
            }
            json += tab + "],";
            return json;
        }

        private static string GetDirectoryInfo(string tab, DirectoryInfo mydir)
        {
            string json = "{\n";
            json += tab + "\"Name\": " + "\"" + mydir.Name + "\",\n";
            json += tab + "\"DateCreated\": " + "\"" + mydir.CreationTime + "\",\n";
            return json;
        }
    }
}
