using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InformationSystemsDesign.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedKeyForStrRozv : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Spec_GLPR_CdKp",
                table: "Spec");

            migrationBuilder.DropForeignKey(
                name: "FK_Spec_GLPR_CdSb",
                table: "Spec");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StrRozv",
                table: "StrRozv");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StrRozv",
                table: "StrRozv",
                columns: new[] { "CdVyr", "CdSb", "CdKp", "QtyKp" });

            migrationBuilder.AddForeignKey(
                name: "FK_Spec_GLPR_CdKp",
                table: "Spec",
                column: "CdKp",
                principalTable: "GLPR",
                principalColumn: "CdPr");

            migrationBuilder.AddForeignKey(
                name: "FK_Spec_GLPR_CdSb",
                table: "Spec",
                column: "CdSb",
                principalTable: "GLPR",
                principalColumn: "CdPr");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Spec_GLPR_CdKp",
                table: "Spec");

            migrationBuilder.DropForeignKey(
                name: "FK_Spec_GLPR_CdSb",
                table: "Spec");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StrRozv",
                table: "StrRozv");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StrRozv",
                table: "StrRozv",
                columns: new[] { "CdVyr", "CdSb", "CdKp" });

            migrationBuilder.AddForeignKey(
                name: "FK_Spec_GLPR_CdKp",
                table: "Spec",
                column: "CdKp",
                principalTable: "GLPR",
                principalColumn: "CdPr",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Spec_GLPR_CdSb",
                table: "Spec",
                column: "CdSb",
                principalTable: "GLPR",
                principalColumn: "CdPr",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
