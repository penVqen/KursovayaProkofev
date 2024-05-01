using System;
using System.ComponentModel.DataAnnotations;

namespace Kursovaya.Pages
{
    public class PadBD
    {
        [Key]
        public int ID_Pad { get; set; }

        public int ID_Paxd { get; set; }

        public int ID { get; set; }

        public decimal Gram { get; set; }

        public string Category { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
