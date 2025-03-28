using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagment.Repository.Migrations
{
    /// <inheritdoc />
    public partial class managerHotelNullTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Managers_Hotels_HotelId",
                table: "Managers");

            migrationBuilder.AlterColumn<int>(
                name: "HotelId",
                table: "Managers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AlterColumn<int>(
                name: "HotelId",
                table: "Managers",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Managers_Hotels_HotelId",
                table: "Managers",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
