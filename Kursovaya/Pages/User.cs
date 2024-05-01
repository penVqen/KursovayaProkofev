using System;
using System.ComponentModel.DataAnnotations;

namespace Kursovaya.Pages
{
    public class User
    {
        public int ID { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        public string? Gender { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
    }
}
