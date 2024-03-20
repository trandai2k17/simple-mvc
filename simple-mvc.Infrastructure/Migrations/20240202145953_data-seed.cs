using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace simple_mvc.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class dataseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "VM_Amenity",
                columns: new[] { "Id", "Description", "Name", "VillaId" },
                values: new object[,]
                {
                    { 1, null, "Private Pool", 1 },
                    { 2, null, "Microwave", 1 },
                    { 3, null, "Private Balcony", 1 },
                    { 4, null, "1 king bed and 1 sofa bed", 1 },
                    { 5, null, "Private Plunge Pool", 2 },
                    { 6, null, "Microwave and Mini Refrigerator", 2 },
                    { 7, null, "Private Balcony", 2 },
                    { 8, null, "king bed or 2 double beds", 2 },
                    { 9, null, "Private Pool", 3 },
                    { 10, null, "Jacuzzi", 3 },
                    { 11, null, "Private Balcony", 3 }
                });

            migrationBuilder.InsertData(
                table: "VM_VillaNumber",
                columns: new[] { "Villa_Number", "SpecialDetails", "VillaID" },
                values: new object[,]
                {
                    { 101, null, 1 },
                    { 102, null, 1 },
                    { 103, null, 1 },
                    { 104, null, 2 },
                    { 105, null, 2 },
                    { 106, null, 2 },
                    { 107, null, 3 },
                    { 108, null, 3 },
                    { 109, null, 3 },
                    { 110, null, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VM_Amenity",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VM_Amenity",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VM_Amenity",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VM_Amenity",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "VM_Amenity",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "VM_Amenity",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "VM_Amenity",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "VM_Amenity",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "VM_Amenity",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "VM_Amenity",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "VM_Amenity",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "VM_VillaNumber",
                keyColumn: "Villa_Number",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "VM_VillaNumber",
                keyColumn: "Villa_Number",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "VM_VillaNumber",
                keyColumn: "Villa_Number",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "VM_VillaNumber",
                keyColumn: "Villa_Number",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "VM_VillaNumber",
                keyColumn: "Villa_Number",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "VM_VillaNumber",
                keyColumn: "Villa_Number",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "VM_VillaNumber",
                keyColumn: "Villa_Number",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "VM_VillaNumber",
                keyColumn: "Villa_Number",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "VM_VillaNumber",
                keyColumn: "Villa_Number",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "VM_VillaNumber",
                keyColumn: "Villa_Number",
                keyValue: 110);
        }
    }
}
