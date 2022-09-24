using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DespensaBarrialAPI.Datos.Entidades;

namespace DespensaBarrialAPI.BD.Datos.Entidades.Configuraciones
{
    public class ProveedorProductoConfiguracion : IEntityTypeConfiguration<ProveedorProducto>
    {
        public void Configure(EntityTypeBuilder<ProveedorProducto> builder)
        {


            builder.HasKey(prop => new
            {

                prop.ProveedorId,

                prop.ProductoId
            });

            builder.
                HasOne(pp => pp.Productos).
                WithMany(p => p.ProveedorProductos).
                HasForeignKey(pa => pa.ProveedorId);

            builder.
                HasOne(pp => pp.Proveedores).
                WithMany(p => p.ProveedorProductos).HasForeignKey(p => p.ProveedorId);


        }
    }
}