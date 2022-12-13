using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InformationSystemsDesign.Migrations
{
    /// <inheritdoc />
    public partial class AddDorPrfandTOPF : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DovPrf",
                columns: table => new
                {
                    CdPf = table.Column<float>(type: "real", nullable: false),
                    NmPf = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DovPrf", x => x.CdPf);
                });

            migrationBuilder.CreateTable(
                name: "TO_PF",
                columns: table => new
                {
                    CdTO = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CdPf = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TO_PF", x => new { x.CdTO, x.CdPf });
                    table.ForeignKey(
                        name: "FK_TO_PF_DovPrf_CdPf",
                        column: x => x.CdPf,
                        principalTable: "DovPrf",
                        principalColumn: "CdPf",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TO_PF_DovTO_CdTO",
                        column: x => x.CdTO,
                        principalTable: "DovTO",
                        principalColumn: "CdTO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TO_PF_CdPf",
                table: "TO_PF",
                column: "CdPf");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TO_PF");

            migrationBuilder.DropTable(
                name: "DovPrf");
        }
    }
}
