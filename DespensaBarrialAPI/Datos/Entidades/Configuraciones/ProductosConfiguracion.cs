using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DespensaBarrialAPI.Datos.Entidades;

namespace DespensaBarrialAPI.BD.Datos.Entidades.Configuraciones
{
    internal class ProductosConfiguracion : IEntityTypeConfiguration<Productos>
    {
        public void Configure(EntityTypeBuilder<Productos> builder)
        {
            builder.
            Property(prop => prop.PrecioProducto).
            HasPrecision(precision: 14, scale: 2);

            builder.
                Property(prop => prop.DescripcionProducto).
                IsRequired();


            builder.HasQueryFilter(prop => !prop.EstaBorrado);

            builder.
                HasIndex(prop => prop.NombreProducto).
                IsUnique().
                HasFilter("EstaBorrado= 'false'");



        }
    }
}


//Tres maneras de configurar relaciones:
//*Por Convencion:
//Por Anotacion de datos:
//Por Capitulo:

