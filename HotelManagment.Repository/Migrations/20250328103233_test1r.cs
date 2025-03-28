using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagment.Repository.Migrations
{
    /// <inheritdoc />
    public partial class test1r : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EntryDate", "LeaveDate" },
                values: new object[] { new DateTime(2025, 3, 30, 10, 32, 32, 611, DateTimeKind.Utc).AddTicks(7240), new DateTime(2025, 4, 2, 10, 32, 32, 611, DateTimeKind.Utc).AddTicks(7622) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EntryDate", "LeaveDate" },
                values: new object[] { new DateTime(2025, 3, 31, 10, 32, 32, 611, DateTimeKind.Utc).AddTicks(7915), new DateTime(2025, 4, 4, 10, 32, 32, 611, DateTimeKind.Utc).AddTicks(7916) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "101",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ef0fd433-f09c-4eaa-a2df-8749f318b111", "AQAAAAIAAYagAAAAEDz7I/C9bMVB5V8M1M8HbTLK63zFaX0F8v2UmA2nkqVhBzYa2rk7O6QhOxVtUk5pIQ==", "67b89259-c8aa-4b3e-9ff3-a959b750ff8f" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "102",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "925de7ae-bc11-4ce4-9c16-1794175ef1bc", "AQAAAAIAAYagAAAAEJ/AMd3V3lIEczRlu2vyAOsTrVCjDUNd6YGYmj5cdDAuRNoKaSznfr2+mC9il6W0Ow==", "81bc02fe-b6b2-45b7-ae6c-08dce56fd09f" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "103",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "855b273b-9cd9-4aa6-9a07-ad8b4c7b4b36", "AQAAAAIAAYagAAAAEK80s+ZhCAdZjuMPkxpO28qS43qU89Td0UCz1Jj/lp6zRWDfoyccnHVi6wjCMDOwyw==", "939781de-ccae-4636-9992-bd256de1b895" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b2b8679e-b45f-4645-bf6d-0c6c9af8f590", "AQAAAAIAAYagAAAAEOs/TFG18vMOXfKhshxVbfLY4h5UXarxc7y5MrT1MXEwth6xl6daQXN0djdrJH5Uzg==", "67a11ac5-2174-421d-9dc7-1e6eed4c2c1d" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "102",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5fcc542f-1dc0-432c-ae8c-bb8fbea83f5a", "AQAAAAIAAYagAAAAELglDWk5kHT1Ih2zDYnvMnEdQ0vUpDHbD2KQ8tkUCn/TlCWSuXzxr6xwce/d/3YDbA==", "1460b0c5-6496-488e-a986-afd13e7a88b0" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "103",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5791fde7-02b6-41d4-b334-338d6b3dccbb", "AQAAAAIAAYagAAAAEOm52/ohr3cFe7VIbBMUdAnRnGgB9mc8nBiDuTvByKbt3Z7rDdZ9HUkgPfgbUM5Qpg==", "29cd74b9-c44c-4965-a2e3-fd45040aeb0c" });
        }
    }
}
