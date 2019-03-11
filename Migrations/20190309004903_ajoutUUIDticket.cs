using Microsoft.EntityFrameworkCore.Migrations;

namespace ASPNETCoreHeroku.Migrations
{
    public partial class ajoutUUIDticket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UUID",
                table: "Ticket",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UUID",
                table: "Ticket");
        }
    }
}
