using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoomService.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "HotelId", "Price", "RoomNumber", "RoomType" },
                values: new object[,]
                {
                    { 1, 1, 999.0, "20A", "AC" },
                    { 2, 1, 555.0, "20B", "AC" },
                    { 3, 2, 666.0, "30A", "NonAC" },
                    { 4, 2, 2999.0, "30B", "AC" },
                    { 5, 3, 4999.0, "40A", "AC" },
                    { 6, 3, 1199.0, "40B", "NonAC" },
                    { 7, 4, 3999.0, "50A", "AC" },
                    { 8, 4, 1999.0, "50B", "NonAC" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
