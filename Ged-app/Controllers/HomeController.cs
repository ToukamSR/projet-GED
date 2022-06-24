using Ged_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ged_app.Controllers
{
    public class HomeController : Controller
    {
        public db_gedEntities Db = new db_gedEntities();

        public ActionResult Index()
        {
            //string idU = Response.Cookies["UserIdCookies"].Value;
            string idU = Request.Cookies["UserIdCookies"].Value;
            user U = Db.users.Find(int.Parse(idU));

            //HomeViewModel homeViewModel = new HomeViewModel
            //{
            //    idUser = U.idUser,
            //    idGroup = U.idGroup,
            //    name = U.name,
            //    surname = U.surname,
            //    password = U.password,
            //    avatarUrl = U.avatarUrl,
            //    email = U.email
            //};

            ViewBag.Message = "Your application description page.";
            //return this.View(homeViewModel);
            return this.View();
        }
    }
}
