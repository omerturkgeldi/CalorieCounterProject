using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounterProject.Core.DTOs
{
    public class DailyFoodIntakeDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir")]
        public int FoodId { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir")]
        public Guid UserId { get; set; }

        [Range(0, float.MaxValue, ErrorMessage = "{0} alanı 0'dan büyük bir değer olmalıdır.")]
        public float PortionSize { get; set; }

        public DateTime Date { get; set; }
    }
}
