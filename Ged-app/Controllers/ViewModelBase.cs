using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ged_app.Controllers
{
    public class ViewModelBase
    {
        public Ged_app.Models.user oneUser { get; set; }
        public IEnumerable<Ged_app.Models.user> listUsers { get; set; }

    }
}