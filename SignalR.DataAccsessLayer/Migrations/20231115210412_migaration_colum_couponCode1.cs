using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalR.DataAccsessLayer.Migrations
{
    public partial class migaration_colum_couponCode1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "couponCodes",
                columns: table => new
                {
                    CouponCodeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amout = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_couponCodes", x => x.CouponCodeID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "couponCodes");
        }
    }
}
