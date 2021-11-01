using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Language2.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Full Name")]
        public string Name {  get; set; }
        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage ="Email is not Valid")]
        public string Email {  get; set; }
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime Birthday {  get; set; }

    }

    public static class DB
    {
        public static List<UserModel> Users { get; set; } = new List<UserModel>()
        {
            new UserModel(){Name = "Patka" , Email = "patka@ca.com" , Birthday = new DateTime(1997,12,01)},
            new UserModel(){Name ="Patryk", Email="patryk@ca.com", Birthday = new DateTime(1999,01,01)}

        };
    } 
}
