using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounterProject.Core.DTOs
{
    public class FriendDto
    {
        public int Id { get; set; }
        public Guid UserId_1 { get; set; }
        public Guid UserId_2 { get; set; }
        public int RelationshipTypeId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string City { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime Birthdate { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
        public string Email { get; set; }
        public bool Gender { get; set; }
        public byte ActivityFactor { get; set; }
        public string Goal { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }


    }
}
