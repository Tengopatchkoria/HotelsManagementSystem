using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagment.Repository.Migrations
{
    /// <inheritdoc />
    public partial class managerHotelNullTes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EntryDate", "LeaveDate" },
                values: new object[] { new DateTime(2025, 3, 30, 11, 56, 45, 267, DateTimeKind.Utc).AddTicks(2233), new DateTime(2025, 4, 2, 11, 56, 45, 267, DateTimeKind.Utc).AddTicks(2619) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EntryDate", "LeaveDate" },
                values: new object[] { new DateTime(2025, 3, 31, 11, 56, 45, 267, DateTimeKind.Utc).AddTicks(2880), new DateTime(2025, 4, 4, 11, 56, 45, 267, DateTimeKind.Utc).AddTicks(2881) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "101",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0db7cf62-31ab-432f-9588-bd0d9d246b97", "AQAAAAIAAYagAAAAEOn3nZ3iVPiE4SFNw+nMZlCtQ36QSzRiqN4bv6qwK7JcA0smasDSAAZYfEzDQy2WhA==", "688b4ea0-4b38-4cc3-a024-a7b5cc74e9b7" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "102",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a02ee63-1a28-464d-bbf7-5479ec9905b4", "AQAAAAIAAYagAAAAEFe8FC3hb8hM5xTqGLh/OwwS8rxupRmZRWAkq44Hbq1vFanNkp1JXemVLDpRdTsx6g==", "d9df42b0-d8ab-4143-9de6-d067ed4d4adf" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "103",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b8d3a100-6b39-4ead-a6cb-aabffe73405a", "AQAAAAIAAYagAAAAENBqsNuHdxD+AVr/0mDCnB34tVjecICC4KDdJDyHD6xx5xvdSoRQfT9GakGaxqtjow==", "97cbee99-2e35-42d3-b52f-d763625bb6db" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EntryDate", "LeaveDate" },
                values: new object[] { new DateTime(2025, 3, 30, 10, 47, 20, 599, DateTimeKind.Utc).AddTicks(5861), new DateTime(2025, 4, 2, 10, 47, 20, 599, DateTimeKind.Utc).AddTicks(6238) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EntryDate", "LeaveDate" },
                values: new object[] { new DateTime(2025, 3, 31, 10, 47, 20, 599, DateTimeKind.Utc).AddTicks(6554), new DateTime(2025, 4, 4, 10, 47, 20, 599, DateTimeKind.Utc).AddTicks(6555) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "101",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "18e80b76-c519-4289-89d5-78681f6dd2e0", "AQAAAAIAAYagAAAAEJdAYyh7LQOny3GUCzbCT/H0ATwtihuizj8UMD2A62BwVCbQ8CMtnN6wjNP4aLrfnQ==", "008931d8-39c4-4a5f-89ab-964eb02d0f69" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "102",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "61c37415-a77b-462c-a349-d6d07dc8dbe4", "AQAAAAIAAYagAAAAEBUnkISlb8o4Q8ssuuH7CrY+2/LVnqcxlO1yY7rOUz1PjvhjMzKh8TdDETGwtJZXcA==", "51f6f053-1a9d-4eef-8d33-07b111a17425" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "103",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "384b3c7f-992e-4370-9468-18b32ac7b10f", "AQAAAAIAAYagAAAAEL6xXBv8IegPPByXcGzxE59+tTWtVWoLXSTQOQJ78uucbtFWoBcjOChzDvsJWux/bw==", "db3809ec-1f20-4526-ae23-c15049dccd50" });
        }
    }
}
