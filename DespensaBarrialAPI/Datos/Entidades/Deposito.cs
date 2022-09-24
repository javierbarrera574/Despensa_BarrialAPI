using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DespensaBarrialAPI.Datos.Entidades
{
    public class Deposito
    {

        public int UnidadMinima { get; set; }

        public List<Productos> ProductosEnDeposito { get; set; }

        public Empleado EmpleadoDeposito { get; set; }


    }
}
