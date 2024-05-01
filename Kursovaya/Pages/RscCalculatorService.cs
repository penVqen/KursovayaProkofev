using Kursovaya.Pages;
using System;
using Kursovaya.Services;

namespace Kursovaya.Services
{
    public class RscCalculatorService
    {
        private readonly ApplicationDbContext _dbContext;

        public RscCalculatorService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int CalculateRsc(int userId)
        {
        
            var user = _dbContext.Users.FirstOrDefault(u => u.ID == userId);

            if (user == null)
            {
                
                return 0;
            }

            
            var goal = _dbContext.Goals.FirstOrDefault(g => g.ID == userId);

            
            if (goal == null)
            {
                
                return 0;
            }

            
            int age = CalculateAge(user.Birthday);

           
            decimal rscDecimal = CalculateRscFromData(age, user.Weight, user.Height, user.Gender, goal.Type, goal.Active);

            
            int rsc = (int)Math.Round(rscDecimal);

            return rsc;
        }

        
        private int CalculateAge(DateTime birthday)
        {
            DateTime now = DateTime.Now;
            int age = now.Year - birthday.Year;
            if (now < birthday.AddYears(age)) age--;

            return age;
        }

        private decimal CalculateRscFromData(int age, decimal weight, decimal height, string gender, string goalType, string activityLevel)
        {
            
            var rscCalculator = new RscCalculator();

            
            double rsc = rscCalculator.CalculateRsc((int)age, (double)weight, (double)height, gender, goalType, activityLevel);

            
            return (decimal)rsc;
        }
    }
}
