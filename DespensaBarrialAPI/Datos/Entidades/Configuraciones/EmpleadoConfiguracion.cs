using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DespensaBarrialAPI.Datos.Entidades;


namespace DespensaBarrialAPI.BD.Datos.Entidades.Configuraciones
{

    class EmpleadoConfiguracion : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> builder)
        {
            builder.
                Property(prop => prop.NumeroTelefono).
                HasMaxLength(8).
                IsRequired();

            builder.Property(prop => prop.NombreEmpleado).IsRequired();

        }
    }
}
