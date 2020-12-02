using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using FarmaciaAvellaneda.Models;

namespace FarmaciaAvellaneda.Data
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

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Caja> Caja { get; set; }
        public virtual DbSet<CajaAhorro> CajaAhorro { get; set; }
        public virtual DbSet<Capacidad> Capacidad { get; set; }
        public virtual DbSet<CategoriaProducto> CategoriaProducto { get; set; }
        public virtual DbSet<Compra> Compra { get; set; }
        public virtual DbSet<Concepto> Concepto { get; set; }
        public virtual DbSet<DetalleLiquidacion> DetalleLiquidacion { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<GrupoFamiliar> GrupoFamiliar { get; set; }
        public virtual DbSet<LineaCompra> LineaCompra { get; set; }
        public virtual DbSet<LineaVenta> LineaVenta { get; set; }
        public virtual DbSet<Liquidacion> Liquidacion { get; set; }
        public virtual DbSet<Marca> Marca { get; set; }
        public virtual DbSet<MovimientoCaja> MovimientoCaja { get; set; }
        public virtual DbSet<Pago> Pago { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Proveedor> Proveedor { get; set; }
        public virtual DbSet<SubCategoriaProducto> SubCategoriaProducto { get; set; }
        public virtual DbSet<Venta> Venta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=DefaultConnection");
            }
        }

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
                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Saldo).HasColumnName("saldo");
            });

            modelBuilder.Entity<CajaAhorro>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Banco)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Cbu)
                    .HasColumnName("cbu")
                    .HasMaxLength(450);

                entity.Property(e => e.Cuenta).HasMaxLength(450);
            });

            modelBuilder.Entity<Capacidad>(entity =>
            {
                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.ProductoId).HasColumnName("productoId");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.Capacidad)
                    .HasForeignKey(d => d.ProductoId)
                    .HasConstraintName("FK_Capacidad_Producto");
            });

            modelBuilder.Entity<CategoriaProducto>(entity =>
            {
                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Compra>(entity =>
            {
                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("datetime");

                entity.Property(e => e.Total).HasColumnName("total");
            });

            modelBuilder.Entity<Concepto>(entity =>
            {
                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Exento).HasColumnName("exento");

                entity.Property(e => e.Monto).HasColumnName("monto");

                entity.Property(e => e.Tipo).HasColumnName("tipo");

                entity.Property(e => e.Unidad).HasColumnName("unidad");
            });

            modelBuilder.Entity<DetalleLiquidacion>(entity =>
            {
                entity.Property(e => e.ConceptoId).HasColumnName("conceptoId");

                entity.Property(e => e.Deduccion)
                    .HasColumnName("deduccion")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Haber)
                    .HasColumnName("haber")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.LiquidacionId).HasColumnName("liquidacionId");

                entity.Property(e => e.Unidad).HasColumnName("unidad");

                entity.HasOne(d => d.Concepto)
                    .WithMany(p => p.DetalleLiquidacion)
                    .HasForeignKey(d => d.ConceptoId)
                    .HasConstraintName("FK_DetalleLiquidacion_Concepto");

                entity.HasOne(d => d.Liquidacion)
                    .WithMany(p => p.DetalleLiquidacion)
                    .HasForeignKey(d => d.LiquidacionId)
                    .HasConstraintName("FK_DetalleLiquidacion_Liquidacion");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasIndex(e => e.CajaAhorroId)
                    .HasName("UQ__Empleado__57E86AD0FC9158A8")
                    .IsUnique();

                entity.HasIndex(e => e.UserId)
                    .HasName("UQ__Empleado__CB9A1CFED2E64194")
                    .IsUnique();

                entity.Property(e => e.Apellido)
                    .HasColumnName("apellido")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CajaAhorroId).HasColumnName("cajaAhorroId");

                entity.Property(e => e.Celular)
                    .HasColumnName("celular")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Cuit)
                    .HasColumnName("cuit")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Domicilio)
                    .HasColumnName("domicilio")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.EmpresaId).HasColumnName("empresaId");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasColumnName("telefono")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("userId");

                entity.HasOne(d => d.CajaAhorro)
                    .WithOne(p => p.Empleado)
                    .HasForeignKey<Empleado>(d => d.CajaAhorroId)
                    .HasConstraintName("FK_Empleado_CajaAhorro");

                entity.HasOne(d => d.Empresa)
                    .WithMany(p => p.Empleado)
                    .HasForeignKey(d => d.EmpresaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Empleado_Empresa");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Empleado)
                    .HasForeignKey<Empleado>(d => d.UserId)
                    .HasConstraintName("FK_Empleado_UserId");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Cuit)
                    .IsRequired()
                    .HasColumnName("cuit")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasColumnName("direccion")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GrupoFamiliar>(entity =>
            {
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
                    .HasConstraintName("FK_GrupoFamiliar_Empleado");
            });

            modelBuilder.Entity<LineaCompra>(entity =>
            {
                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.CompraId).HasColumnName("compraId");

                entity.Property(e => e.ProductoId).HasColumnName("productoId");

                entity.Property(e => e.Subtotal).HasColumnName("subtotal");

                entity.HasOne(d => d.Compra)
                    .WithMany(p => p.LineaCompra)
                    .HasForeignKey(d => d.CompraId)
                    .HasConstraintName("FK_LineaCompra_Compra");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.LineaCompra)
                    .HasForeignKey(d => d.ProductoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LineaCompra_Producto");
            });

            modelBuilder.Entity<LineaVenta>(entity =>
            {
                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.ProductoId).HasColumnName("productoId");

                entity.Property(e => e.Subtotal).HasColumnName("subtotal");

                entity.Property(e => e.VentaId).HasColumnName("ventaId");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.LineaVenta)
                    .HasForeignKey(d => d.ProductoId)
                    .HasConstraintName("FK_LineaVenta_Producto");

                entity.HasOne(d => d.Venta)
                    .WithMany(p => p.LineaVenta)
                    .HasForeignKey(d => d.VentaId)
                    .HasConstraintName("FK_LineaVenta_Venta");
            });

            modelBuilder.Entity<Liquidacion>(entity =>
            {
                entity.Property(e => e.EmpleadoId).HasColumnName("empleadoId");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FechaDesde)
                    .HasColumnName("fechaDesde")
                    .HasColumnType("date");

                entity.Property(e => e.FechaHasta)
                    .HasColumnName("fechaHasta")
                    .HasColumnType("date");

                entity.Property(e => e.LugarPago)
                    .HasColumnName("lugarPago")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PeriodoLiquidacion)
                    .HasColumnName("periodoLiquidacion")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.SalarioDescripto)
                    .HasColumnName("salarioDescripto")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SalarioNeto).HasColumnName("salarioNeto");

                entity.Property(e => e.TotalDeduccion).HasColumnName("totalDeduccion");

                entity.Property(e => e.TotalRemunerado).HasColumnName("totalRemunerado");

                entity.HasOne(d => d.Empleado)
                    .WithMany(p => p.Liquidacion)
                    .HasForeignKey(d => d.EmpleadoId)
                    .HasConstraintName("FK_Liquidacion_Empleado");
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MovimientoCaja>(entity =>
            {
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
                    .HasConstraintName("FK_MovimientoCaja_Caja");

                entity.HasOne(d => d.Compra)
                    .WithMany(p => p.MovimientoCaja)
                    .HasForeignKey(d => d.CompraId)
                    .HasConstraintName("FK_MovimientoCaja_Compra");

                entity.HasOne(d => d.Venta)
                    .WithMany(p => p.MovimientoCaja)
                    .HasForeignKey(d => d.VentaId)
                    .HasConstraintName("FK_MovimientoCaja_Venta");
            });

            modelBuilder.Entity<Pago>(entity =>
            {
                entity.HasIndex(e => e.VentaId)
                    .HasName("UQ__Pago__40B8EB55BDD3C069")
                    .IsUnique();

                entity.Property(e => e.Monto).HasColumnName("monto");

                entity.Property(e => e.VentaId).HasColumnName("ventaId");

                entity.Property(e => e.Vuelto).HasColumnName("vuelto");

                entity.HasOne(d => d.Venta)
                    .WithOne(p => p.Pago)
                    .HasForeignKey<Pago>(d => d.VentaId)
                    .HasConstraintName("FK_Pago_Venta");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.Property(e => e.CategoriaProductoId).HasColumnName("categoriaProductoId");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(60)
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
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.PrecioCompra).HasColumnName("precioCompra");

                entity.Property(e => e.PrecioVenta).HasColumnName("precioVenta");

                entity.Property(e => e.ProveedorId).HasColumnName("proveedorId");

                entity.Property(e => e.Stock).HasColumnName("stock");

                entity.HasOne(d => d.CategoriaProducto)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.CategoriaProductoId)
                    .HasConstraintName("FK_Producto_Categoria");

                entity.HasOne(d => d.Marca)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.MarcaId)
                    .HasConstraintName("FK_Producto_Marca");

                entity.HasOne(d => d.Proveedor)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.ProveedorId)
                    .HasConstraintName("FK_Producto_Proveedor");
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.Property(e => e.CompraId).HasColumnName("compraId");

                entity.Property(e => e.Cuit)
                    .HasColumnName("cuit")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.RazonSocial)
                    .HasColumnName("razonSocial")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasColumnName("telefono")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.HasOne(d => d.Compra)
                    .WithMany(p => p.Proveedor)
                    .HasForeignKey(d => d.CompraId)
                    .HasConstraintName("FK_Proveedor_Compra");
            });

            modelBuilder.Entity<SubCategoriaProducto>(entity =>
            {
                entity.Property(e => e.CategoriaProductoId).HasColumnName("categoriaProductoId");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.HasOne(d => d.CategoriaProducto)
                    .WithMany(p => p.SubCategoriaProducto)
                    .HasForeignKey(d => d.CategoriaProductoId)
                    .HasConstraintName("FK_SubCategoria_Categoria_Producto");
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.Property(e => e.EmpleadoId).HasColumnName("empleadoId");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FechaVenta)
                    .HasColumnName("fechaVenta")
                    .HasColumnType("datetime");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.HasOne(d => d.Empleado)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.EmpleadoId)
                    .HasConstraintName("FK_Venta_Empleado");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
