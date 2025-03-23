using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace doanchuyennganh.Migrations
{
    /// <inheritdoc />
    public partial class AddDuongdanToSach : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Duongdan",
                table: "Saches",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duongdan",
                table: "Saches");
        }
    }
}
