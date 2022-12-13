using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InformationSystemsDesign.Migrations
{
    /// <inheritdoc />
    public partial class AddDovTOPTRNTechNorm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DovTO",
                columns: table => new
                {
                    CdTO = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NmTO = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DovTO", x => x.CdTO);
                    table.UniqueConstraint("AK_DovTO_NmTO", x => x.NmTO);
                });

            migrationBuilder.CreateTable(
                name: "PTRN",
                columns: table => new
                {
                    CdPr = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CdTO = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NbTO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Godin = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PTRN", x => new { x.CdPr, x.CdTO });
                    table.UniqueConstraint("AK_PTRN_CdTO", x => x.CdTO);
                    table.ForeignKey(
                        name: "FK_PTRN_DovTO_CdTO",
                        column: x => x.CdTO,
                        principalTable: "DovTO",
                        principalColumn: "CdTO");
                    table.ForeignKey(
                        name: "FK_PTRN_GLPR_CdPr",
                        column: x => x.CdPr,
                        principalTable: "GLPR",
                        principalColumn: "CdPr");
                });

            migrationBuilder.CreateTable(
                name: "TechNorm",
                columns: table => new
                {
                    CdVyr = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CdTO = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NmTO = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SumGodin = table.Column<float>(type: "real", nullable: false),
                    SumRozvId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechNorm", x => new { x.CdVyr, x.CdTO });
                    table.ForeignKey(
                        name: "FK_TechNorm_DovTO_NmTO",
                        column: x => x.NmTO,
                        principalTable: "DovTO",
                        principalColumn: "NmTO");
                    table.ForeignKey(
                        name: "FK_TechNorm_PTRN_CdTO",
                        column: x => x.CdTO,
                        principalTable: "PTRN",
                        principalColumn: "CdTO");
                    table.ForeignKey(
                        name: "FK_TechNorm_SumRozv_SumRozvId",
                        column: x => x.SumRozvId,
                        principalTable: "SumRozv",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TechNorm_CdTO",
                table: "TechNorm",
                column: "CdTO");

            migrationBuilder.CreateIndex(
                name: "IX_TechNorm_NmTO",
                table: "TechNorm",
                column: "NmTO");

            migrationBuilder.CreateIndex(
                name: "IX_TechNorm_SumRozvId",
                table: "TechNorm",
                column: "SumRozvId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TechNorm");

            migrationBuilder.DropTable(
                name: "PTRN");

            migrationBuilder.DropTable(
                name: "DovTO");
        }
    }
}
