using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CalorieCounterProject.Core.DTOs
{
    public class ActivityDto
    {
        public int ActivityId { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir")]
        public string Name { get; set; }

        public string SpecificMotion { get; set; }

        [Range(0, float.MaxValue, ErrorMessage = "{0} alanı 0'dan büyük bir değer olmalıdır.")]
        public float METValue { get; set; }

    }
}
