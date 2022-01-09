using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounterProject.Core.DTOs
{
    public class AllFoodsAndProductsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Type { get; set; } // 0 => food , 1 => product
        public int Kcal { get; set; }
        public float Carb { get; set; }
        public float Protein { get; set; }
        public float Fat { get; set; }

    }
}
