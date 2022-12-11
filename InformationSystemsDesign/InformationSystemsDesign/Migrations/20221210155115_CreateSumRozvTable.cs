using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InformationSystemsDesign.Migrations
{
    /// <inheritdoc />
    public partial class CreateSumRozvTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SumRozv",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CdVyr = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CdKp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SumKp = table.Column<int>(type: "int", nullable: false),
                    MinRv = table.Column<int>(type: "int", nullable: false),
                    CdTp = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SumRozv", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SumRozv_GLPR_CdKp",
                        column: x => x.CdKp,
                        principalTable: "GLPR",
                        principalColumn: "CdPr");
                    table.ForeignKey(
                        name: "FK_SumRozv_GLPR_CdVyr",
                        column: x => x.CdVyr,
                        principalTable: "GLPR",
                        principalColumn: "CdPr");
                    table.ForeignKey(
                        name: "FK_SumRozv_TypePr_CdTp",
                        column: x => x.CdTp,
                        principalTable: "TypePr",
                        principalColumn: "CdTp");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SumRozv_CdKp",
                table: "SumRozv",
                column: "CdKp");

            migrationBuilder.CreateIndex(
                name: "IX_SumRozv_CdTp",
                table: "SumRozv",
                column: "CdTp");

            migrationBuilder.CreateIndex(
                name: "IX_SumRozv_CdVyr",
                table: "SumRozv",
                column: "CdVyr");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SumRozv");
        }
    }
}
