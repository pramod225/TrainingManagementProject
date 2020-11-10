using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Services.Description;

namespace TrainingManagementProject.Models
{
    public class Role
    {
        public int id { get; set; }
        public string RoleName { get; set; }
        public List<User> roles { get; set; }
    }
}