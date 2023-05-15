using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace shappingCardInMVC.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid UserId { get; set; }

        [Required(ErrorMessage ="please enter User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="please enter Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage ="please enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name ="Confirm password")]
        [Required(ErrorMessage = "please enter Confirm Password")]
        [Compare("Password",ErrorMessage ="Confirm password doesn't match,type again !")]
        [DataType(DataType.Password)]
        [NotMapped]
        public string ConfirmPassword { get; set;}

        [ForeignKey("RoleMaster")]
        public int RoleMasterId { get; set; }
        public virtual RoleMaster RoleMaster { get; set; }

    }
}