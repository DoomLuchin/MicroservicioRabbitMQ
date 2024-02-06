using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroQueue.Consumer.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MailQueues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Body = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    IdUsuarioLog = table.Column<string>(type: "varchar(16)", nullable: false),
                    MessageResponse = table.Column<string>(type: "varchar(64)", nullable: false),
                    StatusResponse = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailQueues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ManifiestoQueues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JsonMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Printer = table.Column<string>(type: "varchar(64)", nullable: false),
                    IdUsuarioLog = table.Column<string>(type: "varchar(16)", nullable: false),
                    MessageResponse = table.Column<string>(type: "varchar(64)", nullable: false),
                    StatusResponse = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManifiestoQueues", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MailQueues");

            migrationBuilder.DropTable(
                name: "ManifiestoQueues");
        }
    }
}
