using Microsoft.EntityFrameworkCore;
using System;

namespace Kursovaya.Pages
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<GoalBD> Goals { get; set; }
        public DbSet<PaxdBD> Paxds { get; set; }
        public DbSet<PadBD> Pads { get; set; }
        public DbSet<GoalHistory> GoalsHistory { get; set; }
    }
}
