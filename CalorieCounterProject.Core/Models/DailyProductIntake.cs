using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounterProject.Core.Models
{
    public class DailyProductIntake
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Guid UserId { get; set; }
        public float PortionSize { get; set; }
        public TypeOfIntake IntakeType { get; set; }
        public DateTime Date { get; set; }

    }
}
