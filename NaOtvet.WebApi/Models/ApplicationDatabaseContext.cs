﻿using Microsoft.EntityFrameworkCore;
using NaOtvet.Api.Models;

namespace NaOtvet.WebApi.Models
{
    public class ApplicationDatabaseContext : DbContext
    {
        public DbSet<ApplicationVersion> ApplicationVersions { get; set; }
        public DbSet<Download> Downloads { get; set; }
        public DbSet<WebLink> WebLinks { get; set; }
        public DbSet<WebSiteAccount> WebSitesAccounts { get; set; }
        public DbSet<SolvedTestSession> SolvedTestsSessions { get; set; }

        public ApplicationDatabaseContext() : base()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=remotemysql.com;Port=3306;Database=YmMyoN4FGA;Uid=YmMyoN4FGA;Pwd=LJ1MqhpXTH;");
        }
    }
}