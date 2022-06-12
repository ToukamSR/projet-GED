using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ged_app.Models;

namespace Ged_app.DAL
{
    public class GedInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<GedContext>
    {
    }
}