using Ged_app.Models;
using Ged_app.MyModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Ged_app.Controllers
{
    public class DirectoryController : Controller
    {
        public db_gedEntities Db = new db_gedEntities();
        // GET: Directory
        public RedirectToRouteResult Create(directory newDir)
        {
            Db.directories.Add(newDir);
            Db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Index(int idD = 0)
        {
            List<directory> directories = new List<directory>();
            List<file> files = new List<file>();

            List<DirFile> dirFiles = new List<DirFile>();

            // del = 0 && idDirRef = null IF INDEX
            if (idD == 0)
            {
                // FOR MAIN DIRECTORIES
                directories = Db.directories.Where(dir => dir.isDeletedD == 0 && dir.Dir_idDirectory == null).ToList();

                //
                foreach (directory directory in directories)
                {
                    DirFile dirFile = new DirFile();

                    dirFile.getDirObj(directory);

                    dirFiles.Add(dirFile);
                }

                ViewBag.isMainDir = "0";

                return View(dirFiles);
            }
            else
            {
                // FOR SUB DIRECTORIES
                directories = Db.directories.Where(dir => dir.isDeletedD == 0 && dir.Dir_idDirectory == idD).ToList();
                files = Db.files.Where(f => f.isDeletedF == 0 && f.idDirectory == idD).ToList();

                // 
                foreach (file file in files)
                {
                    DirFile dirFile = new DirFile();

                    dirFile.getFileObj(file);

                    dirFiles.Add(dirFile);
                }

                //
                foreach (directory directory in directories)
                {
                    DirFile dirFile = new DirFile();

                    dirFile.getDirObj(directory);

                    dirFiles.Add(dirFile);
                }


                ViewBag.isMainDir = "1";
                return View(dirFiles);
            }

        }

        public RedirectToRouteResult Delete(int idDirectory)
        {
            directory deletedDir = Db.directories.Find(idDirectory);
            deletedDir.isDeletedD = 1;
            DbEntityEntry<directory> directoryEntry = Db.Entry(deletedDir);

            directoryEntry.State = System.Data.Entity.EntityState.Modified;
            Db.SaveChanges();

            return RedirectToAction("Index");
        }

        public RedirectToRouteResult Edit(int idDirectory, string DirectoryName)
        {
            directory editedDir = Db.directories.Find(idDirectory);
            editedDir.DirectoryName = DirectoryName;
            DbEntityEntry<directory> directoryEntry = Db.Entry(editedDir);

            directoryEntry.State = System.Data.Entity.EntityState.Modified;
            Db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}