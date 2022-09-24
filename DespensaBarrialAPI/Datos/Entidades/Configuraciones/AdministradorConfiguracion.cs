using DespensaBarrialAPI.Datos.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DespensaBarrialAPI.Datos.Entidades.Configuraciones
{
    internal class AdministradorConfiguracion : IEntityTypeConfiguration<Administrador>
    {
        public void Configure(EntityTypeBuilder<Administrador> builder)
        {

            builder.HasKey(prop => prop.IdAdministrador);

            builder.Property(prop => prop.Nombre).IsRequired();

            builder.
                HasOne(prop => prop.UnEmpleado).
                WithOne().
                HasForeignKey<Empleado>(cf => cf.AdministadorId);

            builder.
                HasMany(prop => prop.ProveedoresAdministrador).
                WithOne(cp => cp.Administrador).
                HasForeignKey(cf => cf.AdministadorId);

        }
    }
}