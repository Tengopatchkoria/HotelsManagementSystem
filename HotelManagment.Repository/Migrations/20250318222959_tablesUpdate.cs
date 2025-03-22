using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagment.Repository.Migrations
{
    /// <inheritdoc />
    public partial class tablesUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PersonalNumber",
                table: "Guests",
                newName: "PhoneNumber");

            migrationBuilder.AddColumn<int>(
                name: "GuestId",
                table: "RoomNums",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "Hotels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RoomNums_GuestId",
                table: "RoomNums",
                column: "GuestId",
                unique: true,
                filter: "[GuestId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomNums_Guests_GuestId",
                table: "RoomNums",
                column: "GuestId",
                principalTable: "Guests",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomNums_Guests_GuestId",
                table: "RoomNums");

            migrationBuilder.DropIndex(
                name: "IX_RoomNums_GuestId",
                table: "RoomNums");

            migrationBuilder.DropColumn(
                name: "GuestId",
                table: "RoomNums");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Hotels");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Guests",
                newName: "PersonalNumber");
        }
    }
}
