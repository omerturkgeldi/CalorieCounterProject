using CalorieCounterProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounterProject.Core.DTOs
{
    public class DailyCalorieIntakeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Type { get; set; } // food or product
        public Guid UserId { get; set; }
        public int Kcal { get; set; }
        public string BarcodeNo { get; set; }
        public float Carb { get; set; }
        public float Protein { get; set; }
        public float Fat { get; set; }
        public float PortionSize { get; set; }
        public TypeOfIntake IntakeType { get; set; }
        public DateTime Date { get; set; }
    }
}
