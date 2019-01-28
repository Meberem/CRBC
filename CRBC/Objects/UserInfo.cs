using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRBC.Objects
{
    public enum UserRole { None, Admin, Worker}
    public class UserInfo
    {
        public string ID { get; set; }
        public string Username { get; set; }
        public string Salt { get; set; }

        [BindProperty]
        [Display(Prompt = "First Name")]
        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 3)]
        [Required(ErrorMessage = "First name must be between 3-50 characters.")]
        public string FirstName { get; set; }

        [BindProperty]
        [Display(Prompt = "Last Name")]
        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 3)]
        [Required(ErrorMessage = "Last name must be between 3-50 characters.")]
        public string LastName { get; set; }
        public UserRole Role { get; set; }
    }
}
