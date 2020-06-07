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
            // Seed do "banco" gerando usuários e configuraçõies iniciais
            modelBuilder.Entity<Configs>()
            .HasData(new Configs()
                { 
                    configId = 1, 
                    maxParcels = 3, 
                    interestRate = 0.2, 
                    comission = .1
                }
            );

            modelBuilder.Entity<Users>().HasData(new Users(){
                userId = 1,
                email = "test.user@paschoalotto.com",
                passwd = EncryptionService.PBKDF2Hash("123Mudar"),
                isAdmin = false,
                fullName = "Usuário de Teste"
            });

            modelBuilder.Entity<Users>().HasData(new Users(){
                userId = 2,
                email = "test.admin@paschoalotto.com",
                passwd = EncryptionService.PBKDF2Hash("321Mudar"),
                isAdmin = true,
                fullName = "Admin de Teste"
            });
        }
    }
}