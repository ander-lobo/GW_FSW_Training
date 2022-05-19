using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gcsb.Connect.Training.Infrastructure.Database.Migrations
{
    public partial class IndexCpfUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Customers_Cpf",
                table: "Customers",
                column: "Cpf",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customers_Cpf",
                table: "Customers");
        }
    }
}
