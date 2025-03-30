using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagment.Repository.Migrations
{
    /// <inheritdoc />
    public partial class StartRe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Managers_Hotels_HotelId",
                table: "Managers");

            migrationBuilder.DropIndex(
                name: "IX_Managers_HotelId",
                table: "Managers");

            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "Hotels",
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
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1,
                column: "ManagerId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2,
                column: "ManagerId",
                value: 2);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_Managers_ManagerId",
                table: "Hotels");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_ManagerId",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Hotels");

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

            migrationBuilder.CreateIndex(
                name: "IX_Managers_HotelId",
                table: "Managers",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Managers_Hotels_HotelId",
                table: "Managers",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id");
        }
    }
}
