using System.ComponentModel.DataAnnotations;

namespace Kursovaya.Pages
{
    public class PaxdBD
    {
        [Key]
        public int ID_Paxd { get; set; }
        public string Name { get; set; }
        public double Caloric { get; set; }
        public double Proteins { get; set; }
        public double Fats { get; set; }
        public double Carbohydrates { get; set; }
    }
}
