using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagment.Repository.Migrations
{
    /// <inheritdoc />
    public partial class guestbookingroomChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Guests_GuestId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_GuestId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "GuestId",
                table: "Rooms");

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EntryDate", "LeaveDate" },
                values: new object[] { new DateTime(2025, 4, 1, 8, 1, 52, 5, DateTimeKind.Utc).AddTicks(2598), new DateTime(2025, 4, 4, 8, 1, 52, 5, DateTimeKind.Utc).AddTicks(2994) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EntryDate", "LeaveDate" },
                values: new object[] { new DateTime(2025, 4, 2, 8, 1, 52, 5, DateTimeKind.Utc).AddTicks(3252), new DateTime(2025, 4, 6, 8, 1, 52, 5, DateTimeKind.Utc).AddTicks(3253) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "101",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7ebdefb7-11c0-4c80-bc35-264d29d8b73f", "AQAAAAIAAYagAAAAEMIEgDlO2dTOFYbRvRlxMH34l44ey0s2tdKzK7Ojwo9jpejGdquonQa6siTjKRXy0w==", "88fc09ba-2561-404d-a6df-2f80d0b7dad6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "102",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "91631773-c6b6-4c25-95a0-9f9a538288f0", "AQAAAAIAAYagAAAAEJjnaTA9bNIcpy2Ub/SVmNei1TrTZvakkCSvq5KM4MbRgCpNOpufFg7bio8M9wqmbw==", "79a68e88-07cc-4e42-9aea-3e017acc9f5c" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "103",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c1c188d8-f4b8-4d3e-bb32-fa663169fb63", "AQAAAAIAAYagAAAAEJZ3AoajeZdBLvZH6zPUREg6RMppRuYIh/oQcP9cAjWxJhBAHcLoNk31m/Lyu3uFVw==", "f8768089-8313-458e-b432-1c90a7358a60" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GuestId",
                table: "Rooms",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EntryDate", "LeaveDate" },
                values: new object[] { new DateTime(2025, 4, 1, 6, 4, 26, 24, DateTimeKind.Utc).AddTicks(3642), new DateTime(2025, 4, 4, 6, 4, 26, 24, DateTimeKind.Utc).AddTicks(4018) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EntryDate", "LeaveDate" },
                values: new object[] { new DateTime(2025, 4, 2, 6, 4, 26, 24, DateTimeKind.Utc).AddTicks(4277), new DateTime(2025, 4, 6, 6, 4, 26, 24, DateTimeKind.Utc).AddTicks(4278) });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1,
                column: "GuestId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2,
                column: "GuestId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3,
                column: "GuestId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "101",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "89594808-6a0b-4c0f-96d4-3809a5ad8580", "AQAAAAIAAYagAAAAEKYtfffdY82VFwN9HueVlZs+hCbZ/5YUEUaKiNe1jBVSRQCoi52nO0qS9ckyTdOnQQ==", "0832e189-5eea-4c39-95a0-420ff2958c8c" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "102",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1d93348d-58eb-4501-97d9-ad89d85bd498", "AQAAAAIAAYagAAAAEL5bzRoFty5T++GfLagWSAoee58QiNYGi/HYBVG/dXZ3bVxagAG4CPjRF91vqwL7OQ==", "bdcf3064-27fb-435e-bcd5-350b618afe45" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "103",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "852d96c9-4a7b-4f88-85ea-e0b6d4c4274d", "AQAAAAIAAYagAAAAEGCw8WKK/Hp2SXY3jPB8X6KbRZfGeQU3s+WM9yVGFxR1748y62B5HZYIZ0hrKEAahg==", "c1a256a0-0b95-4f30-a663-9e08ed62e57e" });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_GuestId",
                table: "Rooms",
                column: "GuestId",
                unique: true,
                filter: "[GuestId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Guests_GuestId",
                table: "Rooms",
                column: "GuestId",
                principalTable: "Guests",
                principalColumn: "Id");
        }
    }
}
