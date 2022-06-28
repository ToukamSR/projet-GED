using Ged_app.Models;
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
        public RedirectToRouteResult Create(directory newDir )
        {
            Db.directories.Add(newDir);
            Db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Index()
        {
            List<directory> directories = Db.directories.Where(dir => dir.isDeletedD == 0).ToList();

            return View(directories);

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