using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BadmintonCourtManagement.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMigraton : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TotalFreeHour",
                table: "Reports",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "TotalFreeHour",
                table: "Reports",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
