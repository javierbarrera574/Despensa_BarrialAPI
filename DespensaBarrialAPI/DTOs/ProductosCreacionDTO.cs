namespace DespensaBarrialAPI.Dtos
{
    public class ProductosCreacionDTO
    {


        public List<int> Categorias { get; set; }

        public enum TipoCategoria { }


        public HashSet<ProveedoresProductosCreacionDTO> ProveedoresProductos { get; set; }



    }
}
