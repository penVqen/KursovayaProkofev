using Kursovaya.Pages;
using System;

namespace Kursovaya.Services
{
    public class RscCalculator
    {
        public double CalculateRsc(int age, double weight, double height, string gender, string goal, string activityLevel)
        {
            // Для мужчин
            if (gender.ToLower() == "мужской")
            {
                // Формула Харриса-Бенедикта для мужчин: (88.362 + (13.397 * вес в кг) + (4.799 * рост в см) - (5.677 * возраст в годах)) * коэффициент активности
                double bmr = (88.362 + (13.397 * weight) + (4.799 * height) - (5.677 * age)) * GetActivityFactor(activityLevel);
                return AdjustRscForGoal(bmr, goal);
            }
            // Для женщин
            else if (gender.ToLower() == "женский")
            {
                // Формула Харриса-Бенедикта для женщин: (447.593 + (9.247 * вес в кг) + (3.098 * рост в см) - (4.330 * возраст в годах)) * коэффициент активности
                double bmr = (447.593 + (9.247 * weight) + (3.098 * height) - (4.330 * age)) * GetActivityFactor(activityLevel);
                return AdjustRscForGoal(bmr, goal);
            }
            else
            {
                throw new ArgumentException("Неверно указан пол. Пожалуйста, укажите 'Мужской' или 'Женский'.");
            }
        }

        // коэффициент активности
        private double GetActivityFactor(string activityLevel)
        {
            switch (activityLevel.ToLower())
            {
                case "сидячий":
                    return 1.2;
                case "малоактивный":
                    return 1.375;
                case "активный":
                    return 1.55;
                default:
                    throw new ArgumentException("Неверно указан уровень активности. Пожалуйста, укажите 'Сидячий', 'Малоактивный' или 'Активный'.");
            }
        }

        // цель диеты
        private double AdjustRscForGoal(double bmr, string goal)
        {
            switch (goal.ToLower())
            {
                case "сохранение веса":
                    return bmr;
                case "потеря веса":
                    return bmr - (bmr * 0.2); // дефицит калорий: 20%
                case "набор веса":
                    return bmr + (bmr * 0.2); // избыток калорий: 20%
                default:
                    throw new ArgumentException("Неверно указана цель диеты. Пожалуйста, укажите 'Сохранение веса', 'Потеря веса' или 'Набор веса'.");
            }
        }
    }
}
