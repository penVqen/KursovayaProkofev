using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Kursovaya.Pages
{
    public class SqliteUserDataService
    {
        private readonly ApplicationDbContext _context;

        public SqliteUserDataService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> RegisterUserAsync(string login, string password, string name, DateTime birthday, string gender, decimal weight, decimal height)
        {
            try
            {
                if (await UserExistsAsync(login))
                {
                    // Пользователь с таким логином уже существует
                    return false;
                }

                var user = new User
                {
                    Login = login,
                    Password = password,
                    Name = name,
                    Birthday = birthday,
                    Gender = gender,
                    Weight = weight,
                    Height = height
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error registering user: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> AuthenticateUserAsync(string login, string password)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Login == login && u.Password == password);
                return user != null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error authenticating user: {ex.Message}");
                return false;
            }
        }

        public async Task<int> GetUserIdAsync(string login)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Login == login);
            return user?.ID ?? -1;
        }

        private async Task<bool> UserExistsAsync(string login)
        {
            return await _context.Users.AnyAsync(u => u.Login == login);
        }
    }
}
