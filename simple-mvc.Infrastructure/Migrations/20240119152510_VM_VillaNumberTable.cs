using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace simple_mvc.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class VM_VillaNumberTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VM_VillaNumber",
                columns: table => new
                {
                    Villa_Number = table.Column<int>(type: "int", nullable: false),
                    VillaID = table.Column<int>(type: "int", nullable: false),
                    SpecialDetails = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VM_VillaNumber", x => x.Villa_Number);
                    table.ForeignKey(
                        name: "FK_VM_VillaNumber_VM_Villa_VillaID",
                        column: x => x.VillaID,
                        principalTable: "VM_Villa",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VM_VillaNumber_VillaID",
                table: "VM_VillaNumber",
                column: "VillaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VM_VillaNumber");
        }
    }
}
