﻿using System;
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
        public static void FormatJson(string path)
        {
            DirectoryInfo mydir = new DirectoryInfo(path);
            string json = "";
            json += "{";
            json += "\t\"Name\": "+ "\""+ mydir.Name+ "\"\n";
            json += "\t\"DataCreated\": " + "\"" + mydir.CreationTime + "\"\n";
            //json += "\t\"Files\": " + "\"" + mydir.GetFiles
        }
    }
}
