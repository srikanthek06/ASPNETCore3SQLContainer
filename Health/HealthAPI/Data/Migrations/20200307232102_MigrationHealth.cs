using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthAPI.Data.Migrations
{
    public partial class MigrationHealth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    PatientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.PatientId);
                });

            migrationBuilder.CreateTable(
                name: "Ailment",
                columns: table => new
                {
                    Name = table.Column<string>(maxLength: 40, nullable: false),
                    PatientId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ailment", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Ailment_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Medication",
                columns: table => new
                {
                    Name = table.Column<string>(maxLength: 40, nullable: false),
                    Doses = table.Column<string>(nullable: true),
                    PatientId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medication", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Medication_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ailment_PatientId",
                table: "Ailment",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Medication_PatientId",
                table: "Medication",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ailment");

            migrationBuilder.DropTable(
                name: "Medication");

            migrationBuilder.DropTable(
                name: "Patient");
        }
    }
}
