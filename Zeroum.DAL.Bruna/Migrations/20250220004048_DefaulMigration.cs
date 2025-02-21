using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zeroum.DAL.Bruna.Migrations
{
    /// <inheritdoc />
    public partial class DefaulMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientesPf",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    cpf = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    rg = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: false),
                    email = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    telefone = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: false),
                    nascimento = table.Column<DateTime>(nullable: false)
                },
               constraints: table =>
               {
                   table.PrimaryKey("PK_ClientesPf", x => x.Id);
               });

            migrationBuilder.CreateTable(
               name: "ClientesPj",
               columns: table => new
               {
                   Id = table.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                   cnpj = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                   razaoSocial = table.Column<decimal>(type: "character varying(250)", maxLength: 250, nullable: false),
                   nomeFantasia = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                   email = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                   dataAbertura = table.Column<DateTime>(nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_ClientesPj", x => x.Id);
               });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientesPf");

            migrationBuilder.DropTable(
            name: "ClientesPj");

        }
    }
}
