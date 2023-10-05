using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class add_hotel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AccountStateLang",
                columns: new[] { "Id", "Fk_Source", "Language", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { 4, 1, 2, null, "Active" },
                    { 5, 2, 2, null, "Pending" },
                    { 6, 3, 2, null, "Ban" }
                });

            migrationBuilder.InsertData(
                table: "AccountTypeLang",
                columns: new[] { "Id", "Fk_Source", "Language", "LastModifiedBy", "Name" },
                values: new object[] { 2, 1, 2, null, "Client" });

            migrationBuilder.InsertData(
                table: "BookingStateLang",
                columns: new[] { "Id", "Fk_Source", "Language", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { 6, 1, 2, null, "Pending" },
                    { 7, 2, 2, null, "Confirmed" },
                    { 8, 3, 2, null, "Cancelled" },
                    { 9, 4, 2, null, "Completed" },
                    { 10, 5, 2, null, "Refunded" }
                });

            migrationBuilder.InsertData(
                table: "DashboardAdministrationRoleLang",
                columns: new[] { "Id", "Fk_Source", "Language", "Name" },
                values: new object[] { 2, 1, 2, "Developer" });

            migrationBuilder.InsertData(
                table: "DashboardViews",
                columns: new[] { "Id", "Name", "ViewPath" },
                values: new object[,]
                {
                    { 21, "Hotel", "Hotel" },
                    { 22, "HotelAttachment", "HotelAttachment" },
                    { 23, "HotelExtraPrice", "HotelExtraPrice" },
                    { 24, "HotelRoom", "HotelRoom" }
                });

            migrationBuilder.InsertData(
                table: "HotelTypeLang",
                columns: new[] { "Id", "Fk_Source", "Language", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { 7, 1, 2, null, "Hotel" },
                    { 8, 2, 2, null, "Resort" },
                    { 9, 3, 2, null, "Apartment" },
                    { 10, 4, 2, null, "Hostel" },
                    { 11, 6, 2, null, "Villa" },
                    { 12, 7, 2, null, "Motel" }
                });

            migrationBuilder.InsertData(
                table: "RoomFoodTypeLang",
                columns: new[] { "Id", "Fk_Source", "Language", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { 6, 1, 2, null, "BedAndBreakfast" },
                    { 7, 2, 2, null, "HalfBoard" },
                    { 8, 3, 2, null, "FullBoard" },
                    { 9, 4, 2, null, "AllInclusive" },
                    { 10, 5, 2, null, "RoomOnly" }
                });

            migrationBuilder.InsertData(
                table: "RoomTypeLang",
                columns: new[] { "Id", "Fk_Source", "Language", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { 4, 1, 2, null, "Single" },
                    { 5, 2, 2, null, "Double" },
                    { 6, 3, 2, null, "Triple" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$nTqD2eyyCwzTP69C3ZvJqu2DPQiyiWgq5PeGfjvbaABIN.fljgbFe");

            migrationBuilder.InsertData(
                table: "AdministrationRolePremissions",
                columns: new[] { "Id", "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[,]
                {
                    { 21, 1, 1, 21 },
                    { 22, 1, 1, 22 },
                    { 23, 1, 1, 23 },
                    { 24, 1, 1, 24 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AccountStateLang",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AccountStateLang",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AccountStateLang",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AccountTypeLang",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "BookingStateLang",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "BookingStateLang",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "BookingStateLang",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "BookingStateLang",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "BookingStateLang",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "DashboardAdministrationRoleLang",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "HotelTypeLang",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "HotelTypeLang",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "HotelTypeLang",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "HotelTypeLang",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "HotelTypeLang",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "HotelTypeLang",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "RoomFoodTypeLang",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "RoomFoodTypeLang",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "RoomFoodTypeLang",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "RoomFoodTypeLang",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "RoomFoodTypeLang",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "RoomTypeLang",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RoomTypeLang",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RoomTypeLang",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "DashboardViews",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "DashboardViews",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "DashboardViews",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "DashboardViews",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$kwct33IDPXRjURN8hL3fteKBIdQ8r6MNHMwTenis9dDVaXP7XAWeS");
        }
    }
}
