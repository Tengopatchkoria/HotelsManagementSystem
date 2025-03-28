using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelManagment.Repository.Migrations
{
    /// <inheritdoc />
    public partial class MxMGuestbooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Guests_GuestId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Rooms_RoomId",
                table: "Bookings");

            migrationBuilder.DropTable(
                name: "HotelBookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_GuestId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "GuestId",
                table: "Bookings");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Guests",
                type: "char(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(9)",
                oldMaxLength: 9);

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "GuestBookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuestId = table.Column<int>(type: "int", nullable: false),
                    BookingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestBookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuestBookings_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GuestBookings_Guests_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Guests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "EntryDate", "LeaveDate", "RoomId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 30, 8, 58, 4, 133, DateTimeKind.Utc).AddTicks(7582), new DateTime(2025, 4, 2, 8, 58, 4, 133, DateTimeKind.Utc).AddTicks(7962), 1 },
                    { 2, new DateTime(2025, 3, 31, 8, 58, 4, 133, DateTimeKind.Utc).AddTicks(8258), new DateTime(2025, 4, 4, 8, 58, 4, 133, DateTimeKind.Utc).AddTicks(8259), 2 }
                });

            migrationBuilder.InsertData(
                table: "Guests",
                columns: new[] { "Id", "FirstName", "IdentityNumber", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "John", "12345678901", "Doe", "+995599111111" },
                    { 2, "Alice", "98765432109", "Smith", "+995599222222" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", null, "Admin", "ADMIN" },
                    { "2", null, "Manager", "MANAGER" },
                    { "3", null, "Guest", "GUEST" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IdentityNumber", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "101", 0, "218c677d-6588-4a22-925e-1f1aa1ca724a", "admin@example.com", true, null, null, null, false, null, "ADMIN@EXAMPLE.COM", "ADMIN", "AQAAAAIAAYagAAAAENXaZyawagrLa1BitoYNDb7OIq/uOddyzAMzTnNq3hacQbU9O5l9nNa+0uulteGzFQ==", null, false, "9e0d1bf0-6093-4b5d-bf38-b2ef9f3ec0fe", false, "admin" },
                    { "102", 0, "f8194aa4-18f5-4f74-aeb6-b600e93e792a", "manager@example.com", true, null, null, null, false, null, "MANAGER@EXAMPLE.COM", "MANAGER", "AQAAAAIAAYagAAAAEK5lKylTLSb8xRHuxILcmgQiZyxWY827a96T+s4AIZ2lJe2I9FDnDahxsEFNWbnxpQ==", null, false, "4a0d2c08-bd5d-4b5b-b8b8-f0cc6002cc40", false, "manager" },
                    { "103", 0, "e7f80cf8-d208-4cd4-91c0-713cddc0b718", "guest@example.com", true, null, null, null, false, null, "GUEST@EXAMPLE.COM", "GUEST", "AQAAAAIAAYagAAAAEJ3jUNic0rC5ci+H/AwlCjJ1tA74Ng734/LeVIEwhi1pkcW/71ceqbg2WaCKzsgCXw==", null, false, "c7a6dfa8-043b-4e73-89d4-7978d41efeae", false, "guest" }
                });

            migrationBuilder.InsertData(
                table: "GuestBookings",
                columns: new[] { "Id", "BookingId", "GuestId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "101" },
                    { "2", "102" },
                    { "3", "103" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GuestBookings_BookingId",
                table: "GuestBookings",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_GuestBookings_GuestId",
                table: "GuestBookings",
                column: "GuestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Rooms_RoomId",
                table: "Bookings",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Rooms_RoomId",
                table: "Bookings");

            migrationBuilder.DropTable(
                name: "GuestBookings");

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Guests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Guests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "101" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "102" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3", "103" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "101");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "102");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "103");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Guests",
                type: "char(9)",
                maxLength: 9,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "Bookings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "GuestId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "HotelBookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelBookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelBookings_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotelBookings_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_GuestId",
                table: "Bookings",
                column: "GuestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HotelBookings_BookingId",
                table: "HotelBookings",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelBookings_HotelId",
                table: "HotelBookings",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Guests_GuestId",
                table: "Bookings",
                column: "GuestId",
                principalTable: "Guests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Rooms_RoomId",
                table: "Bookings",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");
        }
    }
}
