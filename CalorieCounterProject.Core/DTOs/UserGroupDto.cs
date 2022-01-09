using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounterProject.Core.DTOs
{
    public class UserGroupDto
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir")]
        public Guid UserId { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir")]
        public int GroupId { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir")]
        public int RelationshipTypeId { get; set; }
        
        public DateTime DateAdded { get; set; }



    }
}
