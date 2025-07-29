using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class projectforeignadd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Tickets_TicketId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_TicketId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "TicketId",
                table: "Projects");

            migrationBuilder.CreateTable(
                name: "ProjectTicket",
                columns: table => new
                {
                    ProjectsId = table.Column<int>(type: "integer", nullable: false),
                    TicketsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTicket", x => new { x.ProjectsId, x.TicketsId });
                    table.ForeignKey(
                        name: "FK_ProjectTicket_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectTicket_Tickets_TicketsId",
                        column: x => x.TicketsId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTicket_TicketsId",
                table: "ProjectTicket",
                column: "TicketsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectTicket");

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
    }
}
