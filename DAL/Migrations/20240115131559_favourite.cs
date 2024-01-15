using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class favourite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FavouriteAccountHotel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fk_Account = table.Column<int>(type: "int", nullable: false),
                    Fk_Hotel = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteAccountHotel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavouriteAccountHotel_Accounts_Fk_Account",
                        column: x => x.Fk_Account,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavouriteAccountHotel_Hotels_Fk_Hotel",
                        column: x => x.Fk_Hotel,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$oTEixDmd1cQLRWBDUiJbdey4qBTiRUql2N.LJGPNw31Xc0qyPh6mi");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteAccountHotel_Fk_Account",
                table: "FavouriteAccountHotel",
                column: "Fk_Account");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteAccountHotel_Fk_Hotel",
                table: "FavouriteAccountHotel",
                column: "Fk_Hotel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavouriteAccountHotel");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$aUWgMpnM3GN90MOqCzbP6eSEuc6kSkn0wSVTh3a7SbvOUOQY7qMPa");
        }
    }
}
