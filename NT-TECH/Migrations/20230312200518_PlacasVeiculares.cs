using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NT_TECH.Migrations
{
    /// <inheritdoc />
    public partial class PlacasVeiculares : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlacasCadastradas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlacasCadastrada = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChavesAtivas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NaoAtivas = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlacasCadastradas", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlacasCadastradas");
        }
    }
}
