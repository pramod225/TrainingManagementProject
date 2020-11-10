using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace TrainingManagementProject.Models
{
    public class UserDbContext :DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Role> roles { get; set; }
    }
}