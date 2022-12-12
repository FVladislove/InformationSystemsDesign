using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InformationSystemsDesign.Migrations
{
    /// <inheritdoc />
    public partial class CreatedTablesForMaterialsApplicability : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DovMt",
                columns: table => new
                {
                    CdMt = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NmMt = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DovMt", x => x.CdMt);
                });

            migrationBuilder.CreateTable(
                name: "ZastMt",
                columns: table => new
                {
                    CdKp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CdMt = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OdVym = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QtyMt = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZastMt", x => new { x.CdKp, x.CdMt });
                    table.ForeignKey(
                        name: "FK_ZastMt_DovMt_CdMt",
                        column: x => x.CdMt,
                        principalTable: "DovMt",
                        principalColumn: "CdMt");
                    table.ForeignKey(
                        name: "FK_ZastMt_GLPR_CdKp",
                        column: x => x.CdKp,
                        principalTable: "GLPR",
                        principalColumn: "CdPr");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ZastMt_CdMt",
                table: "ZastMt",
                column: "CdMt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZastMt");

            migrationBuilder.DropTable(
                name: "DovMt");
        }
    }
}
