using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounterProject.Core.DTOs
{
    public class GroupDto
    {


        public int Id { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir")]
        public string GroupName { get; set; }

        public DateTime CreatedAt { get; set; }
        public Guid CreatorId { get; set; }


    }
}
