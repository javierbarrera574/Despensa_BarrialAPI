using AutoMapper;
using DespensaBarrialAPI.Datos.Entidades;
using DespensaBarrialAPI.Dtos;

namespace DespensaBarrialAPI.Servicios
{
    public class AutoMapperPerfiles : Profile
    {
        public AutoMapperPerfiles()
        {

            CreateMap<ProductosCreacionDTO, Productos>()
              .ForMember(ent => ent.Categoria,
                  dto => dto.
                  MapFrom(campo => campo.Categorias.
                  Select
                  (
                      id =>
                      
                      new Categorias()

                  { 
                          IdCategoria = id 
                      }
                      )
                  )

                  )
              ;


            CreateMap<ProveedoresProductosCreacionDTO, ProveedorProducto>();

            CreateMap<ProveedoresDTO, Proveedores>();

        }
    }
}