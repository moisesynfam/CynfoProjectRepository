using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CynfoProject.Models
{
    public class GeneralDBContext : DbContext
    {
        public DbSet<User> UserAccounts { get; set; }
    }
}