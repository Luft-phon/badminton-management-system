using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BadmintonCourtManagement.Migrations
{
    /// <inheritdoc />
    public partial class AddCourtBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courts_Bookings_BookingID",
                table: "Courts");

            migrationBuilder.DropIndex(
                name: "IX_Courts_BookingID",
                table: "Courts");

            migrationBuilder.DropColumn(
                name: "BookingID",
                table: "Courts");

            migrationBuilder.CreateTable(
                name: "CourtBooking",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    CourtId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourtBooking", x => new { x.BookingId, x.CourtId });
                    table.ForeignKey(
                        name: "FK_CourtBooking_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "BookingID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourtBooking_Courts_CourtId",
                        column: x => x.CourtId,
                        principalTable: "Courts",
                        principalColumn: "CourtID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourtBooking_CourtId",
                table: "CourtBooking",
                column: "CourtId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourtBooking");

            migrationBuilder.AddColumn<int>(
                name: "BookingID",
                table: "Courts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courts_BookingID",
                table: "Courts",
                column: "BookingID");

            migrationBuilder.AddForeignKey(
                name: "FK_Courts_Bookings_BookingID",
                table: "Courts",
                column: "BookingID",
                principalTable: "Bookings",
                principalColumn: "BookingID");
        }
    }
}
