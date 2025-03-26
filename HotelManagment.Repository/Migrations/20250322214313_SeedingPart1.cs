using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelManagment.Repository.Migrations
{
    /// <inheritdoc />
    public partial class SeedingPart1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonalNumber",
                table: "Managers");

            migrationBuilder.AlterColumn<string>(
                name: "IdentityNumber",
                table: "Managers",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 11);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Managers",
                type: "char(50)",
                maxLength: 9,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Address", "City", "Country", "ManagerId", "Name", "Rating" },
                values: new object[,]
                {
                    { 1, "Rustaveli Avenue 12", "Tbilisi", "Georgia", 0, "Grand Palace Hotel", 5 },
                    { 2, "Black Sea Blvd 5", "Batumi", "Georgia", 0, "Luxury Resort", 4 }
                });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "Email", "FirstName", "HotelId", "IdentityNumber", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "giorgi@example.com", "Giorgi", 1, "12345678901", "Beridze", "+995555123456" },
                    { 2, "nino@example.com", "Nino", 2, "98765432109", "Kopaleishvili", "+995599987654" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Free", "GuestId", "HotelId", "Name", "Price" },
                values: new object[,]
                {
                    { 1, true, null, 1, "Deluxe Suite", "150" },
                    { 2, false, null, 1, "Standard Room", "90" },
                    { 3, true, null, 2, "Ocean View Room", "200" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Managers");

            migrationBuilder.AlterColumn<int>(
                name: "IdentityNumber",
                table: "Managers",
                type: "int",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);

            migrationBuilder.AddColumn<string>(
                name: "PersonalNumber",
                table: "Managers",
                type: "char(9)",
                maxLength: 9,
                nullable: false,
                defaultValue: "");
        }
    }
}
