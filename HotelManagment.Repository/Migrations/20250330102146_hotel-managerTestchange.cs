using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagment.Repository.Migrations
{
    /// <inheritdoc />
    public partial class hotelmanagerTestchange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_Managers_ManagerId",
                table: "Hotels");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_ManagerId",
                table: "Hotels");

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EntryDate", "LeaveDate" },
                values: new object[] { new DateTime(2025, 4, 1, 10, 21, 45, 416, DateTimeKind.Utc).AddTicks(7913), new DateTime(2025, 4, 4, 10, 21, 45, 416, DateTimeKind.Utc).AddTicks(8290) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EntryDate", "LeaveDate" },
                values: new object[] { new DateTime(2025, 4, 2, 10, 21, 45, 416, DateTimeKind.Utc).AddTicks(8554), new DateTime(2025, 4, 6, 10, 21, 45, 416, DateTimeKind.Utc).AddTicks(8555) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "101",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e8b3e930-3605-49b8-9dd8-68a7761caa30", "AQAAAAIAAYagAAAAEAOsEUPTyacB4fqAXpHU2JaIJNDw0KmPV3ohVNahpGdB4lTIw4stE8Cej3PHLqI+eA==", "5dbe1518-e791-4c25-b52d-b14eadaea8fc" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "102",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7bdd3399-2a56-48cf-b226-771392e39f74", "AQAAAAIAAYagAAAAEGOjX97jSqSSDL7in2YJVg2PjywhHJX95d5wTlGKLRs4jVtH6QWjS7XbJAHB+plWIg==", "e4262d9b-b7ed-45e7-bc50-7bff55c3e67a" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "103",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8e604534-8fce-4905-9e3f-400c3bba34e1", "AQAAAAIAAYagAAAAEPoLwzeTjYsvp512gKBPwl5sXJIpArLNC716KNT9neDuWbzBnDeq9Nvpizae9vu6iw==", "742508fe-624f-4aa9-b3f9-7e84d8f41fe1" });

            migrationBuilder.CreateIndex(
                name: "IX_Managers_HotelId",
                table: "Managers",
                column: "HotelId",
                unique: true,
                filter: "[HotelId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Managers_Hotels_HotelId",
                table: "Managers",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Managers_Hotels_HotelId",
                table: "Managers");

            migrationBuilder.DropIndex(
                name: "IX_Managers_HotelId",
                table: "Managers");

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EntryDate", "LeaveDate" },
                values: new object[] { new DateTime(2025, 4, 1, 9, 29, 53, 291, DateTimeKind.Utc).AddTicks(3568), new DateTime(2025, 4, 4, 9, 29, 53, 291, DateTimeKind.Utc).AddTicks(3948) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EntryDate", "LeaveDate" },
                values: new object[] { new DateTime(2025, 4, 2, 9, 29, 53, 291, DateTimeKind.Utc).AddTicks(4217), new DateTime(2025, 4, 6, 9, 29, 53, 291, DateTimeKind.Utc).AddTicks(4218) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "101",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0d452800-8e73-4175-9602-508620cd0532", "AQAAAAIAAYagAAAAEKQT8LX1UzVA9LkrtptfuFYIDk8fJq6ykReLQTFu8+p+s+p2YcNOX5Y6axtnomx9Vw==", "fd49c68a-90ca-4ebd-a4a4-67a022b51bae" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "102",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "373dc9c8-9a3c-48cd-b927-dd7a83ad60cb", "AQAAAAIAAYagAAAAEH+NvjJjjKZizGEhoBAEaVKUc0MhbLyxLgUebb0dg8XZZ32Q5SWZB96r8oUY27qbew==", "14061216-a779-4cad-8c9b-5a5730e2faff" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "103",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eec25bb8-85fa-47b5-98ed-e1e037709813", "AQAAAAIAAYagAAAAELkNpHzc05S2SKSMSH1oNR6K2BtmgDv+2XmUO56ou+33Xv6F6aNQxShsjPkeH4gx0A==", "3ea93112-ba5f-470b-8e2c-6738cde77cdc" });

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_ManagerId",
                table: "Hotels",
                column: "ManagerId",
                unique: true,
                filter: "[ManagerId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_Managers_ManagerId",
                table: "Hotels",
                column: "ManagerId",
                principalTable: "Managers",
                principalColumn: "Id");
        }
    }
}
