using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounterProject.Core.DTOs
{
    public class RelationshipTypeDto
    {

        public int Id { get; set; }


        [Required(ErrorMessage = "{0} alanı gereklidir")]
        public string Type { get; set; }


    }
}
