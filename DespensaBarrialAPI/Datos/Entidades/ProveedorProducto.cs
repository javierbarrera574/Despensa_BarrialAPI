namespace DespensaBarrialAPI.Datos.Entidades
{
    public class ProveedorProducto
    {
        public int ProveedorId { get; set; }
        public int ProductoId { get; set; }
        public Proveedores Proveedores { get; set; }
        public Productos Productos { get; set; }
    }
}
