using CalorieCounterProject.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounterProject.Core.DTOs
{
    public class DailyProductIntakeDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir")]
        public int ProductId { get; set; }
        
        [Required(ErrorMessage = "{0} alanı gereklidir")]
        public Guid UserId { get; set; }

        [Range(0, float.MaxValue, ErrorMessage = "{0} alanı 0'dan büyük bir değer olmalıdır.")]
        public float PortionSize { get; set; }
        public TypeOfIntake IntakeType { get; set; }

        public DateTime Date { get; set; }

    }
}
