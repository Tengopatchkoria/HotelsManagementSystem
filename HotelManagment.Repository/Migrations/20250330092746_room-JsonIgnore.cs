using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagment.Repository.Migrations
{
    /// <inheritdoc />
    public partial class roomJsonIgnore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EntryDate", "LeaveDate" },
                values: new object[] { new DateTime(2025, 4, 1, 9, 27, 45, 557, DateTimeKind.Utc).AddTicks(4958), new DateTime(2025, 4, 4, 9, 27, 45, 557, DateTimeKind.Utc).AddTicks(5335) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EntryDate", "LeaveDate" },
                values: new object[] { new DateTime(2025, 4, 2, 9, 27, 45, 557, DateTimeKind.Utc).AddTicks(5596), new DateTime(2025, 4, 6, 9, 27, 45, 557, DateTimeKind.Utc).AddTicks(5598) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "101",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6c2a6523-78e3-4b7f-919e-bfdd68956b95", "AQAAAAIAAYagAAAAEB/1uvDHqmAJ1PdBVOEAfptK4FJQyMGWUiEoks+5nQqBJHF6TA8DtcQn5kPmC5MiRg==", "a9aff6ce-357e-40ee-8afd-fb07df06927d" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "102",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dfc7fa5d-7ed4-4d20-becf-44323411254f", "AQAAAAIAAYagAAAAEEyTt6yHCiXWN9w4rGM0CPYfFFEXM8a4HT9CRhoUDrKJyEH/rsIRQdaspl6cOianGg==", "04dc5837-15a6-4ffd-8c78-265d053adcdd" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "103",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "025bbd27-01f9-4b98-9664-f177ac3ef43c", "AQAAAAIAAYagAAAAEN9D5DCAogbsT3kpABGl+RM7meN8jrewgEI5lUmjvshm9X1cfwzt3mrY5a9LRnEtcA==", "0e7dba12-98f9-4899-ad70-dd49cb7e9e01" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
