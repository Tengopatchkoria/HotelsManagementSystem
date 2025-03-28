using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagment.Repository.Migrations
{
    /// <inheritdoc />
    public partial class seedUsersFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EntryDate", "LeaveDate" },
                values: new object[] { new DateTime(2025, 3, 30, 9, 10, 12, 344, DateTimeKind.Utc).AddTicks(5119), new DateTime(2025, 4, 2, 9, 10, 12, 344, DateTimeKind.Utc).AddTicks(5508) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EntryDate", "LeaveDate" },
                values: new object[] { new DateTime(2025, 3, 31, 9, 10, 12, 344, DateTimeKind.Utc).AddTicks(5780), new DateTime(2025, 4, 4, 9, 10, 12, 344, DateTimeKind.Utc).AddTicks(5781) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "101",
                columns: new[] { "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IdentityNumber", "LastName", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b2b8679e-b45f-4645-bf6d-0c6c9af8f590", null, false, "admin", "00201071653", "admingero", null, "AQAAAAIAAYagAAAAEOs/TFG18vMOXfKhshxVbfLY4h5UXarxc7y5MrT1MXEwth6xl6daQXN0djdrJH5Uzg==", "67a11ac5-2174-421d-9dc7-1e6eed4c2c1d" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "102",
                columns: new[] { "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IdentityNumber", "LastName", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5fcc542f-1dc0-432c-ae8c-bb8fbea83f5a", null, false, "manager", "00201071653", "mangero", null, "AQAAAAIAAYagAAAAELglDWk5kHT1Ih2zDYnvMnEdQ0vUpDHbD2KQ8tkUCn/TlCWSuXzxr6xwce/d/3YDbA==", "1460b0c5-6496-488e-a986-afd13e7a88b0" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "103",
                columns: new[] { "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IdentityNumber", "LastName", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5791fde7-02b6-41d4-b334-338d6b3dccbb", null, false, "guest", "10201171653", "guestgero", null, "AQAAAAIAAYagAAAAEOm52/ohr3cFe7VIbBMUdAnRnGgB9mc8nBiDuTvByKbt3Z7rDdZ9HUkgPfgbUM5Qpg==", "29cd74b9-c44c-4965-a2e3-fd45040aeb0c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EntryDate", "LeaveDate" },
                values: new object[] { new DateTime(2025, 3, 30, 8, 58, 4, 133, DateTimeKind.Utc).AddTicks(7582), new DateTime(2025, 4, 2, 8, 58, 4, 133, DateTimeKind.Utc).AddTicks(7962) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EntryDate", "LeaveDate" },
                values: new object[] { new DateTime(2025, 3, 31, 8, 58, 4, 133, DateTimeKind.Utc).AddTicks(8258), new DateTime(2025, 4, 4, 8, 58, 4, 133, DateTimeKind.Utc).AddTicks(8259) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "101",
                columns: new[] { "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IdentityNumber", "LastName", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "218c677d-6588-4a22-925e-1f1aa1ca724a", "admin@example.com", true, null, null, null, "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAENXaZyawagrLa1BitoYNDb7OIq/uOddyzAMzTnNq3hacQbU9O5l9nNa+0uulteGzFQ==", "9e0d1bf0-6093-4b5d-bf38-b2ef9f3ec0fe" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "102",
                columns: new[] { "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IdentityNumber", "LastName", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f8194aa4-18f5-4f74-aeb6-b600e93e792a", "manager@example.com", true, null, null, null, "MANAGER@EXAMPLE.COM", "AQAAAAIAAYagAAAAEK5lKylTLSb8xRHuxILcmgQiZyxWY827a96T+s4AIZ2lJe2I9FDnDahxsEFNWbnxpQ==", "4a0d2c08-bd5d-4b5b-b8b8-f0cc6002cc40" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "103",
                columns: new[] { "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IdentityNumber", "LastName", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e7f80cf8-d208-4cd4-91c0-713cddc0b718", "guest@example.com", true, null, null, null, "GUEST@EXAMPLE.COM", "AQAAAAIAAYagAAAAEJ3jUNic0rC5ci+H/AwlCjJ1tA74Ng734/LeVIEwhi1pkcW/71ceqbg2WaCKzsgCXw==", "c7a6dfa8-043b-4e73-89d4-7978d41efeae" });
        }
    }
}
