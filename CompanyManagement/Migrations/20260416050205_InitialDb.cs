using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyManagement.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "COMPANY",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMPANY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "USER",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    full_name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    COMPANY_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_USER_COMPANY_COMPANY_id",
                        column: x => x.COMPANY_id,
                        principalTable: "COMPANY",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_USER_COMPANY_id",
                table: "USER",
                column: "COMPANY_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "USER");

            migrationBuilder.DropTable(
                name: "COMPANY");
        }
    }
}
