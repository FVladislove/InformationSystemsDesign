using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InformationSystemsDesign.Migrations
{
    /// <inheritdoc />
    public partial class Lab2Changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StrRozv",
                columns: table => new
                {
                    CdVyr = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CdSb = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CdKp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    QtyKp = table.Column<int>(type: "int", nullable: false),
                    RivNb = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
                    RivGrf = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, defaultValueSql: "('.1')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrRozv", x => new { x.CdVyr, x.CdSb, x.CdKp });
                    table.ForeignKey(
                        name: "FK_StrRozv_GLPR_CdKp",
                        column: x => x.CdKp,
                        principalTable: "GLPR",
                        principalColumn: "CdPr");
                    table.ForeignKey(
                        name: "FK_StrRozv_GLPR_CdSb",
                        column: x => x.CdSb,
                        principalTable: "GLPR",
                        principalColumn: "CdPr");
                    table.ForeignKey(
                        name: "FK_StrRozv_GLPR_CdVyr",
                        column: x => x.CdVyr,
                        principalTable: "GLPR",
                        principalColumn: "CdPr");
                });

            migrationBuilder.CreateIndex(
                name: "IX_StrRozv_CdKp",
                table: "StrRozv",
                column: "CdKp");

            migrationBuilder.CreateIndex(
                name: "IX_StrRozv_CdSb",
                table: "StrRozv",
                column: "CdSb");

            migrationBuilder.CreateIndex(
                name: "IX_StrRozv_CdVyr",
                table: "StrRozv",
                column: "CdVyr");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StrRozv");
        }
    }
}
