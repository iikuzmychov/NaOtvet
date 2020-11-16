using Microsoft.EntityFrameworkCore;
using NaOtvet.ApiClient;

namespace NaOtvet.WebApi.Models
{
    public class ApplicationDatabaseContext : DbContext
    {
        public DbSet<ApplicationVersion> ApplicationVersions { get; set; }
        public DbSet<WebLink> WebLinks { get; set; }
        public DbSet<WebSiteAccount> WebSitesAccounts { get; set; }
        public DbSet<SolvedTestSession> SolvedTestsSessions { get; set; }

        public ApplicationDatabaseContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=remotemysql.com;Port=3306;Database=IVg0ywhIfP;Uid=IVg0ywhIfP;Pwd=fIcY4HxjbB;");
        }
    }
}