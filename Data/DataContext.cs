using Microsoft.EntityFrameworkCore;
using debt_calculator_api.Models;

namespace debt_calculator_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Configs> Config { get; set; }
        public DbSet<Debts> Debt { get; set; }
        public DbSet<Users> User { get; set; }
    }
}