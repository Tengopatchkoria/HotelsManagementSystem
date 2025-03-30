using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagment.Repository.Migrations
{
    /// <inheritdoc />
    public partial class hotelManagerIdNOtNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ManagerId",
                table: "Hotels",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EntryDate", "LeaveDate" },
                values: new object[] { new DateTime(2025, 4, 1, 10, 54, 51, 998, DateTimeKind.Utc).AddTicks(8535), new DateTime(2025, 4, 4, 10, 54, 51, 998, DateTimeKind.Utc).AddTicks(8912) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EntryDate", "LeaveDate" },
                values: new object[] { new DateTime(2025, 4, 2, 10, 54, 51, 998, DateTimeKind.Utc).AddTicks(9174), new DateTime(2025, 4, 6, 10, 54, 51, 998, DateTimeKind.Utc).AddTicks(9175) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "101",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "68d03901-5902-410b-bb05-ea0fdce52fec", "AQAAAAIAAYagAAAAEJljNneYRgF7DwzLTzpmTGbPYrgudaJzQOB40XguHcqM5VU/ZRUrkR+ZScFJpFMIZg==", "bcdb48d2-12dd-424a-b402-65939c6e0b29" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "102",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "810663c4-86de-41b5-af7e-1c7310ba54d8", "AQAAAAIAAYagAAAAEPj65W9HBv0Vph8j18/ziOlOscDRIQTye32A2NCJde26NrZJBarewG/ggKTQaGy+Pg==", "7facafa2-3a1c-42da-a47a-37df74cd7551" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "103",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a23ce6e0-8b62-46cd-b9a4-911ad1cf8b38", "AQAAAAIAAYagAAAAEA/1hm5T4niIt2WqJ8kXSkHj6y8sUnbMY1tFEaApgm54Q/qXQ8+dEFSoy8Ku4mRSqQ==", "deff02b3-2d7c-4f2b-b320-7325f3436632" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ManagerId",
                table: "Hotels",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
        }
    }
}
