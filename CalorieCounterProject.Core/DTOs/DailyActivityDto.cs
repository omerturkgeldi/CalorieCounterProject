using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounterProject.Core.DTOs
{
    public class DailyActivityDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir")]
        public int ActivityId { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir")]
        public int Minutes { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir")]
        public Guid UserId { get; set; }

        public DateTime Date { get; set; }


    }
}
