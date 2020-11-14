using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FarmaciaAvellaneda.Migrations
{
    public partial class SecondMigration : Migration
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
                    idCaja = table.Column<int>(nullable: false),
                    nombre = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    estado = table.Column<byte>(nullable: true),
                    saldo = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Caja__8BC79B34F17EDF9F", x => x.idCaja);
                });

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    idCategoria = table.Column<int>(nullable: false),
                    nombre = table.Column<string>(unicode: false, maxLength: 60, nullable: true),
                    estado = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Categori__8A3D240C82E6A00D", x => x.idCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Compra",
                columns: table => new
                {
                    idCompra = table.Column<int>(nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime", nullable: true),
                    total = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Compra__48B99DB73C722341", x => x.idCompra);
                });

            migrationBuilder.CreateTable(
                name: "Concepto",
                columns: table => new
                {
                    idConcepto = table.Column<int>(nullable: false),
                    descripcion = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    tipo = table.Column<byte>(nullable: true),
                    montoFijo = table.Column<double>(nullable: true),
                    montoVariable = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Concepto__25A881FDD15B03CA", x => x.idConcepto);
                });

            migrationBuilder.CreateTable(
                name: "Marca",
                columns: table => new
                {
                    idMarca = table.Column<int>(nullable: false),
                    codigo = table.Column<int>(nullable: true),
                    nombre = table.Column<string>(unicode: false, maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Marca__703318124DE92BF2", x => x.idMarca);
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
                name: "Empleado",
                columns: table => new
                {
                    idEmpleado = table.Column<int>(nullable: false),
                    apellido = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    nombre = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    cuit = table.Column<int>(nullable: true),
                    email = table.Column<string>(unicode: false, maxLength: 60, nullable: true),
                    celular = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    telefono = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    domicilio = table.Column<string>(unicode: false, maxLength: 60, nullable: true),
                    estado = table.Column<byte>(nullable: true),
                    userId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Empleado__5295297C1AA21034", x => x.idEmpleado);
                    table.ForeignKey(
                        name: "FK__Empleado__userId__056ECC6A",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubCategoria",
                columns: table => new
                {
                    idSubcategoria = table.Column<int>(nullable: false),
                    nombre = table.Column<string>(unicode: false, maxLength: 60, nullable: true),
                    categoriaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SubCateg__8EA501869E5A1067", x => x.idSubcategoria);
                    table.ForeignKey(
                        name: "FK__SubCatego__categ__1E3A7A34",
                        column: x => x.categoriaId,
                        principalTable: "Categoria",
                        principalColumn: "idCategoria",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    idProveedor = table.Column<int>(nullable: false),
                    razonSocial = table.Column<string>(unicode: false, maxLength: 60, nullable: true),
                    cuit = table.Column<int>(nullable: true),
                    telefono = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    compraId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Proveedo__A3FA8E6BB53D4BFD", x => x.idProveedor);
                    table.ForeignKey(
                        name: "FK__Proveedor__compr__22FF2F51",
                        column: x => x.compraId,
                        principalTable: "Compra",
                        principalColumn: "idCompra",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GrupoFamiliar",
                columns: table => new
                {
                    idGrupofamiliar = table.Column<int>(nullable: false),
                    dni = table.Column<int>(nullable: true),
                    apellido = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    nombre = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    fechaNacimiento = table.Column<DateTime>(type: "date", nullable: true),
                    parentesco = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    empleadoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__GrupoFam__3D65669A3B5BD5A0", x => x.idGrupofamiliar);
                    table.ForeignKey(
                        name: "FK__GrupoFami__emple__084B3915",
                        column: x => x.empleadoId,
                        principalTable: "Empleado",
                        principalColumn: "idEmpleado",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Liquidacion",
                columns: table => new
                {
                    idLiquidacion = table.Column<int>(nullable: false),
                    fechaDesde = table.Column<DateTime>(type: "date", nullable: true),
                    fechaHasta = table.Column<DateTime>(type: "date", nullable: true),
                    salarioNeto = table.Column<double>(nullable: true),
                    periodoLiquidacion = table.Column<DateTime>(type: "date", nullable: true),
                    estado = table.Column<byte>(nullable: true),
                    retenciones = table.Column<double>(nullable: true),
                    salarioBruto = table.Column<double>(nullable: true),
                    empleadoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Liquidac__AD38F40F69F34AD9", x => x.idLiquidacion);
                    table.ForeignKey(
                        name: "FK__Liquidaci__emple__0B27A5C0",
                        column: x => x.empleadoId,
                        principalTable: "Empleado",
                        principalColumn: "idEmpleado",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Venta",
                columns: table => new
                {
                    idVenta = table.Column<int>(nullable: false),
                    fechaVenta = table.Column<DateTime>(type: "datetime", nullable: true),
                    TOTAL = table.Column<double>(nullable: true),
                    ESTADO = table.Column<byte>(nullable: true),
                    empleadoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Venta__077D56147832A66E", x => x.idVenta);
                    table.ForeignKey(
                        name: "FK__Venta__empleadoI__13BCEBC1",
                        column: x => x.empleadoId,
                        principalTable: "Empleado",
                        principalColumn: "idEmpleado",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    idProducto = table.Column<int>(nullable: false),
                    nombre = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    descripcion = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    foto = table.Column<byte[]>(type: "image", nullable: true),
                    stock = table.Column<int>(nullable: true),
                    precioCompra = table.Column<double>(nullable: true),
                    fechaVencimiento = table.Column<DateTime>(type: "date", nullable: true),
                    precioVenta = table.Column<double>(nullable: true),
                    estado = table.Column<byte>(nullable: true),
                    categoriaId = table.Column<int>(nullable: false),
                    marcaId = table.Column<int>(nullable: false),
                    proveedorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Producto__07F4A1322C9C8904", x => x.idProducto);
                    table.ForeignKey(
                        name: "FK__Producto__catego__25DB9BFC",
                        column: x => x.categoriaId,
                        principalTable: "Categoria",
                        principalColumn: "idCategoria",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Producto__marcaI__26CFC035",
                        column: x => x.marcaId,
                        principalTable: "Marca",
                        principalColumn: "idMarca",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Producto__provee__27C3E46E",
                        column: x => x.proveedorId,
                        principalTable: "Proveedor",
                        principalColumn: "idProveedor",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetalleLiquidacion",
                columns: table => new
                {
                    idDetalleLlquidacion = table.Column<int>(nullable: false),
                    unidad = table.Column<int>(nullable: true),
                    haberes = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    conceptoId = table.Column<int>(nullable: false),
                    liquidacionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DetalleL__ADA04E144A7130B5", x => x.idDetalleLlquidacion);
                    table.ForeignKey(
                        name: "FK__DetalleLi__conce__0FEC5ADD",
                        column: x => x.conceptoId,
                        principalTable: "Concepto",
                        principalColumn: "idConcepto",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__DetalleLi__liqui__10E07F16",
                        column: x => x.liquidacionId,
                        principalTable: "Liquidacion",
                        principalColumn: "idLiquidacion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MovimientoCaja",
                columns: table => new
                {
                    idMovimientoCaja = table.Column<int>(nullable: false),
                    descripcion = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    cajaId = table.Column<int>(nullable: false),
                    compraId = table.Column<int>(nullable: false),
                    ventaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Movimien__77EEFB2DDAABD479", x => x.idMovimientoCaja);
                    table.ForeignKey(
                        name: "FK__Movimient__cajaI__58671BC9",
                        column: x => x.cajaId,
                        principalTable: "Caja",
                        principalColumn: "idCaja",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Movimient__compr__595B4002",
                        column: x => x.compraId,
                        principalTable: "Compra",
                        principalColumn: "idCompra",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Movimient__venta__5A4F643B",
                        column: x => x.ventaId,
                        principalTable: "Venta",
                        principalColumn: "idVenta",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pago",
                columns: table => new
                {
                    idPago = table.Column<int>(nullable: false),
                    monto = table.Column<double>(nullable: true),
                    vuelto = table.Column<double>(nullable: true),
                    ventaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Pago__BD2295AD89B57E9B", x => x.idPago);
                    table.ForeignKey(
                        name: "FK__Pago__ventaId__178D7CA5",
                        column: x => x.ventaId,
                        principalTable: "Venta",
                        principalColumn: "idVenta",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Capacidad",
                columns: table => new
                {
                    idCapacidad = table.Column<int>(nullable: false),
                    cantidad = table.Column<int>(nullable: true),
                    estado = table.Column<byte>(nullable: true),
                    productoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Capacida__DC4ADD50E487B485", x => x.idCapacidad);
                    table.ForeignKey(
                        name: "FK__Capacidad__produ__2E70E1FD",
                        column: x => x.productoId,
                        principalTable: "Producto",
                        principalColumn: "idProducto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LineaDeCompra",
                columns: table => new
                {
                    idLineadecompra = table.Column<int>(nullable: false),
                    subtotal = table.Column<double>(nullable: true),
                    cantidad = table.Column<int>(nullable: true),
                    compraId = table.Column<int>(nullable: false),
                    productoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LineaDeC__19C9D5BEA84680FF", x => x.idLineadecompra);
                    table.ForeignKey(
                        name: "FK__LineaDeCo__compr__314D4EA8",
                        column: x => x.compraId,
                        principalTable: "Compra",
                        principalColumn: "idCompra",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__LineaDeCo__produ__324172E1",
                        column: x => x.productoId,
                        principalTable: "Producto",
                        principalColumn: "idProducto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LineaDeVenta",
                columns: table => new
                {
                    idLineadeventa = table.Column<int>(nullable: false),
                    subtotal = table.Column<double>(nullable: true),
                    cantidad = table.Column<int>(nullable: true),
                    ventaId = table.Column<int>(nullable: false),
                    productoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LineaDeV__547E370148B313E6", x => x.idLineadeventa);
                    table.ForeignKey(
                        name: "FK__LineaDeVe__produ__2B947552",
                        column: x => x.productoId,
                        principalTable: "Producto",
                        principalColumn: "idProducto",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__LineaDeVe__venta__2AA05119",
                        column: x => x.ventaId,
                        principalTable: "Venta",
                        principalColumn: "idVenta",
                        onDelete: ReferentialAction.Restrict);
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
                name: "UQ__Empleado__CB9A1CFEFEE2F234",
                table: "Empleado",
                column: "userId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GrupoFamiliar_empleadoId",
                table: "GrupoFamiliar",
                column: "empleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_LineaDeCompra_compraId",
                table: "LineaDeCompra",
                column: "compraId");

            migrationBuilder.CreateIndex(
                name: "IX_LineaDeCompra_productoId",
                table: "LineaDeCompra",
                column: "productoId");

            migrationBuilder.CreateIndex(
                name: "IX_LineaDeVenta_productoId",
                table: "LineaDeVenta",
                column: "productoId");

            migrationBuilder.CreateIndex(
                name: "IX_LineaDeVenta_ventaId",
                table: "LineaDeVenta",
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
                name: "UQ__Pago__40B8EB5565F786B6",
                table: "Pago",
                column: "ventaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Producto_categoriaId",
                table: "Producto",
                column: "categoriaId");

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
                name: "IX_SubCategoria_categoriaId",
                table: "SubCategoria",
                column: "categoriaId");

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
                name: "LineaDeCompra");

            migrationBuilder.DropTable(
                name: "LineaDeVenta");

            migrationBuilder.DropTable(
                name: "MovimientoCaja");

            migrationBuilder.DropTable(
                name: "Pago");

            migrationBuilder.DropTable(
                name: "SubCategoria");

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
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Marca");

            migrationBuilder.DropTable(
                name: "Proveedor");

            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropTable(
                name: "Compra");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
