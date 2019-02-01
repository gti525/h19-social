using Microsoft.EntityFrameworkCore.Migrations;

namespace ASPNETCoreHeroku.Migrations
{
    public partial class EditId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Client_Id",
                table: "Ticket");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Ticket",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_Id",
                table: "Ticket",
                newName: "IX_Ticket_ClientId");

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "Client",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Client_ClientId",
                table: "Ticket",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Client_ClientId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "Token",
                table: "Client");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Ticket",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_ClientId",
                table: "Ticket",
                newName: "IX_Ticket_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Client_Id",
                table: "Ticket",
                column: "Id",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
