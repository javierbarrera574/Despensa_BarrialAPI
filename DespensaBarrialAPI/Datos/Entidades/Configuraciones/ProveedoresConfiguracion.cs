using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DespensaBarrialAPI.Datos.Entidades;


namespace DespensaBarrialAPI.BD.Datos.Entidades.Configuraciones
{
    internal class ProveedoresConfiguracion : IEntityTypeConfiguration<Proveedores>
    {
        public void Configure(EntityTypeBuilder<Proveedores> builder)
        {
            builder.Property(prop => prop.Nombre).IsRequired();

            builder.Property(prop => prop.Nombre).HasField("_Nombre");

            builder.
                Property(prop => prop.NumeroTelefono).
                HasMaxLength(9).
                IsRequired();

            builder.Property(prop => prop.CorreoElectronico).IsRequired();

        }
    }
}