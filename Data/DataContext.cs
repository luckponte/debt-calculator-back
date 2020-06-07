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

        public DbSet<Configs> Configs { get; set; }
        public DbSet<Debts> Debts { get; set; }
        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Configs>().HasData(new Configs(){ configId = 1, maxParcels = 3, interestRate = 0.2, comission = .1});
        }
    }
}