using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ffhhhfhfh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColorCode",
                table: "DashboardAdministrationRoles");

            migrationBuilder.DropColumn(
                name: "Icon",
                table: "DashboardAdministrationRoles");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$J4FFdTBFZigNRlwR2lciSufP2ZiN2B1dfFWPNcaRUpnSA8Sr037uO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ColorCode",
                table: "DashboardAdministrationRoles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "DashboardAdministrationRoles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "DashboardAdministrationRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ColorCode", "Icon" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$0pc9NzQCvT7vp38/UPHuauTq./kYNbXxCiH6iinriczHMg.kQ7Cqi");
        }
    }
}
