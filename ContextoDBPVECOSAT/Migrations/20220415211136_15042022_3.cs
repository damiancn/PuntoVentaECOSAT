using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContextoDBPVECOSAT.Migrations
{
    public partial class _15042022_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Venta",
                schema: "SubVentas",
                table: "Venta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tienda",
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Catalogo",
                schema: "RolUsuarios",
                table: "Catalogo");

            migrationBuilder.EnsureSchema(
                name: "Tienda");

            migrationBuilder.EnsureSchema(
                name: "Catalogo");

            migrationBuilder.RenameTable(
                name: "Venta",
                schema: "Venta",
                newName: "Ventas",
                newSchema: "Venta");

            migrationBuilder.RenameTable(
                name: "Venta",
                schema: "SubVentas",
                newName: "SubVentas",
                newSchema: "Venta");

            migrationBuilder.RenameTable(
                name: "Tienda",
                schema: "Productos",
                newName: "Productos",
                newSchema: "Tienda");

            migrationBuilder.RenameTable(
                name: "Tienda",
                schema: "Departamentos",
                newName: "Departamentos",
                newSchema: "Tienda");

            migrationBuilder.RenameTable(
                name: "Catalogo",
                schema: "Usuarios",
                newName: "Usuarios",
                newSchema: "Catalogo");

            migrationBuilder.RenameTable(
                name: "Catalogo",
                schema: "RolUsuarios",
                newName: "RolUsuarios",
                newSchema: "Catalogo");

            migrationBuilder.RenameIndex(
                name: "IX_Venta_UsuarioId",
                schema: "Venta",
                table: "Ventas",
                newName: "IX_Ventas_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Venta_VentaId",
                schema: "Venta",
                table: "SubVentas",
                newName: "IX_SubVentas_VentaId");

            migrationBuilder.RenameIndex(
                name: "IX_Venta_ProductoId",
                schema: "Venta",
                table: "SubVentas",
                newName: "IX_SubVentas_ProductoId");

            migrationBuilder.RenameIndex(
                name: "IX_Tienda_DepartamentoId",
                schema: "Tienda",
                table: "Productos",
                newName: "IX_Productos_DepartamentoId");

            migrationBuilder.RenameIndex(
                name: "IX_Catalogo_RolUsuarioId",
                schema: "Catalogo",
                table: "Usuarios",
                newName: "IX_Usuarios_RolUsuarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ventas",
                schema: "Venta",
                table: "Ventas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubVentas",
                schema: "Venta",
                table: "SubVentas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Productos",
                schema: "Tienda",
                table: "Productos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departamentos",
                schema: "Tienda",
                table: "Departamentos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                schema: "Catalogo",
                table: "Usuarios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RolUsuarios",
                schema: "Catalogo",
                table: "RolUsuarios",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Departamentos_DepartamentoId",
                schema: "Tienda",
                table: "Productos",
                column: "DepartamentoId",
                principalSchema: "Tienda",
                principalTable: "Departamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubVentas_Productos_ProductoId",
                schema: "Venta",
                table: "SubVentas",
                column: "ProductoId",
                principalSchema: "Tienda",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubVentas_Ventas_VentaId",
                schema: "Venta",
                table: "SubVentas",
                column: "VentaId",
                principalSchema: "Venta",
                principalTable: "Ventas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_RolUsuarios_RolUsuarioId",
                schema: "Catalogo",
                table: "Usuarios",
                column: "RolUsuarioId",
                principalSchema: "Catalogo",
                principalTable: "RolUsuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Usuarios_UsuarioId",
                schema: "Venta",
                table: "Ventas",
                column: "UsuarioId",
                principalSchema: "Catalogo",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Departamentos_DepartamentoId",
                schema: "Tienda",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_SubVentas_Productos_ProductoId",
                schema: "Venta",
                table: "SubVentas");

            migrationBuilder.DropForeignKey(
                name: "FK_SubVentas_Ventas_VentaId",
                schema: "Venta",
                table: "SubVentas");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_RolUsuarios_RolUsuarioId",
                schema: "Catalogo",
                table: "Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Usuarios_UsuarioId",
                schema: "Venta",
                table: "Ventas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ventas",
                schema: "Venta",
                table: "Ventas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                schema: "Catalogo",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubVentas",
                schema: "Venta",
                table: "SubVentas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RolUsuarios",
                schema: "Catalogo",
                table: "RolUsuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Productos",
                schema: "Tienda",
                table: "Productos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departamentos",
                schema: "Tienda",
                table: "Departamentos");

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

            migrationBuilder.RenameTable(
                name: "Ventas",
                schema: "Venta",
                newName: "Venta",
                newSchema: "Venta");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                schema: "Catalogo",
                newName: "Catalogo",
                newSchema: "Usuarios");

            migrationBuilder.RenameTable(
                name: "SubVentas",
                schema: "Venta",
                newName: "Venta",
                newSchema: "SubVentas");

            migrationBuilder.RenameTable(
                name: "RolUsuarios",
                schema: "Catalogo",
                newName: "Catalogo",
                newSchema: "RolUsuarios");

            migrationBuilder.RenameTable(
                name: "Productos",
                schema: "Tienda",
                newName: "Tienda",
                newSchema: "Productos");

            migrationBuilder.RenameTable(
                name: "Departamentos",
                schema: "Tienda",
                newName: "Tienda",
                newSchema: "Departamentos");

            migrationBuilder.RenameIndex(
                name: "IX_Ventas_UsuarioId",
                schema: "Venta",
                table: "Venta",
                newName: "IX_Venta_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Usuarios_RolUsuarioId",
                schema: "Usuarios",
                table: "Catalogo",
                newName: "IX_Catalogo_RolUsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_SubVentas_VentaId",
                schema: "SubVentas",
                table: "Venta",
                newName: "IX_Venta_VentaId");

            migrationBuilder.RenameIndex(
                name: "IX_SubVentas_ProductoId",
                schema: "SubVentas",
                table: "Venta",
                newName: "IX_Venta_ProductoId");

            migrationBuilder.RenameIndex(
                name: "IX_Productos_DepartamentoId",
                schema: "Productos",
                table: "Tienda",
                newName: "IX_Tienda_DepartamentoId");

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
    }
}
