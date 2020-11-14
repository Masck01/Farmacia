using Microsoft.EntityFrameworkCore.Migrations;

namespace FarmaciaAvellaneda.Migrations
{
    public partial class Pago : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK__Pago__BD2295AD89B57E9B",
                table: "Pago");

            migrationBuilder.DropColumn(
                name: "idPago",
                table: "Pago");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Pago",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK__Pago__BD2295AD89B57E9B",
                table: "Pago",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK__Pago__BD2295AD89B57E9B",
                table: "Pago");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Pago");

            migrationBuilder.AddColumn<int>(
                name: "idPago",
                table: "Pago",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK__Pago__BD2295AD89B57E9B",
                table: "Pago",
                column: "idPago");
        }
    }
}
