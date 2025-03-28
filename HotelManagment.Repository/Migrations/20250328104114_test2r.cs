using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagment.Repository.Migrations
{
    /// <inheritdoc />
    public partial class test2r : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EntryDate", "LeaveDate" },
                values: new object[] { new DateTime(2025, 3, 30, 10, 41, 13, 395, DateTimeKind.Utc).AddTicks(1239), new DateTime(2025, 4, 2, 10, 41, 13, 395, DateTimeKind.Utc).AddTicks(1599) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EntryDate", "LeaveDate" },
                values: new object[] { new DateTime(2025, 3, 31, 10, 41, 13, 395, DateTimeKind.Utc).AddTicks(1868), new DateTime(2025, 4, 4, 10, 41, 13, 395, DateTimeKind.Utc).AddTicks(1869) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "101",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "50d36e93-c374-4e6c-8b36-9f3ad7f02d37", "AQAAAAIAAYagAAAAENsJridOnMNA/WEzBO3w7yDz8M0qK2tu3f5F7uRaxa1qUN+mpGL632iHGe6wDAOhJw==", "33ca0f87-681f-430a-8158-54312b13cd7a" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "102",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5f42c5c7-397a-404b-9693-6990831efa3a", "AQAAAAIAAYagAAAAEAkU2plAcuI1YIm2azqcfUMM5AtVq4nS2i3jBUghXddFzCsw+RmF1msAdYqvYsvn9A==", "a1f3e572-49ea-40d6-860d-cd54c7e6e491" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "103",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "036d9fd5-9819-45f4-aa94-43e5f678b8c7", "AQAAAAIAAYagAAAAEJVqaL/gcASLJcXKnqGIR68SR50cKxR5im5pt59UeiwwREdyg+gxPDdWnJwu5I9IEw==", "f131a89b-f5ba-4f35-bcf9-f931015d0198" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
