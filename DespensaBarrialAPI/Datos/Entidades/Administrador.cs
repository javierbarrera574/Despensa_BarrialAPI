using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DespensaBarrialAPI.Datos.Entidades
{
    public class Administrador
    {

        public int IdAdministrador { get; set; }

        public string Nombre { get; set; }

        public HashSet<Proveedores> ProveedoresAdministrador { get; set; }

        public Empleado UnEmpleado { get; set; }


    }
}
