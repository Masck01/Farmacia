using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace FarmaciaAvellaneda.Models
{
    public partial class FarmaciaAvellanedaContext : DbContext
    {
        public FarmaciaAvellanedaContext()
        {
        }

        public FarmaciaAvellanedaContext(DbContextOptions<FarmaciaAvellanedaContext> options)
            : base(options)
        {
        }

        public IConfiguration Config { get; }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Caja> Caja { get; set; }
        public virtual DbSet<Capacidad> Capacidad { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Compra> Compra { get; set; }
        public virtual DbSet<Concepto> Concepto { get; set; }
        public virtual DbSet<DetalleLiquidacion> DetalleLiquidacion { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<GrupoFamiliar> GrupoFamiliar { get; set; }
        public virtual DbSet<LineaDeCompra> LineaDeCompra { get; set; }
        public virtual DbSet<LineaDeVenta> LineaDeVenta { get; set; }
        public virtual DbSet<Liquidacion> Liquidacion { get; set; }
        public virtual DbSet<Marca> Marca { get; set; }
        public virtual DbSet<MovimientoCaja> MovimientoCaja { get; set; }
        public virtual DbSet<Pago> Pago { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Proveedor> Proveedor { get; set; }
        public virtual DbSet<SubCategoria> SubCategoria { get; set; }
        public virtual DbSet<Venta> Venta { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer(Config.GetConnectionString("DefaultConnection"));
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Caja>(entity =>
            {
                entity.HasKey(e => e.IdCaja)
                    .HasName("PK__Caja__8BC79B34F17EDF9F");

                entity.Property(e => e.IdCaja)
                    .HasColumnName("idCaja")
                    .ValueGeneratedNever();

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Saldo).HasColumnName("saldo");
            });

            modelBuilder.Entity<Capacidad>(entity =>
            {
                entity.HasKey(e => e.IdCapacidad)
                    .HasName("PK__Capacida__DC4ADD50E487B485");

                entity.Property(e => e.IdCapacidad)
                    .HasColumnName("idCapacidad")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.ProductoId).HasColumnName("productoId");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.Capacidad)
                    .HasForeignKey(d => d.ProductoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Capacidad__produ__2E70E1FD");
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__Categori__8A3D240C82E6A00D");

                entity.Property(e => e.IdCategoria)
                    .HasColumnName("idCategoria")
                    .ValueGeneratedNever();

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Compra>(entity =>
            {
                entity.HasKey(e => e.IdCompra)
                    .HasName("PK__Compra__48B99DB73C722341");

                entity.Property(e => e.IdCompra)
                    .HasColumnName("idCompra")
                    .ValueGeneratedNever();

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("datetime");

                entity.Property(e => e.Total).HasColumnName("total");
            });

            modelBuilder.Entity<Concepto>(entity =>
            {
                entity.HasKey(e => e.IdConcepto)
                    .HasName("PK__Concepto__25A881FDD15B03CA");

                entity.Property(e => e.IdConcepto)
                    .HasColumnName("idConcepto")
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.MontoFijo).HasColumnName("montoFijo");

                entity.Property(e => e.MontoVariable).HasColumnName("montoVariable");

                entity.Property(e => e.Tipo).HasColumnName("tipo");
            });

            modelBuilder.Entity<DetalleLiquidacion>(entity =>
            {
                entity.HasKey(e => e.IdDetalleLlquidacion)
                    .HasName("PK__DetalleL__ADA04E144A7130B5");

                entity.Property(e => e.IdDetalleLlquidacion)
                    .HasColumnName("idDetalleLlquidacion")
                    .ValueGeneratedNever();

                entity.Property(e => e.ConceptoId).HasColumnName("conceptoId");

                entity.Property(e => e.Haberes)
                    .HasColumnName("haberes")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.LiquidacionId).HasColumnName("liquidacionId");

                entity.Property(e => e.Unidad).HasColumnName("unidad");

                entity.HasOne(d => d.Concepto)
                    .WithMany(p => p.DetalleLiquidacion)
                    .HasForeignKey(d => d.ConceptoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DetalleLi__conce__0FEC5ADD");

                entity.HasOne(d => d.Liquidacion)
                    .WithMany(p => p.DetalleLiquidacion)
                    .HasForeignKey(d => d.LiquidacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DetalleLi__liqui__10E07F16");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado)
                    .HasName("PK__Empleado__5295297C1AA21034");

                entity.HasIndex(e => e.UserId)
                    .HasName("UQ__Empleado__CB9A1CFEFEE2F234")
                    .IsUnique();

                entity.Property(e => e.IdEmpleado)
                    .HasColumnName("idEmpleado")
                    .ValueGeneratedNever();

                entity.Property(e => e.Apellido)
                    .HasColumnName("apellido")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Celular)
                    .HasColumnName("celular")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Cuit).HasColumnName("cuit");

                entity.Property(e => e.Domicilio)
                    .HasColumnName("domicilio")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasColumnName("telefono")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Empleado)
                    .HasForeignKey<Empleado>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Empleado__userId__056ECC6A");
            });

            modelBuilder.Entity<GrupoFamiliar>(entity =>
            {
                entity.HasKey(e => e.IdGrupofamiliar)
                    .HasName("PK__GrupoFam__3D65669A3B5BD5A0");

                entity.Property(e => e.IdGrupofamiliar)
                    .HasColumnName("idGrupofamiliar")
                    .ValueGeneratedNever();

                entity.Property(e => e.Apellido)
                    .HasColumnName("apellido")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Dni).HasColumnName("dni");

                entity.Property(e => e.EmpleadoId).HasColumnName("empleadoId");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnName("fechaNacimiento")
                    .HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Parentesco)
                    .HasColumnName("parentesco")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Empleado)
                    .WithMany(p => p.GrupoFamiliar)
                    .HasForeignKey(d => d.EmpleadoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GrupoFami__emple__084B3915");
            });

            modelBuilder.Entity<LineaDeCompra>(entity =>
            {
                entity.HasKey(e => e.IdLineadecompra)
                    .HasName("PK__LineaDeC__19C9D5BEA84680FF");

                entity.Property(e => e.IdLineadecompra)
                    .HasColumnName("idLineadecompra")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.CompraId).HasColumnName("compraId");

                entity.Property(e => e.ProductoId).HasColumnName("productoId");

                entity.Property(e => e.Subtotal).HasColumnName("subtotal");

                entity.HasOne(d => d.Compra)
                    .WithMany(p => p.LineaDeCompra)
                    .HasForeignKey(d => d.CompraId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LineaDeCo__compr__314D4EA8");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.LineaDeCompra)
                    .HasForeignKey(d => d.ProductoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LineaDeCo__produ__324172E1");
            });

            modelBuilder.Entity<LineaDeVenta>(entity =>
            {
                entity.HasKey(e => e.IdLineadeventa)
                    .HasName("PK__LineaDeV__547E370148B313E6");

                entity.Property(e => e.IdLineadeventa)
                    .HasColumnName("idLineadeventa")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.ProductoId).HasColumnName("productoId");

                entity.Property(e => e.Subtotal).HasColumnName("subtotal");

                entity.Property(e => e.VentaId).HasColumnName("ventaId");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.LineaDeVenta)
                    .HasForeignKey(d => d.ProductoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LineaDeVe__produ__2B947552");

                entity.HasOne(d => d.Venta)
                    .WithMany(p => p.LineaDeVenta)
                    .HasForeignKey(d => d.VentaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LineaDeVe__venta__2AA05119");
            });

            modelBuilder.Entity<Liquidacion>(entity =>
            {
                entity.HasKey(e => e.IdLiquidacion)
                    .HasName("PK__Liquidac__AD38F40F69F34AD9");

                entity.Property(e => e.IdLiquidacion)
                    .HasColumnName("idLiquidacion")
                    .ValueGeneratedNever();

                entity.Property(e => e.EmpleadoId).HasColumnName("empleadoId");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FechaDesde)
                    .HasColumnName("fechaDesde")
                    .HasColumnType("date");

                entity.Property(e => e.FechaHasta)
                    .HasColumnName("fechaHasta")
                    .HasColumnType("date");

                entity.Property(e => e.PeriodoLiquidacion)
                    .HasColumnName("periodoLiquidacion")
                    .HasColumnType("date");

                entity.Property(e => e.Retenciones).HasColumnName("retenciones");

                entity.Property(e => e.SalarioBruto).HasColumnName("salarioBruto");

                entity.Property(e => e.SalarioNeto).HasColumnName("salarioNeto");

                entity.HasOne(d => d.Empleado)
                    .WithMany(p => p.Liquidacion)
                    .HasForeignKey(d => d.EmpleadoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Liquidaci__emple__0B27A5C0");
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.HasKey(e => e.IdMarca)
                    .HasName("PK__Marca__703318124DE92BF2");

                entity.Property(e => e.IdMarca)
                    .HasColumnName("idMarca")
                    .ValueGeneratedNever();

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MovimientoCaja>(entity =>
            {
                entity.HasKey(e => e.IdMovimientoCaja)
                    .HasName("PK__Movimien__77EEFB2DDAABD479");

                entity.Property(e => e.IdMovimientoCaja)
                    .HasColumnName("idMovimientoCaja")
                    .ValueGeneratedNever();

                entity.Property(e => e.CajaId).HasColumnName("cajaId");

                entity.Property(e => e.CompraId).HasColumnName("compraId");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.VentaId).HasColumnName("ventaId");

                entity.HasOne(d => d.Caja)
                    .WithMany(p => p.MovimientoCaja)
                    .HasForeignKey(d => d.CajaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Movimient__cajaI__58671BC9");

                entity.HasOne(d => d.Compra)
                    .WithMany(p => p.MovimientoCaja)
                    .HasForeignKey(d => d.CompraId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Movimient__compr__595B4002");

                entity.HasOne(d => d.Venta)
                    .WithMany(p => p.MovimientoCaja)
                    .HasForeignKey(d => d.VentaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Movimient__venta__5A4F643B");
            });

            modelBuilder.Entity<Pago>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__Pago__BD2295AD89B57E9B");

                entity.HasIndex(e => e.VentaId)
                    .HasName("UQ__Pago__40B8EB5565F786B6")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Monto).HasColumnName("monto");

                entity.Property(e => e.VentaId).HasColumnName("ventaId");

                entity.Property(e => e.Vuelto).HasColumnName("vuelto");

                entity.HasOne(d => d.Venta)
                    .WithOne(p => p.Pago)
                    .HasForeignKey<Pago>(d => d.VentaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Pago__ventaId__178D7CA5");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PK__Producto__07F4A1322C9C8904");

                entity.Property(e => e.IdProducto)
                    .HasColumnName("idProducto")
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoriaId).HasColumnName("categoriaId");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FechaVencimiento)
                    .HasColumnName("fechaVencimiento")
                    .HasColumnType("date");

                entity.Property(e => e.Foto)
                    .HasColumnName("foto")
                    .HasColumnType("image");

                entity.Property(e => e.MarcaId).HasColumnName("marcaId");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.PrecioCompra).HasColumnName("precioCompra");

                entity.Property(e => e.PrecioVenta).HasColumnName("precioVenta");

                entity.Property(e => e.ProveedorId).HasColumnName("proveedorId");

                entity.Property(e => e.Stock).HasColumnName("stock");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.CategoriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Producto__catego__25DB9BFC");

                entity.HasOne(d => d.Marca)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.MarcaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Producto__marcaI__26CFC035");

                entity.HasOne(d => d.Proveedor)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.ProveedorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Producto__provee__27C3E46E");
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.HasKey(e => e.IdProveedor)
                    .HasName("PK__Proveedo__A3FA8E6BB53D4BFD");

                entity.Property(e => e.IdProveedor)
                    .HasColumnName("idProveedor")
                    .ValueGeneratedNever();

                entity.Property(e => e.CompraId).HasColumnName("compraId");

                entity.Property(e => e.Cuit).HasColumnName("cuit");

                entity.Property(e => e.RazonSocial)
                    .HasColumnName("razonSocial")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasColumnName("telefono")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.HasOne(d => d.Compra)
                    .WithMany(p => p.Proveedor)
                    .HasForeignKey(d => d.CompraId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Proveedor__compr__22FF2F51");
            });

            modelBuilder.Entity<SubCategoria>(entity =>
            {
                entity.HasKey(e => e.IdSubcategoria)
                    .HasName("PK__SubCateg__8EA501869E5A1067");

                entity.Property(e => e.IdSubcategoria)
                    .HasColumnName("idSubcategoria")
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoriaId).HasColumnName("categoriaId");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.SubCategoria)
                    .HasForeignKey(d => d.CategoriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SubCatego__categ__1E3A7A34");
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.HasKey(e => e.IdVenta)
                    .HasName("PK__Venta__077D56147832A66E");

                entity.Property(e => e.IdVenta)
                    .HasColumnName("idVenta")
                    .ValueGeneratedNever();

                entity.Property(e => e.EmpleadoId).HasColumnName("empleadoId");

                entity.Property(e => e.Estado).HasColumnName("ESTADO");

                entity.Property(e => e.FechaVenta)
                    .HasColumnName("fechaVenta")
                    .HasColumnType("datetime");

                entity.Property(e => e.Total).HasColumnName("TOTAL");

                entity.HasOne(d => d.Empleado)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.EmpleadoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Venta__empleadoI__13BCEBC1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
