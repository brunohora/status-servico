using Microsoft.EntityFrameworkCore;
using STATUS.API.Models;
using Microsoft.Extensions.Configuration;

namespace STATUS.API.Repository
{
    public class BaseContext : DbContext
    {
        private static string ConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionString").Value;
        public BaseContext() : base(GetOptions(ConnectionString))
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StatusServico>()
                .HasKey(status => status.Id);
        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }

        public virtual DbSet<StatusServico> StatusServico { get; set; }
        public virtual DbSet<ServicosCompartilhados> ServicoCompartilhado { get; set; }
    }
}
