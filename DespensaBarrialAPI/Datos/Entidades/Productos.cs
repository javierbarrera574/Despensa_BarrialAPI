using Microsoft.EntityFrameworkCore;


namespace DespensaBarrialAPI.Datos.Entidades
{

    [Index(nameof(NombreProducto), IsUnique = true)]

    //Esto me garantiza que no haya dos productos con el mismo nombre

    public class Productos
    {

        public int IdProductos { get; set; }

        public Categorias Categoria { get; set; }

        public string NombreProducto { get; set; }

        public string DescripcionProducto { get; set; }

        public DateTime? FechaVencimientoProducto { get; set; }

        public bool EstaBorrado { get; set; }

        public decimal PrecioProducto { get; set; }

        public List<ProveedorProducto> ProveedorProductos { get; set; }

        public Deposito DepositoCantidad { get; set; }


    }
}
