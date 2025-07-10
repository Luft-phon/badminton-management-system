using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BadmintonCourtManagement.Migrations
{
    /// <inheritdoc />
    public partial class NullableDobUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Notifications_NotificationID",
                table: "User");

            migrationBuilder.AlterColumn<int>(
                name: "NotificationID",
                table: "User",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Notifications_NotificationID",
                table: "User",
                column: "NotificationID",
                principalTable: "Notifications",
                principalColumn: "NotificationID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Notifications_NotificationID",
                table: "User");

            migrationBuilder.AlterColumn<int>(
                name: "NotificationID",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Notifications_NotificationID",
                table: "User",
                column: "NotificationID",
                principalTable: "Notifications",
                principalColumn: "NotificationID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
