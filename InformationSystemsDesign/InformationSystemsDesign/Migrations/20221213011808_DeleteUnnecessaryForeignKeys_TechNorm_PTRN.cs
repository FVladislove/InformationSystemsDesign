using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InformationSystemsDesign.Migrations
{
    /// <inheritdoc />
    public partial class DeleteUnnecessaryForeignKeysTechNormPTRN : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TechNorm_DovTO_NmTO",
                table: "TechNorm");

            migrationBuilder.DropForeignKey(
                name: "FK_TechNorm_PTRN_CdTO",
                table: "TechNorm");

            migrationBuilder.DropForeignKey(
                name: "FK_TechNorm_SumRozv_SumRozvId",
                table: "TechNorm");

            migrationBuilder.DropIndex(
                name: "IX_TechNorm_CdTO",
                table: "TechNorm");

            migrationBuilder.DropIndex(
                name: "IX_TechNorm_NmTO",
                table: "TechNorm");

            migrationBuilder.DropIndex(
                name: "IX_TechNorm_SumRozvId",
                table: "TechNorm");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_PTRN_CdTO",
                table: "PTRN");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_DovTO_NmTO",
                table: "DovTO");

            migrationBuilder.DropColumn(
                name: "SumRozvId",
                table: "TechNorm");

            migrationBuilder.AlterColumn<string>(
                name: "NmTO",
                table: "TechNorm",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "NmTO",
                table: "DovTO",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_PTRN_CdTO",
                table: "PTRN",
                column: "CdTO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PTRN_CdTO",
                table: "PTRN");

            migrationBuilder.AlterColumn<string>(
                name: "NmTO",
                table: "TechNorm",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "SumRozvId",
                table: "TechNorm",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NmTO",
                table: "DovTO",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_PTRN_CdTO",
                table: "PTRN",
                column: "CdTO");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_DovTO_NmTO",
                table: "DovTO",
                column: "NmTO");

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

            migrationBuilder.AddForeignKey(
                name: "FK_TechNorm_DovTO_NmTO",
                table: "TechNorm",
                column: "NmTO",
                principalTable: "DovTO",
                principalColumn: "NmTO");

            migrationBuilder.AddForeignKey(
                name: "FK_TechNorm_PTRN_CdTO",
                table: "TechNorm",
                column: "CdTO",
                principalTable: "PTRN",
                principalColumn: "CdTO");

            migrationBuilder.AddForeignKey(
                name: "FK_TechNorm_SumRozv_SumRozvId",
                table: "TechNorm",
                column: "SumRozvId",
                principalTable: "SumRozv",
                principalColumn: "Id");
        }
    }
}
