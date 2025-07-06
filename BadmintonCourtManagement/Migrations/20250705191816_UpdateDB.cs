using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BadmintonCourtManagement.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Reports_ReportID",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_CourtBooking_Bookings_BookingId",
                table: "CourtBooking");

            migrationBuilder.DropForeignKey(
                name: "FK_CourtBooking_Courts_CourtId",
                table: "CourtBooking");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Notifications_NotificationID",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourtBooking",
                table: "CourtBooking");

            migrationBuilder.RenameTable(
                name: "CourtBooking",
                newName: "CourtBookings");

            migrationBuilder.RenameIndex(
                name: "IX_CourtBooking_CourtId",
                table: "CourtBookings",
                newName: "IX_CourtBookings_CourtId");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "NotificationID",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Method",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ReportID",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourtBookings",
                table: "CourtBookings",
                columns: new[] { "BookingId", "CourtId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Reports_ReportID",
                table: "Bookings",
                column: "ReportID",
                principalTable: "Reports",
                principalColumn: "ReportID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourtBookings_Bookings_BookingId",
                table: "CourtBookings",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "BookingID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourtBookings_Courts_CourtId",
                table: "CourtBookings",
                column: "CourtId",
                principalTable: "Courts",
                principalColumn: "CourtID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Notifications_NotificationID",
                table: "User",
                column: "NotificationID",
                principalTable: "Notifications",
                principalColumn: "NotificationID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Reports_ReportID",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_CourtBookings_Bookings_BookingId",
                table: "CourtBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_CourtBookings_Courts_CourtId",
                table: "CourtBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Notifications_NotificationID",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourtBookings",
                table: "CourtBookings");

            migrationBuilder.RenameTable(
                name: "CourtBookings",
                newName: "CourtBooking");

            migrationBuilder.RenameIndex(
                name: "IX_CourtBookings_CourtId",
                table: "CourtBooking",
                newName: "IX_CourtBooking_CourtId");

            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "User",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "NotificationID",
                table: "User",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Payments",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Method",
                table: "Payments",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Bookings",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ReportID",
                table: "Bookings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourtBooking",
                table: "CourtBooking",
                columns: new[] { "BookingId", "CourtId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Reports_ReportID",
                table: "Bookings",
                column: "ReportID",
                principalTable: "Reports",
                principalColumn: "ReportID");

            migrationBuilder.AddForeignKey(
                name: "FK_CourtBooking_Bookings_BookingId",
                table: "CourtBooking",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "BookingID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourtBooking_Courts_CourtId",
                table: "CourtBooking",
                column: "CourtId",
                principalTable: "Courts",
                principalColumn: "CourtID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Notifications_NotificationID",
                table: "User",
                column: "NotificationID",
                principalTable: "Notifications",
                principalColumn: "NotificationID");
        }
    }
}
