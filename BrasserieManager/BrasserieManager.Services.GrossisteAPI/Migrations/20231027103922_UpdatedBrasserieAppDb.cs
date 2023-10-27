using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrasserieManager.Services.GrossisteAPI.Migrations
{
    public partial class UpdatedBrasserieAppDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brasserie",
                columns: table => new
                {
                    BrasserieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brasserie", x => x.BrasserieId);
                });

            migrationBuilder.CreateTable(
                name: "Grossiste",
                columns: table => new
                {
                    GrossisteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grossiste", x => x.GrossisteId);
                });

            migrationBuilder.CreateTable(
                name: "Biere",
                columns: table => new
                {
                    BiereId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alcool = table.Column<double>(type: "float", nullable: false),
                    Prix = table.Column<double>(type: "float", nullable: false),
                    BrasserieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biere", x => x.BiereId);
                    table.ForeignKey(
                        name: "FK_Biere_Brasserie_BrasserieId",
                        column: x => x.BrasserieId,
                        principalTable: "Brasserie",
                        principalColumn: "BrasserieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BiereGrossiste",
                columns: table => new
                {
                    BiereGrossisteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GrossisteId = table.Column<int>(type: "int", nullable: false),
                    BiereId = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BiereGrossiste", x => x.BiereGrossisteId);
                    table.ForeignKey(
                        name: "FK_BiereGrossiste_Biere_BiereId",
                        column: x => x.BiereId,
                        principalTable: "Biere",
                        principalColumn: "BiereId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BiereGrossiste_Grossiste_GrossisteId",
                        column: x => x.GrossisteId,
                        principalTable: "Grossiste",
                        principalColumn: "GrossisteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brasserie",
                columns: new[] { "BrasserieId", "Nom" },
                values: new object[] { 1, "Abbaye de Leffe" });

            migrationBuilder.InsertData(
                table: "Brasserie",
                columns: new[] { "BrasserieId", "Nom" },
                values: new object[] { 2, "Flying dodo" });

            migrationBuilder.InsertData(
                table: "Grossiste",
                columns: new[] { "GrossisteId", "Nom" },
                values: new object[] { 1, "GeneDrinks" });

            migrationBuilder.InsertData(
                table: "Biere",
                columns: new[] { "BiereId", "Alcool", "BrasserieId", "Nom", "Prix" },
                values: new object[] { 1, 6.5, 1, "Leffe blonde", 1.5 });

            migrationBuilder.InsertData(
                table: "BiereGrossiste",
                columns: new[] { "BiereGrossisteId", "BiereId", "GrossisteId", "Stock" },
                values: new object[] { 1, 1, 1, 10 });

            migrationBuilder.CreateIndex(
                name: "IX_Biere_BrasserieId",
                table: "Biere",
                column: "BrasserieId");

            migrationBuilder.CreateIndex(
                name: "IX_BiereGrossiste_BiereId",
                table: "BiereGrossiste",
                column: "BiereId");

            migrationBuilder.CreateIndex(
                name: "IX_BiereGrossiste_GrossisteId",
                table: "BiereGrossiste",
                column: "GrossisteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BiereGrossiste");

            migrationBuilder.DropTable(
                name: "Biere");

            migrationBuilder.DropTable(
                name: "Grossiste");

            migrationBuilder.DropTable(
                name: "Brasserie");
        }
    }
}
