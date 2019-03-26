using Microsoft.EntityFrameworkCore.Migrations;

namespace ASPNETCoreHeroku.Migrations
{
    public partial class TicketUUIDToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UUID",
                table: "Ticket",
                nullable: true,
                oldClrType: typeof(long));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "UUID",
                table: "Ticket",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
