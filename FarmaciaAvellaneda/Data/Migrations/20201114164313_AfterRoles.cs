using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FarmaciaAvellaneda.Data.Migrations
{
    public partial class AfterRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "AspNetRoles1",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(nullable: false),
            //        Name = table.Column<string>(nullable: true),
            //        NormalizedName = table.Column<string>(nullable: true),
            //        ConcurrencyStamp = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetRoles1", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUsers1",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(nullable: false),
            //        UserName = table.Column<string>(nullable: true),
            //        NormalizedUserName = table.Column<string>(nullable: true),
            //        Email = table.Column<string>(nullable: true),
            //        NormalizedEmail = table.Column<string>(nullable: true),
            //        EmailConfirmed = table.Column<bool>(nullable: false),
            //        PasswordHash = table.Column<string>(nullable: true),
            //        SecurityStamp = table.Column<string>(nullable: true),
            //        ConcurrencyStamp = table.Column<string>(nullable: true),
            //        PhoneNumber = table.Column<string>(nullable: true),
            //        PhoneNumberConfirmed = table.Column<bool>(nullable: false),
            //        TwoFactorEnabled = table.Column<bool>(nullable: false),
            //        LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
            //        LockoutEnabled = table.Column<bool>(nullable: false),
            //        AccessFailedCount = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUsers1", x => x.Id);
            //    });

            migrationBuilder.CreateTable(
                name: "Caja",
                columns: table => new
                {
                    IdCaja = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Estado = table.Column<byte>(nullable: true),
                    Saldo = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caja", x => x.IdCaja);
                });

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Estado = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Compra",
                columns: table => new
                {
                    IdCompra = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(nullable: true),
                    Total = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compra", x => x.IdCompra);
                });

            migrationBuilder.CreateTable(
                name: "Concepto",
                columns: table => new
                {
                    IdConcepto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: true),
                    Tipo = table.Column<byte>(nullable: true),
                    MontoFijo = table.Column<double>(nullable: true),
                    MontoVariable = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concepto", x => x.IdConcepto);
                });

            migrationBuilder.CreateTable(
                name: "Marca",
                columns: table => new
                {
                    IdMarca = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<int>(nullable: true),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marca", x => x.IdMarca);
                });

            //migrationBuilder.CreateTable(
            //    name: "AspNetRoleClaims1",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        RoleId = table.Column<string>(nullable: true),
            //        ClaimType = table.Column<string>(nullable: true),
            //        ClaimValue = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetRoleClaims1", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_AspNetRoleClaims1_AspNetRoles1_RoleId",
            //            column: x => x.RoleId,
            //            principalTable: "AspNetRoles1",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserClaims1",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        UserId = table.Column<string>(nullable: true),
            //        ClaimType = table.Column<string>(nullable: true),
            //        ClaimValue = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserClaims1", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_AspNetUserClaims1_AspNetUsers1_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers1",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserLogins1",
            //    columns: table => new
            //    {
            //        UserId = table.Column<string>(nullable: false),
            //        LoginProvider = table.Column<string>(nullable: true),
            //        ProviderKey = table.Column<string>(nullable: true),
            //        ProviderDisplayName = table.Column<string>(nullable: true),
            //        UserId1 = table.Column<string>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserLogins1", x => x.UserId);
            //        table.ForeignKey(
            //            name: "FK_AspNetUserLogins1_AspNetUsers1_UserId1",
            //            column: x => x.UserId1,
            //            principalTable: "AspNetUsers1",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserRoles1",
            //    columns: table => new
            //    {
            //        UserId = table.Column<string>(nullable: false),
            //        RoleId = table.Column<string>(nullable: true),
            //        UserId1 = table.Column<string>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserRoles1", x => x.UserId);
            //        table.ForeignKey(
            //            name: "FK_AspNetUserRoles1_AspNetRoles1_RoleId",
            //            column: x => x.RoleId,
            //            principalTable: "AspNetRoles1",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_AspNetUserRoles1_AspNetUsers1_UserId1",
            //            column: x => x.UserId1,
            //            principalTable: "AspNetUsers1",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserTokens1",
            //    columns: table => new
            //    {
            //        UserId = table.Column<string>(nullable: false),
            //        LoginProvider = table.Column<string>(nullable: true),
            //        Name = table.Column<string>(nullable: true),
            //        Value = table.Column<string>(nullable: true),
            //        UserId1 = table.Column<string>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserTokens1", x => x.UserId);
            //        table.ForeignKey(
            //            name: "FK_AspNetUserTokens1_AspNetUsers1_UserId1",
            //            column: x => x.UserId1,
            //            principalTable: "AspNetUsers1",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    IdEmpleado = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Apellido = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Cuit = table.Column<int>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Celular = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    Domicilio = table.Column<string>(nullable: true),
                    Estado = table.Column<byte>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.IdEmpleado);
                    table.ForeignKey(
                        name: "FK_Empleado_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubCategoria",
                columns: table => new
                {
                    IdSubcategoria = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    CategoriaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategoria", x => x.IdSubcategoria);
                    table.ForeignKey(
                        name: "FK_SubCategoria_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    IdProveedor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RazonSocial = table.Column<string>(nullable: true),
                    Cuit = table.Column<int>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    CompraId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor", x => x.IdProveedor);
                    table.ForeignKey(
                        name: "FK_Proveedor_Compra_CompraId",
                        column: x => x.CompraId,
                        principalTable: "Compra",
                        principalColumn: "IdCompra",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GrupoFamiliar",
                columns: table => new
                {
                    IdGrupofamiliar = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dni = table.Column<int>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    FechaNacimiento = table.Column<DateTime>(nullable: true),
                    Parentesco = table.Column<string>(nullable: true),
                    EmpleadoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoFamiliar", x => x.IdGrupofamiliar);
                    table.ForeignKey(
                        name: "FK_GrupoFamiliar_Empleado_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleado",
                        principalColumn: "IdEmpleado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Liquidacion",
                columns: table => new
                {
                    IdLiquidacion = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaDesde = table.Column<DateTime>(nullable: true),
                    FechaHasta = table.Column<DateTime>(nullable: true),
                    SalarioNeto = table.Column<double>(nullable: true),
                    PeriodoLiquidacion = table.Column<DateTime>(nullable: true),
                    Estado = table.Column<byte>(nullable: true),
                    Retenciones = table.Column<double>(nullable: true),
                    SalarioBruto = table.Column<double>(nullable: true),
                    EmpleadoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Liquidacion", x => x.IdLiquidacion);
                    table.ForeignKey(
                        name: "FK_Liquidacion_Empleado_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleado",
                        principalColumn: "IdEmpleado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Venta",
                columns: table => new
                {
                    IdVenta = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaVenta = table.Column<DateTime>(nullable: true),
                    Total = table.Column<double>(nullable: true),
                    Estado = table.Column<byte>(nullable: true),
                    EmpleadoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venta", x => x.IdVenta);
                    table.ForeignKey(
                        name: "FK_Venta_Empleado_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleado",
                        principalColumn: "IdEmpleado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    IdProducto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    Foto = table.Column<byte[]>(nullable: true),
                    Stock = table.Column<int>(nullable: true),
                    PrecioCompra = table.Column<double>(nullable: true),
                    FechaVencimiento = table.Column<DateTime>(nullable: true),
                    PrecioVenta = table.Column<double>(nullable: true),
                    Estado = table.Column<byte>(nullable: true),
                    CategoriaId = table.Column<int>(nullable: false),
                    MarcaId = table.Column<int>(nullable: false),
                    ProveedorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.IdProducto);
                    table.ForeignKey(
                        name: "FK_Producto_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Producto_Marca_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "Marca",
                        principalColumn: "IdMarca",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Producto_Proveedor_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedor",
                        principalColumn: "IdProveedor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleLiquidacion",
                columns: table => new
                {
                    IdDetalleLlquidacion = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Unidad = table.Column<int>(nullable: true),
                    Haberes = table.Column<string>(nullable: true),
                    ConceptoId = table.Column<int>(nullable: false),
                    LiquidacionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleLiquidacion", x => x.IdDetalleLlquidacion);
                    table.ForeignKey(
                        name: "FK_DetalleLiquidacion_Concepto_ConceptoId",
                        column: x => x.ConceptoId,
                        principalTable: "Concepto",
                        principalColumn: "IdConcepto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleLiquidacion_Liquidacion_LiquidacionId",
                        column: x => x.LiquidacionId,
                        principalTable: "Liquidacion",
                        principalColumn: "IdLiquidacion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovimientoCaja",
                columns: table => new
                {
                    IdMovimientoCaja = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: true),
                    CajaId = table.Column<int>(nullable: false),
                    CompraId = table.Column<int>(nullable: false),
                    VentaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimientoCaja", x => x.IdMovimientoCaja);
                    table.ForeignKey(
                        name: "FK_MovimientoCaja_Caja_CajaId",
                        column: x => x.CajaId,
                        principalTable: "Caja",
                        principalColumn: "IdCaja",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovimientoCaja_Compra_CompraId",
                        column: x => x.CompraId,
                        principalTable: "Compra",
                        principalColumn: "IdCompra",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovimientoCaja_Venta_VentaId",
                        column: x => x.VentaId,
                        principalTable: "Venta",
                        principalColumn: "IdVenta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pago",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Monto = table.Column<double>(nullable: true),
                    Vuelto = table.Column<double>(nullable: true),
                    VentaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pago", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pago_Venta_VentaId",
                        column: x => x.VentaId,
                        principalTable: "Venta",
                        principalColumn: "IdVenta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Capacidad",
                columns: table => new
                {
                    IdCapacidad = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(nullable: true),
                    Estado = table.Column<byte>(nullable: true),
                    ProductoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Capacidad", x => x.IdCapacidad);
                    table.ForeignKey(
                        name: "FK_Capacidad_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LineaDeCompra",
                columns: table => new
                {
                    IdLineadecompra = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subtotal = table.Column<double>(nullable: true),
                    Cantidad = table.Column<int>(nullable: true),
                    CompraId = table.Column<int>(nullable: false),
                    ProductoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineaDeCompra", x => x.IdLineadecompra);
                    table.ForeignKey(
                        name: "FK_LineaDeCompra_Compra_CompraId",
                        column: x => x.CompraId,
                        principalTable: "Compra",
                        principalColumn: "IdCompra",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LineaDeCompra_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "LineaDeVenta",
                columns: table => new
                {
                    IdLineadeventa = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subtotal = table.Column<double>(nullable: true),
                    Cantidad = table.Column<int>(nullable: true),
                    VentaId = table.Column<int>(nullable: false),
                    ProductoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineaDeVenta", x => x.IdLineadeventa);
                    table.ForeignKey(
                        name: "FK_LineaDeVenta_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LineaDeVenta_Venta_VentaId",
                        column: x => x.VentaId,
                        principalTable: "Venta",
                        principalColumn: "IdVenta",
                        onDelete: ReferentialAction.Cascade);
                });

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetRoleClaims1_RoleId",
            //    table: "AspNetRoleClaims1",
            //    column: "RoleId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserClaims1_UserId",
            //    table: "AspNetUserClaims1",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserLogins1_UserId1",
            //    table: "AspNetUserLogins1",
            //    column: "UserId1");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserRoles1_RoleId",
            //    table: "AspNetUserRoles1",
            //    column: "RoleId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserRoles1_UserId1",
            //    table: "AspNetUserRoles1",
            //    column: "UserId1");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserTokens1_UserId1",
            //    table: "AspNetUserTokens1",
            //    column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Capacidad_ProductoId",
                table: "Capacidad",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleLiquidacion_ConceptoId",
                table: "DetalleLiquidacion",
                column: "ConceptoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleLiquidacion_LiquidacionId",
                table: "DetalleLiquidacion",
                column: "LiquidacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_UserId",
                table: "Empleado",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_GrupoFamiliar_EmpleadoId",
                table: "GrupoFamiliar",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_LineaDeCompra_CompraId",
                table: "LineaDeCompra",
                column: "CompraId");

            migrationBuilder.CreateIndex(
                name: "IX_LineaDeCompra_ProductoId",
                table: "LineaDeCompra",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_LineaDeVenta_ProductoId",
                table: "LineaDeVenta",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_LineaDeVenta_VentaId",
                table: "LineaDeVenta",
                column: "VentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Liquidacion_EmpleadoId",
                table: "Liquidacion",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientoCaja_CajaId",
                table: "MovimientoCaja",
                column: "CajaId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientoCaja_CompraId",
                table: "MovimientoCaja",
                column: "CompraId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientoCaja_VentaId",
                table: "MovimientoCaja",
                column: "VentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pago_VentaId",
                table: "Pago",
                column: "VentaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Producto_CategoriaId",
                table: "Producto",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_MarcaId",
                table: "Producto",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_ProveedorId",
                table: "Producto",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedor_CompraId",
                table: "Proveedor",
                column: "CompraId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategoria_CategoriaId",
                table: "SubCategoria",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_EmpleadoId",
                table: "Venta",
                column: "EmpleadoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "AspNetRoleClaims1");

            //migrationBuilder.DropTable(
            //    name: "AspNetUserClaims1");

            //migrationBuilder.DropTable(
            //    name: "AspNetUserLogins1");

            //migrationBuilder.DropTable(
            //    name: "AspNetUserRoles1");

            //migrationBuilder.DropTable(
            //    name: "AspNetUserTokens1");

            migrationBuilder.DropTable(
                name: "Capacidad");

            migrationBuilder.DropTable(
                name: "DetalleLiquidacion");

            migrationBuilder.DropTable(
                name: "GrupoFamiliar");

            migrationBuilder.DropTable(
                name: "LineaDeCompra");

            migrationBuilder.DropTable(
                name: "LineaDeVenta");

            migrationBuilder.DropTable(
                name: "MovimientoCaja");

            migrationBuilder.DropTable(
                name: "Pago");

            migrationBuilder.DropTable(
                name: "SubCategoria");

            //migrationBuilder.DropTable(
            //    name: "AspNetRoles1");

            migrationBuilder.DropTable(
                name: "Concepto");

            migrationBuilder.DropTable(
                name: "Liquidacion");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Caja");

            migrationBuilder.DropTable(
                name: "Venta");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Marca");

            migrationBuilder.DropTable(
                name: "Proveedor");

            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropTable(
                name: "Compra");

            //migrationBuilder.DropTable(
            //    name: "AspNetUsers1");
        }
    }
}
