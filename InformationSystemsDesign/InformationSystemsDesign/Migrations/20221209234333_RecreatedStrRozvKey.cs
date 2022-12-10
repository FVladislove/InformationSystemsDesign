using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InformationSystemsDesign.Migrations
{
    /// <inheritdoc />
    public partial class RecreatedStrRozvKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StrRozv",
                table: "StrRozv");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "StrRozv",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StrRozv",
                table: "StrRozv",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StrRozv",
                table: "StrRozv");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "StrRozv");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StrRozv",
                table: "StrRozv",
                columns: new[] { "CdVyr", "CdSb", "CdKp", "QtyKp" });
        }
    }
}
