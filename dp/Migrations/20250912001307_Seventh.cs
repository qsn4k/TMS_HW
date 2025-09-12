using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dp.Migrations
{
    /// <inheritdoc />
    public partial class Seventh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TicketCartId",
                table: "Tickets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TicketCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketCarts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TicketCartId",
                table: "Tickets",
                column: "TicketCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TicketCarts_TicketCartId",
                table: "Tickets",
                column: "TicketCartId",
                principalTable: "TicketCarts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TicketCarts_TicketCartId",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "TicketCarts");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_TicketCartId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "TicketCartId",
                table: "Tickets");
        }
    }
}
