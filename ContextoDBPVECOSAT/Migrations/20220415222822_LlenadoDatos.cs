using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContextoDBPVECOSAT.Migrations
{
    public partial class LlenadoDatos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Tienda",
                table: "Departamentos",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Abarrotes" },
                    { 2, "Ropa" },
                    { 3, "Dulceria" },
                    { 4, "Panaderia" }
                });

            migrationBuilder.InsertData(
                schema: "Catalogo",
                table: "RolUsuarios",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Cajero" },
                    { 2, "Supervisor" }
                });

            migrationBuilder.InsertData(
                schema: "Tienda",
                table: "Productos",
                columns: new[] { "Id", "DepartamentoId", "Descripcion", "Precio" },
                values: new object[,]
                {
                    { 1, 1, "Azucar", 25.50m },
                    { 2, 1, "Lata Atún", 14.00m },
                    { 3, 2, "Pantalon Hombre", 299.00m },
                    { 4, 2, "Pantalon Mujer", 399.00m },
                    { 5, 3, "Chocolate", 20.00m },
                    { 6, 3, "Chicle", 5.00m },
                    { 7, 4, "Dona Cholate", 7.00m },
                    { 8, 4, "Pan Blanco", 5.50m }
                });

            migrationBuilder.InsertData(
                schema: "Catalogo",
                table: "Usuarios",
                columns: new[] { "Id", "NombreUsuario", "Password", "RolUsuarioId" },
                values: new object[,]
                {
                    { 1, "Damián", "pventa1", 1 },
                    { 2, "David", "pventa2", 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Tienda",
                table: "Productos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Tienda",
                table: "Productos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Tienda",
                table: "Productos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Tienda",
                table: "Productos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "Tienda",
                table: "Productos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "Tienda",
                table: "Productos",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "Tienda",
                table: "Productos",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "Tienda",
                table: "Productos",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "Catalogo",
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Catalogo",
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Tienda",
                table: "Departamentos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Tienda",
                table: "Departamentos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Tienda",
                table: "Departamentos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Tienda",
                table: "Departamentos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "Catalogo",
                table: "RolUsuarios",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Catalogo",
                table: "RolUsuarios",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
