using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace bank.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "agences",
                columns: table => new
                {
                    Code = table.Column<string>(type: "text", nullable: false),
                    Nom = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Adresse = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_agences", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Numero = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Nom = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Prenom = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Genre = table.Column<int>(type: "integer", nullable: false),
                    Telephone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    AgenceCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.Id);
                    table.UniqueConstraint("AK_clients_Numero", x => x.Numero);
                    table.ForeignKey(
                        name: "FK_clients_agences_AgenceCode",
                        column: x => x.AgenceCode,
                        principalTable: "agences",
                        principalColumn: "Code");
                });

            migrationBuilder.CreateTable(
                name: "comptes",
                columns: table => new
                {
                    Code = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Solde = table.Column<double>(type: "double precision", nullable: false),
                    ClientNumero = table.Column<string>(type: "character varying(100)", nullable: false),
                    TypeCompte = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false),
                    Decouvert = table.Column<double>(type: "double precision", nullable: true),
                    TauxInteret = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comptes", x => x.Code);
                    table.ForeignKey(
                        name: "FK_comptes_clients_ClientNumero",
                        column: x => x.ClientNumero,
                        principalTable: "clients",
                        principalColumn: "Numero",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Montant = table.Column<double>(type: "double precision", nullable: false),
                    CompteSourceId = table.Column<int>(type: "integer", nullable: false),
                    CompteDestinationId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Operations_comptes_CompteDestinationId",
                        column: x => x.CompteDestinationId,
                        principalTable: "comptes",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_Operations_comptes_CompteSourceId",
                        column: x => x.CompteSourceId,
                        principalTable: "comptes",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_clients_AgenceCode",
                table: "clients",
                column: "AgenceCode");

            migrationBuilder.CreateIndex(
                name: "IX_comptes_ClientNumero",
                table: "comptes",
                column: "ClientNumero",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Operations_CompteDestinationId",
                table: "Operations",
                column: "CompteDestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_CompteSourceId",
                table: "Operations",
                column: "CompteSourceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Operations");

            migrationBuilder.DropTable(
                name: "comptes");

            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropTable(
                name: "agences");
        }
    }
}
