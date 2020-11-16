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
        public virtual DbSet<Capacidad> Capacidad { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Compra> Compra { get; set; }
        public virtual DbSet<Concepto> Concepto { get; set; }
        public virtual DbSet<DetalleLiquidacion> DetalleLiquidacion { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<GrupoFamiliar> GrupoFamiliar { get; set; }
        public virtual DbSet<LineaCompra> LineaCompra { get; set; }
        public virtual DbSet<LineaVenta> LineaVenta { get; set; }
        public virtual DbSet<Liquidacion> Liquidacion { get; set; }
        public virtual DbSet<Marca> Marca { get; set; }
        public virtual DbSet<MovimientoCaja> MovimientoCaja { get; set; }
        public virtual DbSet<Pago> Pago { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Proveedor> Proveedor { get; set; }
        public virtual DbSet<SubCategoria> SubCategoria { get; set; }
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

            modelBuilder.Entity<Capacidad>(entity =>
            {
                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.ProductoId).HasColumnName("productoId");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.Capacidad)
                    .HasForeignKey(d => d.ProductoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Capacidad__produ__6B1AC8E1");
            });

            modelBuilder.Entity<Categoria>(entity =>
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
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.MontoFijo).HasColumnName("montoFijo");

                entity.Property(e => e.MontoVariable).HasColumnName("montoVariable");

                entity.Property(e => e.Tipo).HasColumnName("tipo");
            });

            modelBuilder.Entity<DetalleLiquidacion>(entity =>
            {
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
                    .HasConstraintName("FK__DetalleLi__conce__4C9641C1");

                entity.HasOne(d => d.Liquidacion)
                    .WithMany(p => p.DetalleLiquidacion)
                    .HasForeignKey(d => d.LiquidacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DetalleLi__liqui__4D8A65FA");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("UQ__Empleado__CB9A1CFE0C54C1C1")
                    .IsUnique();

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
                    .HasConstraintName("FK__Empleado__userId__4218B34E");
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
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GrupoFami__emple__44F51FF9");
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
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LineaComp__compr__6DF7358C");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.LineaCompra)
                    .HasForeignKey(d => d.ProductoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LineaComp__produ__6EEB59C5");
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
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LineaVent__produ__683E5C36");

                entity.HasOne(d => d.Venta)
                    .WithMany(p => p.LineaVenta)
                    .HasForeignKey(d => d.VentaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LineaVent__venta__674A37FD");
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
                    .HasConstraintName("FK__Liquidaci__emple__47D18CA4");
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
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Movimient__cajaI__73B00EE2");

                entity.HasOne(d => d.Compra)
                    .WithMany(p => p.MovimientoCaja)
                    .HasForeignKey(d => d.CompraId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Movimient__compr__74A4331B");

                entity.HasOne(d => d.Venta)
                    .WithMany(p => p.MovimientoCaja)
                    .HasForeignKey(d => d.VentaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Movimient__venta__75985754");
            });

            modelBuilder.Entity<Pago>(entity =>
            {
                entity.HasIndex(e => e.VentaId)
                    .HasName("UQ__Pago__40B8EB55B2137B6A")
                    .IsUnique();

                entity.Property(e => e.Monto).HasColumnName("monto");

                entity.Property(e => e.VentaId).HasColumnName("ventaId");

                entity.Property(e => e.Vuelto).HasColumnName("vuelto");

                entity.HasOne(d => d.Venta)
                    .WithOne(p => p.Pago)
                    .HasForeignKey<Pago>(d => d.VentaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Pago__ventaId__54376389");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
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
                    .HasConstraintName("FK__Producto__catego__628582E0");

                entity.HasOne(d => d.Marca)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.MarcaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Producto__marcaI__6379A719");

                entity.HasOne(d => d.Proveedor)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.ProveedorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Producto__provee__646DCB52");
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
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
                    .HasConstraintName("FK__Proveedor__compr__5FA91635");
            });

            modelBuilder.Entity<SubCategoria>(entity =>
            {
                entity.Property(e => e.CategoriaId).HasColumnName("categoriaId");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.SubCategoria)
                    .HasForeignKey(d => d.CategoriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SubCatego__categ__5AE46118");
            });

            modelBuilder.Entity<Venta>(entity =>
            {
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
                    .HasConstraintName("FK__Venta__empleadoI__5066D2A5");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
