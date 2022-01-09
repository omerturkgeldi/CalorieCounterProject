using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounterProject.Core.DTOs
{
    public class DailyActivityClientDto
    {
        public int Id { get; set; }
        public int ActivityId { get; set; }
        public int Minutes { get; set; }
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        public string SpecificMotion { get; set; }
        public float Weight { get; set; }
        public float METValue { get; set; }

    }
}
