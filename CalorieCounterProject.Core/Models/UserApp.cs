using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounterProject.Core.Models
{
    public class UserApp : IdentityUser
    {
        public string City { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime Birthdate { get; set; }
        public float Weight { get; set; }
        public bool Gender { get; set; }
        public string Goal { get; set; }
        public bool IsDeleted { get; set; }

    }
}
