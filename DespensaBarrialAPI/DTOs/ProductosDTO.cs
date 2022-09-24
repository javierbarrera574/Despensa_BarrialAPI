namespace DespensaBarrialAPI.Dtos
{
    public class ProductosDTO
    {

        public int Id { get; set; }
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public decimal Precio { get; set; }
        public ICollection<CategoriasDTO> Categorias { get; set; } = new List<CategoriasDTO>();
        public ICollection<ProveedoresDTO> Proveedores { get; set; }

    }
}
