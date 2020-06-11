using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OperationAccount.Data.SuperDigital.Migrations
{
    public partial class inicialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "SuperDigital");

            migrationBuilder.CreateTable(
                name: "Conta",
                schema: "SuperDigital",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Numero = table.Column<string>(type: "varchar(200)", nullable: false),
                    Saldo = table.Column<decimal>(nullable: false),
                    TitularId = table.Column<Guid>(nullable: false),
                    LancamentoId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lancamento",
                schema: "SuperDigital",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    ContaId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lancamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lancamento_Conta_ContaId",
                        column: x => x.ContaId,
                        principalSchema: "SuperDigital",
                        principalTable: "Conta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Titular",
                schema: "SuperDigital",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    Cpf = table.Column<string>(type: "varchar(200)", nullable: false),
                    ContaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titular", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Titular_Conta_ContaId",
                        column: x => x.ContaId,
                        principalSchema: "SuperDigital",
                        principalTable: "Conta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lancamento_ContaId",
                schema: "SuperDigital",
                table: "Lancamento",
                column: "ContaId");

            migrationBuilder.CreateIndex(
                name: "IX_Titular_ContaId",
                schema: "SuperDigital",
                table: "Titular",
                column: "ContaId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lancamento",
                schema: "SuperDigital");

            migrationBuilder.DropTable(
                name: "Titular",
                schema: "SuperDigital");

            migrationBuilder.DropTable(
                name: "Conta",
                schema: "SuperDigital");
        }
    }
}
