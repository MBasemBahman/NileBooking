using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class featureimage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_HotelFeatures_Name",
                table: "HotelFeatures");

            migrationBuilder.DropColumn(
                name: "LocationUrl",
                table: "Hotels");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "HotelFeatures",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "HotelFeatures",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StorageUrl",
                table: "HotelFeatures",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$UNuW9jjMvZGnc8Wa1Icqn.shYlNPgdJ4.J2Bx5ENXvie6i2OGp2S2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "HotelFeatures");

            migrationBuilder.DropColumn(
                name: "StorageUrl",
                table: "HotelFeatures");

            migrationBuilder.AddColumn<string>(
                name: "LocationUrl",
                table: "Hotels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "HotelFeatures",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$Ihz12eLUSVUHmiQX2xT4wuGkjrUtzpmefhQC2m7ZpKhUuM8bLFe7K");

            migrationBuilder.CreateIndex(
                name: "IX_HotelFeatures_Name",
                table: "HotelFeatures",
                column: "Name",
                unique: true);
        }
    }
}
