using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContextoDBPVECOSAT.Migrations
{
    public partial class _15042022_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Ventas",
                table: "Ventas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubVentas",
                table: "SubVentas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RolUsuarios",
                table: "RolUsuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Productos",
                table: "Productos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departamentos",
                table: "Departamentos");

            migrationBuilder.DropColumn(
                name: "ListaSubVentaId",
                table: "Ventas");

            migrationBuilder.EnsureSchema(
                name: "RolUsuarios");

            migrationBuilder.EnsureSchema(
                name: "Usuarios");

            migrationBuilder.EnsureSchema(
                name: "Departamentos");

            migrationBuilder.EnsureSchema(
                name: "Productos");

            migrationBuilder.EnsureSchema(
                name: "SubVentas");

            migrationBuilder.EnsureSchema(
                name: "Venta");

            migrationBuilder.RenameTable(
                name: "Ventas",
                newName: "Venta",
                newSchema: "Venta");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "Catalogo",
                newSchema: "Usuarios");

            migrationBuilder.RenameTable(
                name: "SubVentas",
                newName: "Venta",
                newSchema: "SubVentas");

            migrationBuilder.RenameTable(
                name: "RolUsuarios",
                newName: "Catalogo",
                newSchema: "RolUsuarios");

            migrationBuilder.RenameTable(
                name: "Productos",
                newName: "Tienda",
                newSchema: "Productos");

            migrationBuilder.RenameTable(
                name: "Departamentos",
                newName: "Tienda",
                newSchema: "Departamentos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Venta",
                schema: "Venta",
                table: "Venta",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Catalogo",
                schema: "Usuarios",
                table: "Catalogo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Venta",
                schema: "SubVentas",
                table: "Venta",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Catalogo",
                schema: "RolUsuarios",
                table: "Catalogo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tienda",
                schema: "Productos",
                table: "Tienda",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tienda",
                schema: "Departamentos",
                table: "Tienda",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_UsuarioId",
                schema: "Venta",
                table: "Venta",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalogo_RolUsuarioId",
                schema: "Usuarios",
                table: "Catalogo",
                column: "RolUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_ProductoId",
                schema: "SubVentas",
                table: "Venta",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_VentaId",
                schema: "SubVentas",
                table: "Venta",
                column: "VentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tienda_DepartamentoId",
                schema: "Productos",
                table: "Tienda",
                column: "DepartamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Catalogo_Catalogo_RolUsuarioId",
                schema: "Usuarios",
                table: "Catalogo",
                column: "RolUsuarioId",
                principalSchema: "RolUsuarios",
                principalTable: "Catalogo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tienda_Tienda_DepartamentoId",
                schema: "Productos",
                table: "Tienda",
                column: "DepartamentoId",
                principalSchema: "Departamentos",
                principalTable: "Tienda",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Venta_Tienda_ProductoId",
                schema: "SubVentas",
                table: "Venta",
                column: "ProductoId",
                principalSchema: "Productos",
                principalTable: "Tienda",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Venta_Venta_VentaId",
                schema: "SubVentas",
                table: "Venta",
                column: "VentaId",
                principalSchema: "Venta",
                principalTable: "Venta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Venta_Catalogo_UsuarioId",
                schema: "Venta",
                table: "Venta",
                column: "UsuarioId",
                principalSchema: "Usuarios",
                principalTable: "Catalogo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Catalogo_Catalogo_RolUsuarioId",
                schema: "Usuarios",
                table: "Catalogo");

            migrationBuilder.DropForeignKey(
                name: "FK_Tienda_Tienda_DepartamentoId",
                schema: "Productos",
                table: "Tienda");

            migrationBuilder.DropForeignKey(
                name: "FK_Venta_Tienda_ProductoId",
                schema: "SubVentas",
                table: "Venta");

            migrationBuilder.DropForeignKey(
                name: "FK_Venta_Venta_VentaId",
                schema: "SubVentas",
                table: "Venta");

            migrationBuilder.DropForeignKey(
                name: "FK_Venta_Catalogo_UsuarioId",
                schema: "Venta",
                table: "Venta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Venta",
                schema: "Venta",
                table: "Venta");

            migrationBuilder.DropIndex(
                name: "IX_Venta_UsuarioId",
                schema: "Venta",
                table: "Venta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Venta",
                schema: "SubVentas",
                table: "Venta");

            migrationBuilder.DropIndex(
                name: "IX_Venta_ProductoId",
                schema: "SubVentas",
                table: "Venta");

            migrationBuilder.DropIndex(
                name: "IX_Venta_VentaId",
                schema: "SubVentas",
                table: "Venta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tienda",
                schema: "Productos",
                table: "Tienda");

            migrationBuilder.DropIndex(
                name: "IX_Tienda_DepartamentoId",
                schema: "Productos",
                table: "Tienda");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tienda",
                schema: "Departamentos",
                table: "Tienda");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Catalogo",
                schema: "Usuarios",
                table: "Catalogo");

            migrationBuilder.DropIndex(
                name: "IX_Catalogo_RolUsuarioId",
                schema: "Usuarios",
                table: "Catalogo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Catalogo",
                schema: "RolUsuarios",
                table: "Catalogo");

            migrationBuilder.RenameTable(
                name: "Venta",
                schema: "Venta",
                newName: "Ventas");

            migrationBuilder.RenameTable(
                name: "Venta",
                schema: "SubVentas",
                newName: "SubVentas");

            migrationBuilder.RenameTable(
                name: "Tienda",
                schema: "Productos",
                newName: "Productos");

            migrationBuilder.RenameTable(
                name: "Tienda",
                schema: "Departamentos",
                newName: "Departamentos");

            migrationBuilder.RenameTable(
                name: "Catalogo",
                schema: "Usuarios",
                newName: "Usuarios");

            migrationBuilder.RenameTable(
                name: "Catalogo",
                schema: "RolUsuarios",
                newName: "RolUsuarios");

            migrationBuilder.AddColumn<int>(
                name: "ListaSubVentaId",
                table: "Ventas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ventas",
                table: "Ventas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubVentas",
                table: "SubVentas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Productos",
                table: "Productos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departamentos",
                table: "Departamentos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RolUsuarios",
                table: "RolUsuarios",
                column: "Id");
        }
    }
}
