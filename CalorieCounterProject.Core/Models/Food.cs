using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounterProject.Core.Models
{
    public class Food
    {
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public int Kcal { get; set; }
        public float Carb { get; set; }
        public float Protein { get; set; }
        public float Fat { get; set; }
        public DateTime RegisterDate { get; set; }
        public string Note { get; set; }
        public bool IsDeleted { get; set; }
    }
}
