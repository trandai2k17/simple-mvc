using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace simple_mvc.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VM_Amenity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VillaId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VM_Amenity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VM_Amenity_VM_Villa_VillaId",
                        column: x => x.VillaId,
                        principalTable: "VM_Villa",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VM_Booking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VillaId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalCost = table.Column<double>(type: "float", nullable: false),
                    Nights = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckInDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CheckOutDate = table.Column<DateOnly>(type: "date", nullable: false),
                    IsPaymentSuccessful = table.Column<bool>(type: "bit", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StripeSessionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StripePaymentIntentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActualCheckInDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualCheckOutDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VillaNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VM_Booking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VM_Booking_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VM_Booking_VM_Villa_VillaId",
                        column: x => x.VillaId,
                        principalTable: "VM_Villa",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VM_Amenity_VillaId",
                table: "VM_Amenity",
                column: "VillaId");

            migrationBuilder.CreateIndex(
                name: "IX_VM_Booking_UserId",
                table: "VM_Booking",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_VM_Booking_VillaId",
                table: "VM_Booking",
                column: "VillaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VM_Amenity");

            migrationBuilder.DropTable(
                name: "VM_Booking");
        }
    }
}
