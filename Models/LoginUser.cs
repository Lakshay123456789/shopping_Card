using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace shappingCardInMVC.Models
{
    public class LoginUser
    {
        [Required(ErrorMessage ="please Enter UserName")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="please Enter Password")]
        [DataType(DataType.Password)]

        public string Password { get; set; }
    }
}