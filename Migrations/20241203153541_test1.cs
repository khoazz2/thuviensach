using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace doanchuyennganh.Migrations
{
    /// <inheritdoc />
    public partial class test1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Theloais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Mota = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Theloais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Saches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Tacgia = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Mota = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Anhbia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TheloaiId = table.Column<int>(type: "int", nullable: false),
                    Duongdan = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Saches_Theloais_TheloaiId",
                        column: x => x.TheloaiId,
                        principalTable: "Theloais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Saches_TheloaiId",
                table: "Saches",
                column: "TheloaiId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Saches");

            migrationBuilder.DropTable(
                name: "Theloais");
        }
    }
}
