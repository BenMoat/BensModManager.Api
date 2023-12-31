﻿namespace BensModManager.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;Database=BensModManagerTestTEMP;Trusted_Connection=true;TrustServerCertificate=true;");
        }

        public DbSet<Mod> Mods { get; set; }
    }
}
