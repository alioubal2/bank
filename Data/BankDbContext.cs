using Microsoft.EntityFrameworkCore;
using bank.Models;

namespace bank.Data
{
    public class BankDbContext : DbContext
    {
        public BankDbContext(DbContextOptions<BankDbContext> options) : base(options)
        {
        }

        public DbSet<Agence> Agences { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Compte> Comptes { get; set; }
        public DbSet<Operation> Operations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // =================== AGENCE ===================
            modelBuilder.Entity<Agence>(entity =>
            {
                entity.ToTable("agences");

                // Clé primaire = Code
                entity.HasKey(a => a.Code);

                entity.Property(a => a.Nom)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.Property(a => a.Adresse)
                      .HasMaxLength(300);
            });

            // =================== CLIENT ===================
            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("clients");

                // Clé primaire = Numero
                entity.HasKey(c => c.Numero);

                entity.Property(c => c.Nom)
                      .HasMaxLength(150);

                entity.Property(c => c.Prenom)
                      .HasMaxLength(150);
            });

            // =================== COMPTE ===================
            modelBuilder.Entity<Compte>(entity =>
            {
                entity.ToTable("comptes");

                // Clé primaire = Code
                entity.HasKey(c => c.Code);

                entity.Property(c => c.Solde)
                      .IsRequired();

                entity.HasDiscriminator<string>("TypeCompte")
                      .HasValue<Compte>("Base")
                      .HasValue<CompteEpargne>("Epargne")
                      .HasValue<CompteCourant>("Courant")
                      .HasValue<ComptePayant>("Payant");
            });

            // =================== OPERATIONS ===================
            // Tu me donneras la classe Operation pour la mapper proprement
        }
    }
}
