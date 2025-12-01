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

                // si vous aviez choisi Code comme PK, laissez-le. Sinon adaptez.
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

                // Clé primaire = Id (int)
                entity.HasKey(c => c.Id);

                entity.Property(c => c.Numero).HasMaxLength(100);
                entity.Property(c => c.Nom).HasMaxLength(150);
                entity.Property(c => c.Prenom).HasMaxLength(150);
                entity.Property(c => c.Telephone).HasMaxLength(20);
            });

            // =================== COMPTE ===================
            modelBuilder.Entity<Compte>(entity =>
            {
                entity.ToTable("comptes");

                // Clé primaire = Code
                entity.HasKey(c => c.Code);

                entity.Property(c => c.Solde)
                      .IsRequired();

                // Relation 1 client → 1 compte
                // FK dans Compte.ClientId qui pointe sur Client.Id
                entity.HasOne(c => c.Client)
      .WithOne(c => c.Compte)
      .HasForeignKey<Compte>(c => c.ClientNumero)
      .HasPrincipalKey<Client>(c => c.Numero);


                entity.HasDiscriminator<string>("TypeCompte")
                      .HasValue<Compte>("Base")
                      .HasValue<CompteEpargne>("Epargne")
                      .HasValue<CompteCourant>("Courant")
                      .HasValue<ComptePayant>("Payant");
            });

            // =================== OPERATIONS ===================
            // (Assurez-vous que Operation.cs existe et est publique)
            // modelBuilder.Entity<Operation>(entity =>
            // {
            //     entity.ToTable("operations");
            //     entity.HasKey(o => o.Id);

            //     entity.Property(o => o.Type).IsRequired().HasMaxLength(100);
            //     entity.Property(o => o.Date).IsRequired();
            //     entity.Property(o => o.Montant).IsRequired();

            //     entity.HasOne(o => o.CompteSource)
            //           .WithMany(c => c.Operations)
            //           .HasForeignKey(o => o.CompteSourceId)
            //           .OnDelete(DeleteBehavior.Cascade);

            //     entity.HasOne(o => o.CompteDestination)
            //           .WithMany()
            //           .HasForeignKey(o => o.CompteDestinationId)
            //           .OnDelete(DeleteBehavior.Restrict);
            // });
        }
    }
}
