using Microsoft.EntityFrameworkCore;
using Uva.ProjetoFinal.Models;

namespace Uva.ProjetoFinal.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ClientModel> Clients { get; set; }
        public DbSet<AddressModel> Addresses { get; set; }
        public DbSet<BrowsingHistoryModel> BrowsingHistory { get; set; }
        public DbSet<EmailModel> Emails { get; set; }

        //Fluent Api
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ClientModel Configuring
            modelBuilder.Entity<ClientModel>()
                .Property(prop => prop.Name).HasMaxLength(40);

            modelBuilder.Entity<ClientModel>()
                .Property(prop => prop.Cpf).HasMaxLength(11);

            // AddressModel Configuring
            modelBuilder.Entity<AddressModel>()
                .Property(prop => prop.Cep).HasMaxLength(8);

            modelBuilder.Entity<AddressModel>()
                .Property(prop => prop.HomeNumber).HasMaxLength(20);

            //BrowsingHistoryModel Configuring
            modelBuilder.Entity<BrowsingHistoryModel>()
                .Property(prop => prop.Ip).HasMaxLength(12);

            //EmailModel Configuring
            modelBuilder.Entity<EmailModel>()
                .Property(prop => prop.Email).HasMaxLength(40);
        }
    }
}
