using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;

public class DetallePedidoConfiguration : IEntityTypeConfiguration<DetallePedido>
{
    public void Configure(EntityTypeBuilder<DetallePedido> builder)
    {
        builder.HasKey(e => e.CodigoPedido).HasName("PRIMARY");

            builder.ToTable("detalle_pedido");

            builder.HasIndex(e => e.CodigoProducto, "codigo_producto");

            builder.Property(e => e.CodigoPedido)
                .ValueGeneratedNever()
                .HasColumnName("codigo_pedido");
            builder.Property(e => e.Cantidad).HasColumnName("cantidad");
            builder.Property(e => e.CodigoProducto)
                .HasMaxLength(15)
                .HasColumnName("codigo_producto");
            builder.Property(e => e.NumeroLinea).HasColumnName("numero_linea");
            builder.Property(e => e.PrecioUnidad)
                .HasPrecision(15, 2)
                .HasColumnName("precio_unidad");

            builder.HasOne(d => d.CodigoPedidoNavigation).WithOne(p => p.DetallePedido)
                .HasForeignKey<DetallePedido>(d => d.CodigoPedido)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("detalle_pedido_ibfk_1");

            builder.HasOne(d => d.CodigoProductoNavigation).WithMany(p => p.DetallePedidos)
                .HasForeignKey(d => d.CodigoProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("detalle_pedido_ibfk_2");
    }
}