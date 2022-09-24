using System.ComponentModel.DataAnnotations.Schema;

namespace DespensaBarrialAPI.Datos.Entidades
{
    public class Proveedores
    {
        //mapeo flexible--> Para que los nombres de los proveedores empiecen con mayuscula

        public int IdProveedores { get; set; }
        //clave primaria compuesta-->Esta compuesta de dos claves primarias
        public int AdministadorId { get; set; }

        [ForeignKey(nameof(AdministadorId))]

        public string _Nombre { get; set; }

        public string Nombre
        {

            get
            {
                return _Nombre;
            }

            set
            {

                //Esto lo que hace es unir cada de unos los caracteres,
                //que compone el nombre del Proveedor
                _Nombre = string.
                    Join(' ', value.
                    Split(' ').
                    Select(x => x[0].
                    ToString().
                    ToUpper() + x.
                    Substring(1).
                    ToLower().
                    ToArray()));
            }
        }

        public TipoDeCategoria Tipo { get; set; }

        public HashSet<Categorias> categorias { get; set; }

        public string CorreoElectronico { get; set; }

        public int NumeroTelefono { get; set; }

        public HashSet<ProveedorProducto> ProveedorProductos { get; set; }

        public Administrador Administrador { get; set; }



    }
}
