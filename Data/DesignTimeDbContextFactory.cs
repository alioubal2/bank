using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace bank.Data
{
    // Factory utilisée par dotnet-ef en design-time
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<BankDbContext>
    {
        public BankDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<BankDbContext>();

            // Lecture de la chaîne de connexion via variable d'environnement (recommandé)
            // OU fallback sur une chaîne par défaut si la variable n'existe pas.
            var conn = Environment.GetEnvironmentVariable("ConnectionStrings__BankDatabase")
                       ?? "Host=localhost;Port=5432;Database=bankdb;Username=postgres;Password=1234";

            builder.UseNpgsql(conn);

            return new BankDbContext(builder.Options);
        }
    }
}
