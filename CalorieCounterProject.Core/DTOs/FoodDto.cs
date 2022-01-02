using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CalorieCounterProject.Core.DTOs
{
    public class FoodDto
    {
        public int FoodId { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir")]
        public string FoodName { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir")]
        public string UrlName { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "{0} alanı 0'dan büyük bir değer olmalıdır.")]
        public int Kcal { get; set; }

        [Range(0, float.MaxValue, ErrorMessage = "{0} alanı 0'dan büyük bir değer olmalıdır.")]
        public float Carb { get; set; }

        [Range(0, float.MaxValue, ErrorMessage = "{0} alanı 0'dan büyük bir değer olmalıdır.")]
        public float Protein { get; set; }

        [Range(0, float.MaxValue, ErrorMessage = "{0} alanı 0'dan büyük bir değer olmalıdır.")]
        public float Fat { get; set; }

    }
}
