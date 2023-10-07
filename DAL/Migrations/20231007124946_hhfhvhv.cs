using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class hhfhvhv : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "DashboardAdministrators",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.UpdateData(
                table: "DashboardAdministrators",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$Ihz12eLUSVUHmiQX2xT4wuGkjrUtzpmefhQC2m7ZpKhUuM8bLFe7K");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "DashboardAdministrators");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$J4FFdTBFZigNRlwR2lciSufP2ZiN2B1dfFWPNcaRUpnSA8Sr037uO");
        }
    }
}
