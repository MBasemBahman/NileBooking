using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class hffc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "AccountStateLang",
                keyColumn: "Id",
                keyValue: 1,
                column: "Language",
                value: 1);

            migrationBuilder.UpdateData(
                table: "AccountStateLang",
                keyColumn: "Id",
                keyValue: 2,
                column: "Language",
                value: 1);

            migrationBuilder.UpdateData(
                table: "AccountStateLang",
                keyColumn: "Id",
                keyValue: 3,
                column: "Language",
                value: 1);

            migrationBuilder.UpdateData(
                table: "AccountTypeLang",
                keyColumn: "Id",
                keyValue: 1,
                column: "Language",
                value: 1);

            migrationBuilder.UpdateData(
                table: "BookingStateLang",
                keyColumn: "Id",
                keyValue: 1,
                column: "Language",
                value: 1);

            migrationBuilder.UpdateData(
                table: "BookingStateLang",
                keyColumn: "Id",
                keyValue: 2,
                column: "Language",
                value: 1);

            migrationBuilder.UpdateData(
                table: "BookingStateLang",
                keyColumn: "Id",
                keyValue: 3,
                column: "Language",
                value: 1);

            migrationBuilder.UpdateData(
                table: "BookingStateLang",
                keyColumn: "Id",
                keyValue: 4,
                column: "Language",
                value: 1);

            migrationBuilder.UpdateData(
                table: "BookingStateLang",
                keyColumn: "Id",
                keyValue: 5,
                column: "Language",
                value: 1);

            migrationBuilder.UpdateData(
                table: "DashboardAdministrationRoleLang",
                keyColumn: "Id",
                keyValue: 1,
                column: "Language",
                value: 1);

            migrationBuilder.InsertData(
                table: "DashboardViews",
                columns: new[] { "Id", "Name", "ViewPath" },
                values: new object[,]
                {
                    { 12, "Country", "Country" },
                    { 13, "Area", "Area" },
                    { 14, "BookingState", "BookingState" },
                    { 15, "HotelType", "HotelType" },
                    { 16, "HotelFeatureCategory", "HotelFeatureCategory" },
                    { 17, "HotelFeature", "HotelFeature" },
                    { 18, "RoomType", "RoomType" },
                    { 19, "RoomFoodType", "RoomFoodType" }
                });

            migrationBuilder.UpdateData(
                table: "HotelTypeLang",
                keyColumn: "Id",
                keyValue: 1,
                column: "Language",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HotelTypeLang",
                keyColumn: "Id",
                keyValue: 2,
                column: "Language",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HotelTypeLang",
                keyColumn: "Id",
                keyValue: 3,
                column: "Language",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HotelTypeLang",
                keyColumn: "Id",
                keyValue: 4,
                column: "Language",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HotelTypeLang",
                keyColumn: "Id",
                keyValue: 5,
                column: "Language",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HotelTypeLang",
                keyColumn: "Id",
                keyValue: 6,
                column: "Language",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RoomFoodTypeLang",
                keyColumn: "Id",
                keyValue: 1,
                column: "Language",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RoomFoodTypeLang",
                keyColumn: "Id",
                keyValue: 2,
                column: "Language",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RoomFoodTypeLang",
                keyColumn: "Id",
                keyValue: 3,
                column: "Language",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RoomFoodTypeLang",
                keyColumn: "Id",
                keyValue: 4,
                column: "Language",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RoomFoodTypeLang",
                keyColumn: "Id",
                keyValue: 5,
                column: "Language",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RoomTypeLang",
                keyColumn: "Id",
                keyValue: 1,
                column: "Language",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RoomTypeLang",
                keyColumn: "Id",
                keyValue: 2,
                column: "Language",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RoomTypeLang",
                keyColumn: "Id",
                keyValue: 3,
                column: "Language",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$AzZFrU3AOdi./aDJdpQwI.8sPZnIOgmRzC16tAVZgX825ONtGSs5S");

            migrationBuilder.InsertData(
                table: "AdministrationRolePremissions",
                columns: new[] { "Id", "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[,]
                {
                    { 12, 1, 1, 12 },
                    { 13, 1, 1, 13 },
                    { 14, 1, 1, 14 },
                    { 15, 1, 1, 15 },
                    { 16, 1, 1, 16 },
                    { 17, 1, 1, 17 },
                    { 18, 1, 1, 18 },
                    { 19, 1, 1, 19 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "DashboardViews",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "DashboardViews",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "DashboardViews",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "DashboardViews",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "DashboardViews",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "DashboardViews",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "DashboardViews",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "DashboardViews",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.UpdateData(
                table: "AccountStateLang",
                keyColumn: "Id",
                keyValue: 1,
                column: "Language",
                value: 0);

            migrationBuilder.UpdateData(
                table: "AccountStateLang",
                keyColumn: "Id",
                keyValue: 2,
                column: "Language",
                value: 0);

            migrationBuilder.UpdateData(
                table: "AccountStateLang",
                keyColumn: "Id",
                keyValue: 3,
                column: "Language",
                value: 0);

            migrationBuilder.InsertData(
                table: "AccountStateLang",
                columns: new[] { "Id", "Fk_Source", "Language", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { 4, 1, 1, null, "Active" },
                    { 5, 2, 1, null, "Pending" },
                    { 6, 3, 1, null, "Ban" }
                });

            migrationBuilder.UpdateData(
                table: "AccountTypeLang",
                keyColumn: "Id",
                keyValue: 1,
                column: "Language",
                value: 0);

            migrationBuilder.InsertData(
                table: "AccountTypeLang",
                columns: new[] { "Id", "Fk_Source", "Language", "LastModifiedBy", "Name" },
                values: new object[] { 2, 1, 1, null, "Client" });

            migrationBuilder.UpdateData(
                table: "BookingStateLang",
                keyColumn: "Id",
                keyValue: 1,
                column: "Language",
                value: 0);

            migrationBuilder.UpdateData(
                table: "BookingStateLang",
                keyColumn: "Id",
                keyValue: 2,
                column: "Language",
                value: 0);

            migrationBuilder.UpdateData(
                table: "BookingStateLang",
                keyColumn: "Id",
                keyValue: 3,
                column: "Language",
                value: 0);

            migrationBuilder.UpdateData(
                table: "BookingStateLang",
                keyColumn: "Id",
                keyValue: 4,
                column: "Language",
                value: 0);

            migrationBuilder.UpdateData(
                table: "BookingStateLang",
                keyColumn: "Id",
                keyValue: 5,
                column: "Language",
                value: 0);

            migrationBuilder.InsertData(
                table: "BookingStateLang",
                columns: new[] { "Id", "Fk_Source", "Language", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { 6, 1, 1, null, "Pending" },
                    { 7, 2, 1, null, "Confirmed" },
                    { 8, 3, 1, null, "Cancelled" },
                    { 9, 4, 1, null, "Completed" },
                    { 10, 5, 1, null, "Refunded" }
                });

            migrationBuilder.UpdateData(
                table: "DashboardAdministrationRoleLang",
                keyColumn: "Id",
                keyValue: 1,
                column: "Language",
                value: 0);

            migrationBuilder.InsertData(
                table: "DashboardAdministrationRoleLang",
                columns: new[] { "Id", "Fk_Source", "Language", "Name" },
                values: new object[] { 2, 1, 1, "Developer" });

            migrationBuilder.UpdateData(
                table: "HotelTypeLang",
                keyColumn: "Id",
                keyValue: 1,
                column: "Language",
                value: 0);

            migrationBuilder.UpdateData(
                table: "HotelTypeLang",
                keyColumn: "Id",
                keyValue: 2,
                column: "Language",
                value: 0);

            migrationBuilder.UpdateData(
                table: "HotelTypeLang",
                keyColumn: "Id",
                keyValue: 3,
                column: "Language",
                value: 0);

            migrationBuilder.UpdateData(
                table: "HotelTypeLang",
                keyColumn: "Id",
                keyValue: 4,
                column: "Language",
                value: 0);

            migrationBuilder.UpdateData(
                table: "HotelTypeLang",
                keyColumn: "Id",
                keyValue: 5,
                column: "Language",
                value: 0);

            migrationBuilder.UpdateData(
                table: "HotelTypeLang",
                keyColumn: "Id",
                keyValue: 6,
                column: "Language",
                value: 0);

            migrationBuilder.InsertData(
                table: "HotelTypeLang",
                columns: new[] { "Id", "Fk_Source", "Language", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { 7, 1, 1, null, "Hotel" },
                    { 8, 2, 1, null, "Resort" },
                    { 9, 3, 1, null, "Apartment" },
                    { 10, 4, 1, null, "Hostel" },
                    { 11, 6, 1, null, "Villa" },
                    { 12, 7, 1, null, "Motel" }
                });

            migrationBuilder.UpdateData(
                table: "RoomFoodTypeLang",
                keyColumn: "Id",
                keyValue: 1,
                column: "Language",
                value: 0);

            migrationBuilder.UpdateData(
                table: "RoomFoodTypeLang",
                keyColumn: "Id",
                keyValue: 2,
                column: "Language",
                value: 0);

            migrationBuilder.UpdateData(
                table: "RoomFoodTypeLang",
                keyColumn: "Id",
                keyValue: 3,
                column: "Language",
                value: 0);

            migrationBuilder.UpdateData(
                table: "RoomFoodTypeLang",
                keyColumn: "Id",
                keyValue: 4,
                column: "Language",
                value: 0);

            migrationBuilder.UpdateData(
                table: "RoomFoodTypeLang",
                keyColumn: "Id",
                keyValue: 5,
                column: "Language",
                value: 0);

            migrationBuilder.InsertData(
                table: "RoomFoodTypeLang",
                columns: new[] { "Id", "Fk_Source", "Language", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { 6, 1, 1, null, "BedAndBreakfast" },
                    { 7, 2, 1, null, "HalfBoard" },
                    { 8, 3, 1, null, "FullBoard" },
                    { 9, 4, 1, null, "AllInclusive" },
                    { 10, 5, 1, null, "RoomOnly" }
                });

            migrationBuilder.UpdateData(
                table: "RoomTypeLang",
                keyColumn: "Id",
                keyValue: 1,
                column: "Language",
                value: 0);

            migrationBuilder.UpdateData(
                table: "RoomTypeLang",
                keyColumn: "Id",
                keyValue: 2,
                column: "Language",
                value: 0);

            migrationBuilder.UpdateData(
                table: "RoomTypeLang",
                keyColumn: "Id",
                keyValue: 3,
                column: "Language",
                value: 0);

            migrationBuilder.InsertData(
                table: "RoomTypeLang",
                columns: new[] { "Id", "Fk_Source", "Language", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { 4, 1, 1, null, "Single" },
                    { 5, 2, 1, null, "Double" },
                    { 6, 3, 1, null, "Triple" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$r9LSvjFsDDf6Oh36T/cUzudbpScFkct6x8qP.pNmtLgcqC7CwX8Cu");
        }
    }
}
