using Ged_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.IO;
using System.Data.Entity.Infrastructure;
using System.Web.Script.Serialization;
using Microsoft.Ajax.Utilities;
using System.Web.Services;

namespace Ged_app.Controllers
{
    public class UserController : Controller
    {
        public db_gedEntities Db = new db_gedEntities();

        [HttpGet]
        public ActionResult Create()
        {
            var Status = Db.usergroups.ToList();
            SelectList list = new SelectList(Status, "idGroup", "GroupName");
            ViewBag.Status = list;
            return View();
        }


        public ActionResult Login()
        {
            //ViewBag.Status = list;
            ViewBag.DisErrMsg = 0;
            return View();
        }

        [HttpPost]
        public ActionResult Login(user user)
        {
            string pwdC = cryptDPW(user.password);

            if (Db.users.Any(u => u.email == user.email && u.password == pwdC))
            {
                Response.Cookies["UserIdCookies"].Value = Db.users.Where(u => u.email == user.email && u.password == pwdC).FirstOrDefault().idUser.ToString();

                return Redirect("/Home/Index");
            }
            ViewBag.DisErrMsg = 1;

            //ViewBag.ErrorMessage = "Email Or Password are incorrect! Try again."
            ViewBag.ErrorMessage = "Email or Password are incorrect!";
            return View();
            //ViewBag.Status = list;
          
        }

        [WebMethod]
        public void getUser(int idUser)
        {
            var us = Db.users.Find(idUser);

            //ViewBag.userToEdit = us;
            //return Redirect("/User/Index");


            userMap userMap = new userMap
            {
                idUser = us.idUser,
                idGroup = us.idGroup,
                name = us.name,
                surname = us.surname,
                email = us.email,
                password = us.password,
                avatarUrl = us.avatarUrl
            };

            JavaScriptSerializer js = new JavaScriptSerializer();
            Response.Write(js.Serialize(userMap));

            //return Redirect("/User/Index");
        }

        [HttpPost]
        public RedirectResult Index(user newUser, HttpPostedFileBase avatarFile)
        {

            string fileName = null;
            //if (Db.users.Find(newUser.idUser)==null)
            if (Db.users.Any(u => u.idUser == newUser.idUser))
            {
                // UPDATE 

                user editedUser = Db.users.Find(newUser.idUser);
                if (avatarFile != null)
                {
                    string path = Path.Combine(Server.MapPath("~/App_Data/avatars"), Path.GetFileName(avatarFile.FileName));
                    avatarFile.SaveAs(path);
                    fileName = Path.GetFileName(path);
                    newUser.avatarUrl = fileName;
                }
                DbEntityEntry<user> userEntry = Db.Entry(editedUser);

                userEntry.State = System.Data.Entity.EntityState.Modified;

                userEntry.CurrentValues.SetValues(newUser);

            }
            else
            {

                //ADD
                if (avatarFile != null)
                {
                    string path = Path.Combine(Server.MapPath("~/App_Data/avatars"), Path.GetFileName(avatarFile.FileName));
                    avatarFile.SaveAs(path);
                    fileName = Path.GetFileName(path);
                    newUser.avatarUrl = fileName;
                }

                newUser.password = cryptDPW(newUser.password);
                Db.users.Add(newUser);
            }

            Db.SaveChanges();

            return Redirect("/User/Index");
        }

        private string cryptDPW(string password)
        {
            if (String.IsNullOrEmpty(password))
            {
                return String.Empty;
            }

            // Uses SHA256 to create the hash
            using (var sha = new System.Security.Cryptography.SHA256Managed())
            {
                // Convert the string to a byte array first, to be processed
                byte[] textBytes = System.Text.Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha.ComputeHash(textBytes);

                // Convert back to a string, removing the '-' that BitConverter adds
                string hash = BitConverter
                    .ToString(hashBytes)
                    .Replace("-", String.Empty);

                return hash;
            }
        }

        public ActionResult Index()
        {
            ViewBag.Title = "User list";
            List<user> users = Db.users.ToList();

            var Status = Db.usergroups.ToList();
            SelectList list = new SelectList(Status, "idGroup", "GroupName");
            ViewBag.Status = list;
            return View(users);
        }

        public RedirectToRouteResult Delete(int id)
        {
            user user = Db.users.Find(id);
            Db.users.Remove(user);
            Db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            user user = Db.users.Find(id);
            return View(user);
        }

        [HttpPost]
        public RedirectToRouteResult Edit(int id, user updatedUser)
        {
            user editedUser = Db.users.Find(id);
            DbEntityEntry<user> userEntry = Db.Entry(editedUser);

            userEntry.State = System.Data.Entity.EntityState.Modified;

            userEntry.CurrentValues.SetValues(updatedUser);
            Db.SaveChanges();

            return RedirectToAction("Index");
        }

        class userMap
        {
            public int idUser { get; set; }
            public int idGroup { get; set; }
            public string name { get; set; }
            public string surname { get; set; }
            public string email { get; set; }
            public string password { get; set; }
            public string avatarUrl { get; set; }
        }
    }
}