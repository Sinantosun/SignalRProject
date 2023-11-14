using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalR.DataAccsessLayer.Migrations
{
    public partial class mig_colm_add_status : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "Discounts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "Discounts");
        }
    }
}
