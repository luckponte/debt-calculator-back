using Microsoft.EntityFrameworkCore;
using debt_calculator_api.Models;
using debt_calculator_api.Services;

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
            // Seed do "banco"
            // Cria configurações iniciais
            modelBuilder.Entity<Configs>()
            .HasData(new Configs()
                { 
                    configId = 1, 
                    maxParcels = 3, 
                    interestRate = 0.2, 
                    comission = .1
                }
            );

            // Cria usuários
            modelBuilder.Entity<Users>()
            .HasData(new Users()
                {
                    userId = 1,
                    email = "test.user@paschoalotto.com",
                    passwd = EncryptionService.PBKDF2Hash("123Mudar"),
                    isAdmin = false,
                    fullName = "Usuário de Teste"
                }
            );

            modelBuilder.Entity<Users>()
            .HasData(new Users()
                {
                    userId = 2,
                    email = "test.admin@paschoalotto.com",
                    passwd = EncryptionService.PBKDF2Hash("321Mudar"),
                    isAdmin = true,
                    fullName = "Admin de Teste"
                }
            );

            // Cria Dívidas
            modelBuilder.Entity<Debts>()
            .HasData(new Debts()
                {
                    debtId = 1,
                    debtValue = 1000.00,
                    deadlineDate = 1591476827000,
                    userId = 1,
                    phone = "(14) 3225-8554"
                }
            );

            modelBuilder.Entity<Debts>()
            .HasData(new Debts()
                {
                    debtId = 2,
                    debtValue = 2200.00,
                    deadlineDate = 1592254427000,
                    userId = 1,
                    phone = "(14) 3225-8554"
                }
            );
            
            modelBuilder.Entity<Debts>()
            .HasData(new Debts()
                {
                    debtId = 3,
                    debtValue = 3500.00,
                    deadlineDate = 1596142427000,
                    userId = 1,
                    phone = "(14) 3225-8554"
                }
            );
        }
    }
}