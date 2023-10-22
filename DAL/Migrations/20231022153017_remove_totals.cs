using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class remove_totals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalAdultPrice",
                table: "BookingRooms");

            migrationBuilder.DropColumn(
                name: "TotalChildPrice",
                table: "BookingRooms");

            migrationBuilder.AddColumn<int>(
                name: "AdultCount",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ChildCount",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "TotalAdultPrice",
                table: "Bookings",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalChildPrice",
                table: "Bookings",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "DashboardViews",
                columns: new[] { "Id", "Name", "ViewPath" },
                values: new object[] { 26, "Booking", "Booking" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$aUWgMpnM3GN90MOqCzbP6eSEuc6kSkn0wSVTh3a7SbvOUOQY7qMPa");

            migrationBuilder.InsertData(
                table: "AdministrationRolePremissions",
                columns: new[] { "Id", "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[] { 26, 1, 1, 26 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "DashboardViews",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DropColumn(
                name: "AdultCount",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "ChildCount",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "TotalAdultPrice",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "TotalChildPrice",
                table: "Bookings");

            migrationBuilder.AddColumn<double>(
                name: "TotalAdultPrice",
                table: "BookingRooms",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalChildPrice",
                table: "BookingRooms",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$76l4FR342ToVTgA1At10G.RBHQ63cKGZaaR3AFYnuAIJa4tb4zqwS");
        }
    }
}
