using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounterProject.Core.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string BarcodeNo { get; set; }
        public string ProductName { get; set; }
        public int Kcal { get; set; }
        public float Carb { get; set; }
        public float Protein { get; set; }
        public float Fat { get; set; }
        public float PortionSize { get; set; }
        public DateTime RegisterDate { get; set; }
        public string Note { get; set; }
        public bool IsDeleted { get; set; }
    }
}
