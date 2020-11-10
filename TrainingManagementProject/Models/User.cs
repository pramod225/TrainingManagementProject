using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrainingManagementProject.Models
{
    public class User
    {

        public int id { get; set; }
        [Display(Name = "User Name")]
        [Required]
        public string UserName { get; set; }
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required]
        public string UserPassword { get; set; }
        [Display(Name = "First Name")]
        [Required]
        public string UserFirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        public string UserLastName { get; set; }
        [Display(Name = "Date of Joining")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime UserDateOfJoining { get; set; }
        [Display(Name = "Email Id")]
        [DataType(DataType.EmailAddress)]
        public string UserEmailId { get; set; }
        [Display(Name = "Role Id")]
        public int RoleId { get; set; }
        [Display(Name = "Manager Id")]
        public int ManagerId { get; set; }
    }
}