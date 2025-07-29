using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class projectforeign : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Tickets",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TicketId",
                table: "Projects",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_TicketId",
                table: "Projects",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Tickets_TicketId",
                table: "Projects",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Tickets_TicketId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_TicketId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "TicketId",
                table: "Projects");
        }
    }
}
