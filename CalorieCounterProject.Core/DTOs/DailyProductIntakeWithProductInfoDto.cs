using CalorieCounterProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounterProject.Core.DTOs
{
    public class DailyProductIntakeWithProductInfoDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Guid UserId { get; set; }
        public float PortionSize { get; set; }
        public DateTime Date { get; set; }
        public string BarcodeNo { get; set; }
        public string ProductName { get; set; }
        public TypeOfIntake IntakeType { get; set; }
        public int Kcal { get; set; }
        public float Carb { get; set; }
        public float Protein { get; set; }
        public float Fat { get; set; }

    }
}
