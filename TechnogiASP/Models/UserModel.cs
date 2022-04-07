using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TechnogiASP.Models
{
    public class UserModel
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int? Age { get; set; }

        public UserModel()
        {
            ID = -1;
            Name = "empty";
            Email = "test@test.com";
            Age = null;
        }

        public UserModel(int id, string name, string email, int age)
        {
            ID = id;
            Name = name;
            Email = email;
            Age = age;
        }
    }
}