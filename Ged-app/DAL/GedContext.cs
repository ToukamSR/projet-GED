using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ged_app.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Ged_app.DAL
{
    public class GedContext : DbContext
    {
        public GedContext() : base("GedContext")
        {
        }

        public DbSet<User> Users { get; set; }
    } 
}