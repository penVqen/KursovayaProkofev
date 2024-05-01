using System;
using System.ComponentModel.DataAnnotations;

namespace Kursovaya.Pages
{
    public class GoalHistory
    {
        [Key]
        public int ID_Goal { get; set; }

        public int ID { get; set; }

        public string Type { get; set; }

        public string Active { get; set; }

        public decimal Weight { get; set; }

        public decimal CurrentBMI { get; set; }

        public decimal ExpectedBMI { get; set; }

        [DataType(DataType.Date)]
        public DateTime Start { get; set; }

        [DataType(DataType.Date)]
        public DateTime End { get; set; }
    }
}
