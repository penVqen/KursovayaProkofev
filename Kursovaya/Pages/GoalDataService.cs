using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Kursovaya.Pages
{
    public class GoalDataService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly GoalHistoryService _goalHistoryService;

        public GoalDataService(ApplicationDbContext dbContext, GoalHistoryService goalHistoryService)
        {
            _dbContext = dbContext;
            _goalHistoryService = goalHistoryService;
        }

        public async Task<bool> CreateGoalAsync(int userId, string dietType, string activityLevel, decimal desiredWeight, DateTime startDate, DateTime endDate)
        {
            bool hasGoal = await HasGoalAsync(userId);

            if (hasGoal)
            {
                return false;
            }

            if (dietType == "Выбрать" || activityLevel == "Выбрать")
            {
                return false;
            }

            GoalBD newGoal = new GoalBD
            {
                ID = userId,
                Type = dietType,
                Active = activityLevel,
                Weight = desiredWeight,
                Start = startDate,
                End = endDate
            };

            _dbContext.Goals.Add(newGoal);
            await _dbContext.SaveChangesAsync();

            return true;
        }


        public async Task<bool> DeleteGoalAsync(int userId)
        {
            var goal = await _dbContext.Goals.FirstOrDefaultAsync(g => g.ID == userId);
            if (goal != null)
            {
                await _goalHistoryService.AddGoalToHistoryAsync(goal);

                _dbContext.Goals.Remove(goal);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> HasGoalAsync(int userId)
        {
            var goal = await _dbContext.Goals.FirstOrDefaultAsync(g => g.ID == userId);
            return goal != null;
        }

        public async Task<GoalBD> GetGoalAsync(int userId)
        {
            return await _dbContext.Goals.FirstOrDefaultAsync(g => g.ID == userId);
        }
    }
}
