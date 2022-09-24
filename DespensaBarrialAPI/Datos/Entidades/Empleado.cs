using System.ComponentModel.DataAnnotations.Schema;

namespace DespensaBarrialAPI.Datos.Entidades
{
    public class Empleado
    {

        public int IdEmpleado { get; set; }

        public string NombreEmpleado { get; set; }

        public ulong EdadEmpleado { get; set; }

        public DateTime? FechaNacimiento { get; set; }

        public string Domicilio { get; set; }

        public ulong NumeroTelefono { get; set; }

        public int AdministadorId { get; set; }

        [ForeignKey(nameof(AdministadorId))]


        public Administrador administrador { get; set; }

    }
}