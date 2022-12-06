using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InformationSystemsDesign.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TypePr",
                columns: table => new
                {
                    CdTp = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NmTp = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypePr", x => x.CdTp);
                });

            migrationBuilder.CreateTable(
                name: "GLPR",
                columns: table => new
                {
                    CdPr = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NmPr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CdTp = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GLPR", x => x.CdPr);
                    table.ForeignKey(
                        name: "FK_GLPR_TypePr_CdTp",
                        column: x => x.CdTp,
                        principalTable: "TypePr",
                        principalColumn: "CdTp",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Spec",
                columns: table => new
                {
                    CdSb = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CdKp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    QtyKp = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spec", x => new { x.CdSb, x.CdKp });
                    table.CheckConstraint("CK_Spec_CdKp", "[CdKp] != [CdSb]");
                    table.CheckConstraint("CK_Spec_CdSb", "[CdSb] != [CdKp]");
                    table.CheckConstraint("CK_Spec_QtyKp", "[QtyKp] >= 0");
                    table.ForeignKey(
                        name: "FK_Spec_GLPR_CdKp",
                        column: x => x.CdKp,
                        principalTable: "GLPR",
                        principalColumn: "CdPr",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Spec_GLPR_CdSb",
                        column: x => x.CdSb,
                        principalTable: "GLPR",
                        principalColumn: "CdPr",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GLPR_CdTp",
                table: "GLPR",
                column: "CdTp");

            migrationBuilder.CreateIndex(
                name: "IX_Spec_CdKp",
                table: "Spec",
                column: "CdKp");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Spec");

            migrationBuilder.DropTable(
                name: "GLPR");

            migrationBuilder.DropTable(
                name: "TypePr");
        }
    }
}
