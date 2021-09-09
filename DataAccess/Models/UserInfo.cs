using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Models
{
    public class UserInfo
    { 
        [Key]
        public int UserID { get; set; }


        [Required(ErrorMessage = "Name is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Role is required")]
        public string Role { get; set; }

        public string Token { get; set; }
    }
}
