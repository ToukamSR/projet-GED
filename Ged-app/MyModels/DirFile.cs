using Ged_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ged_app.MyModels
{
    public class DirFile
    {
        public int id { get; set; }
        public string name { get; set; }
        public string author { get; set; }
        public string nbrFile { get; set; } = "/";
        public string nbrDir { get; set; } = "/";
        public DateTime creationDate { get; set; }

        public DirFile()
        {

        }

        public void getFileObj(file f)
        {
            id = f.idFile;
            name = f.Name;
            author = f.user.name;
            creationDate = f.dateCreationF;
        }

        public void getDirObj(directory dir)
        {
            id = dir.idDirectory;
            name = dir.DirectoryName;
            author = dir.user.name;
            nbrFile = dir.files.Count().ToString();
            nbrDir = dir.directory1.Count().ToString();
            creationDate = dir.dateCreationD;
        }

    }
}