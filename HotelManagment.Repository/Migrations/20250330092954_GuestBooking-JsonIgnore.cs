using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagment.Repository.Migrations
{
    /// <inheritdoc />
    public partial class GuestBookingJsonIgnore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
