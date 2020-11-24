using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FarmaciaAvellaneda.Migrations.FarmaciaAvellaneda
{
    public partial class FarmaciaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Caja",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    estado = table.Column<byte>(nullable: true),
                    saldo = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caja", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CajaAhorro",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    cbu = table.Column<string>(maxLength: 450, nullable: true),
                    Cuenta = table.Column<string>(maxLength: 450, nullable: true),
                    Banco = table.Column<string>(unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CajaAhorro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoriaProducto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(unicode: false, maxLength: 60, nullable: true),
                    estado = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaProducto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Compra",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<DateTime>(type: "datetime", nullable: true),
                    total = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compra", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Concepto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    tipo = table.Column<byte>(nullable: true),
                    monto = table.Column<double>(nullable: true),
                    exento = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concepto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    nombre = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    cuit = table.Column<string>(unicode: false, maxLength: 60, nullable: false),
                    direccion = table.Column<string>(unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Marca",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigo = table.Column<int>(nullable: true),
                    nombre = table.Column<string>(unicode: false, maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marca", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubCategoriaProducto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(unicode: false, maxLength: 60, nullable: true),
                    categoriaProductoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategoriaProducto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategoria_Categoria_Producto",
                        column: x => x.categoriaProductoId,
                        principalTable: "CategoriaProducto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    razonSocial = table.Column<string>(unicode: false, maxLength: 60, nullable: true),
                    cuit = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    telefono = table.Column<string>(unicode: false, maxLength: 60, nullable: true),
                    compraId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proveedor_Compra",
                        column: x => x.compraId,
                        principalTable: "Compra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    apellido = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    nombre = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    cuit = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    email = table.Column<string>(unicode: false, maxLength: 60, nullable: true),
                    celular = table.Column<string>(unicode: false, maxLength: 60, nullable: true),
                    telefono = table.Column<string>(unicode: false, maxLength: 60, nullable: true),
                    domicilio = table.Column<string>(unicode: false, maxLength: 60, nullable: true),
                    estado = table.Column<byte>(nullable: true),
                    userId = table.Column<string>(nullable: false),
                    empresaId = table.Column<Guid>(nullable: false),
                    cajaAhorroId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empleado_CajaAhorro",
                        column: x => x.cajaAhorroId,
                        principalTable: "CajaAhorro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Empleado_Empresa",
                        column: x => x.empresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Empleado_UserId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(unicode: false, maxLength: 60, nullable: true),
                    descripcion = table.Column<string>(unicode: false, maxLength: 60, nullable: true),
                    foto = table.Column<byte[]>(type: "image", nullable: true),
                    stock = table.Column<int>(nullable: true),
                    precioCompra = table.Column<double>(nullable: true),
                    fechaVencimiento = table.Column<DateTime>(type: "date", nullable: true),
                    precioVenta = table.Column<double>(nullable: true),
                    estado = table.Column<byte>(nullable: true),
                    categoriaProductoId = table.Column<int>(nullable: false),
                    marcaId = table.Column<int>(nullable: false),
                    proveedorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Producto_Categoria",
                        column: x => x.categoriaProductoId,
                        principalTable: "CategoriaProducto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Producto_Marca",
                        column: x => x.marcaId,
                        principalTable: "Marca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Producto_Proveedor",
                        column: x => x.proveedorId,
                        principalTable: "Proveedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GrupoFamiliar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dni = table.Column<int>(nullable: true),
                    apellido = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    nombre = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    fechaNacimiento = table.Column<DateTime>(type: "date", nullable: true),
                    parentesco = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    empleadoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoFamiliar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GrupoFamiliar_Empleado",
                        column: x => x.empleadoId,
                        principalTable: "Empleado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Liquidacion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fechaDesde = table.Column<DateTime>(type: "date", nullable: true),
                    fechaHasta = table.Column<DateTime>(type: "date", nullable: true),
                    salarioNeto = table.Column<double>(nullable: true),
                    salarioDescripto = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    lugarPago = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    periodoLiquidacion = table.Column<string>(unicode: false, maxLength: 60, nullable: true),
                    estado = table.Column<byte>(nullable: true),
                    totalRemunerado = table.Column<double>(nullable: true),
                    totalDeduccion = table.Column<double>(nullable: true),
                    empleadoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Liquidacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Liquidacion_Empleado",
                        column: x => x.empleadoId,
                        principalTable: "Empleado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Venta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fechaVenta = table.Column<DateTime>(type: "datetime", nullable: true),
                    total = table.Column<double>(nullable: true),
                    estado = table.Column<byte>(nullable: true),
                    empleadoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Venta_Empleado",
                        column: x => x.empleadoId,
                        principalTable: "Empleado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Capacidad",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cantidad = table.Column<int>(nullable: true),
                    estado = table.Column<byte>(nullable: true),
                    productoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Capacidad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Capacidad_Producto",
                        column: x => x.productoId,
                        principalTable: "Producto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LineaCompra",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subtotal = table.Column<double>(nullable: true),
                    cantidad = table.Column<int>(nullable: true),
                    compraId = table.Column<int>(nullable: false),
                    productoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineaCompra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LineaCompra_Compra",
                        column: x => x.compraId,
                        principalTable: "Compra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LineaCompra_Producto",
                        column: x => x.productoId,
                        principalTable: "Producto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetalleLiquidacion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    unidad = table.Column<int>(nullable: true),
                    haber = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    deduccion = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    conceptoId = table.Column<int>(nullable: false),
                    liquidacionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleLiquidacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalleLiquidacion_Concepto",
                        column: x => x.conceptoId,
                        principalTable: "Concepto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleLiquidacion_Liquidacion",
                        column: x => x.liquidacionId,
                        principalTable: "Liquidacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LineaVenta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subtotal = table.Column<double>(nullable: true),
                    cantidad = table.Column<int>(nullable: true),
                    ventaId = table.Column<int>(nullable: false),
                    productoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineaVenta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LineaVenta_Producto",
                        column: x => x.productoId,
                        principalTable: "Producto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LineaVenta_Venta",
                        column: x => x.ventaId,
                        principalTable: "Venta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovimientoCaja",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    cajaId = table.Column<int>(nullable: false),
                    compraId = table.Column<int>(nullable: false),
                    ventaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimientoCaja", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovimientoCaja_Caja",
                        column: x => x.cajaId,
                        principalTable: "Caja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovimientoCaja_Compra",
                        column: x => x.compraId,
                        principalTable: "Compra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovimientoCaja_Venta",
                        column: x => x.ventaId,
                        principalTable: "Venta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pago",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    monto = table.Column<double>(nullable: true),
                    vuelto = table.Column<double>(nullable: true),
                    ventaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pago", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pago_Venta",
                        column: x => x.ventaId,
                        principalTable: "Venta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "([NormalizedName] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "([NormalizedUserName] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_Capacidad_productoId",
                table: "Capacidad",
                column: "productoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleLiquidacion_conceptoId",
                table: "DetalleLiquidacion",
                column: "conceptoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleLiquidacion_liquidacionId",
                table: "DetalleLiquidacion",
                column: "liquidacionId");

            migrationBuilder.CreateIndex(
                name: "UQ__Empleado__57E86AD0FC9158A8",
                table: "Empleado",
                column: "cajaAhorroId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_empresaId",
                table: "Empleado",
                column: "empresaId");

            migrationBuilder.CreateIndex(
                name: "UQ__Empleado__CB9A1CFED2E64194",
                table: "Empleado",
                column: "userId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GrupoFamiliar_empleadoId",
                table: "GrupoFamiliar",
                column: "empleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_LineaCompra_compraId",
                table: "LineaCompra",
                column: "compraId");

            migrationBuilder.CreateIndex(
                name: "IX_LineaCompra_productoId",
                table: "LineaCompra",
                column: "productoId");

            migrationBuilder.CreateIndex(
                name: "IX_LineaVenta_productoId",
                table: "LineaVenta",
                column: "productoId");

            migrationBuilder.CreateIndex(
                name: "IX_LineaVenta_ventaId",
                table: "LineaVenta",
                column: "ventaId");

            migrationBuilder.CreateIndex(
                name: "IX_Liquidacion_empleadoId",
                table: "Liquidacion",
                column: "empleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientoCaja_cajaId",
                table: "MovimientoCaja",
                column: "cajaId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientoCaja_compraId",
                table: "MovimientoCaja",
                column: "compraId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientoCaja_ventaId",
                table: "MovimientoCaja",
                column: "ventaId");

            migrationBuilder.CreateIndex(
                name: "UQ__Pago__40B8EB55BDD3C069",
                table: "Pago",
                column: "ventaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Producto_categoriaProductoId",
                table: "Producto",
                column: "categoriaProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_marcaId",
                table: "Producto",
                column: "marcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_proveedorId",
                table: "Producto",
                column: "proveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedor_compraId",
                table: "Proveedor",
                column: "compraId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategoriaProducto_categoriaProductoId",
                table: "SubCategoriaProducto",
                column: "categoriaProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_empleadoId",
                table: "Venta",
                column: "empleadoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Capacidad");

            migrationBuilder.DropTable(
                name: "DetalleLiquidacion");

            migrationBuilder.DropTable(
                name: "GrupoFamiliar");

            migrationBuilder.DropTable(
                name: "LineaCompra");

            migrationBuilder.DropTable(
                name: "LineaVenta");

            migrationBuilder.DropTable(
                name: "MovimientoCaja");

            migrationBuilder.DropTable(
                name: "Pago");

            migrationBuilder.DropTable(
                name: "SubCategoriaProducto");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

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
                name: "CategoriaProducto");

            migrationBuilder.DropTable(
                name: "Marca");

            migrationBuilder.DropTable(
                name: "Proveedor");

            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropTable(
                name: "Compra");

            migrationBuilder.DropTable(
                name: "CajaAhorro");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
