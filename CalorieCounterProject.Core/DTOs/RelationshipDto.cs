using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounterProject.Core.DTOs
{
    public class RelationshipDto
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir")]
        public Guid UserId_1 { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir")]
        public Guid UserId_2 { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir")]
        public int RelationshipTypeId { get; set; }
        public DateTime CreatedAt { get; set; }


    }
}
