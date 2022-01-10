using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounterProject.Core.DTOs
{
    public class UserAppDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public DateTime Birthdate { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
        public bool Gender { get; set; }
        public byte ActivityFactor { get; set; }
        public string Goal { get; set; }
        public bool IsDeleted { get; set; }

    }
}
