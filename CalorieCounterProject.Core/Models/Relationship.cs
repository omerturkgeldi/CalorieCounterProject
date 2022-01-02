using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounterProject.Core.Models
{
    public class Relationship
    {

        public int Id { get; set; }
        public Guid UserId_1 { get; set; }
        public Guid UserId_2 { get; set; }
        public int RelationshipTypeId { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }


    }
}
