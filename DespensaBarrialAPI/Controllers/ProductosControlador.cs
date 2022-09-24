using AutoMapper;
using AutoMapper.QueryableExtensions;
using DespensaBarrialAPI.Datos.Entidades;
using DespensaBarrialAPI.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DespensaBarrialAPI.Server.Controllers
{

    [ApiController]

    [Route("api/Productos")]

    public class ProductosControlador : ControllerBase
    {
        private readonly DespensaBarrialAPIDbContext context;

        private readonly IMapper mapper;

        public ProductosControlador(DespensaBarrialAPIDbContext contexto, IMapper Mapper)
        {
            this.context = contexto;
            this.mapper = Mapper;
        }



        [HttpGet]


        public async Task<IEnumerable<ProductosDTO>> GetAutoMapper()
        {
            return await context.Productos.ProjectTo<ProductosDTO>(mapper.ConfigurationProvider).ToListAsync();
        }


        [HttpGet]


        //para que devuelva el query utilizando Select uso ActionResult
        public async Task<IEnumerable<ProductosDTO>> Get()
        {
            var productos = await context.Productos.
                Select
                (
                prop =>
                new ProductosDTO
                {

                    Id = prop.IdProductos,
                    Nombre = prop.NombreProducto,
                    Descripcion = prop.DescripcionProducto,
                    Precio = prop.PrecioProducto

                }
                ).
                ToListAsync();


            return productos;
        }

        //[HttpGet("OrdenarPorFecha")]-->Ver como hacerlo



        [HttpGet("{id:int}")]



        public async Task<ActionResult<Productos>> Buscar(int id)
        {

            var productos = await context.Productos.

                Include(prop => prop.Categoria).

                ThenInclude(prop => prop.TipoDeCategoria).

                Include(prop => prop.ProveedorProductos).

                FirstOrDefaultAsync(prop => prop.IdProductos == id);

            return productos;

        }






        [HttpGet("UsandoProjecTo/{id:int}")]

        public async Task<ActionResult<ProductosDTO>> Buscar1(int id)
        {

            var productos = await context.Productos.

                ProjectTo<ProductosDTO>(mapper.ConfigurationProvider).
                FirstOrDefaultAsync(prop => prop.Id == id);

            if (productos is null)
            {
                return NotFound();
            }

            return Ok(productos);

        }

        [HttpGet("CargaSelectiva/{id:int}")]

        public async Task<ActionResult> GetSelectivo(int id)
        {

            var productos = await context.Productos.Select(prop =>
            new
            {
                IdProductos = prop.IdProductos,

                NombreProducto = prop.NombreProducto,

                DescripcionProducto = prop.DescripcionProducto,

                FechaVencimientoProducto = prop.FechaVencimientoProducto,

                PrecioProducto = prop.PrecioProducto,

            }

            ).FirstOrDefaultAsync(prop => prop.IdProductos == id);


            if (productos is null)
            {
                return NotFound();
            }

            return Ok(productos);
        }

        //Cargado explicito

        [HttpGet("CargadoExplicito/{id:int}")]


        public async Task<ActionResult<ProductosDTO>> GetExplicito(int id)
        {
            //carga posterior


            var producto = await context.Productos.
                AsTracking().
                FirstOrDefaultAsync(prop => prop.IdProductos == id);


            //cargo si lo deseo tambien desde la coleccion de proveedores en productos

            await context.Entry(producto).Collection(p => p.ProveedorProductos).LoadAsync();

            if (producto is null)
            {
                return NotFound();
            }

            var productoDTO = mapper.Map<ProductosDTO>(producto);

            return productoDTO;

        }


        //insertando registros


        [HttpPost("Ingresar_Registros")]

        public async Task<ActionResult> Post(Productos productos)
        {

            context.Logs.Add(new Logs
            {

                Id = Guid.NewGuid(),

                Mensaje = "Ejecutando el metodo ProductosController.Get"
            });

            await context.SaveChangesAsync();

            var Estado = context.Entry(productos).State;//sin agregar

            //cambio el estado de productos a "agregado"

            context.Add(productos);

            var Estado1 = context.Entry(productos).State;//agregado

            //no es que lo esta agregando sino que esta proximo a agregar para cuando confirme la accion

            await context.SaveChangesAsync();//se confirma que se agrega

            var Estado2 = context.Entry(productos).State;//sin modificar

            return Ok($"El resultado es: " +
                $"{Estado} y despues el estado es: " +
                $"{Estado1};" +
                $" y por ultimo se guardan los cambios como:" +
                $"{Estado2}");
        }


        [HttpPost("Insertar_Varios_Registros")]

        public async Task<ActionResult> PostVarios(Productos[] productos)
        {

            context.Add(productos);

            await context.SaveChangesAsync();

            return Ok();

        }


        [HttpDelete("{id:int}")]//borrado normal

        public async Task<ActionResult> Delete(int id)
        {

            var producto = await context.Productos.FirstOrDefaultAsync(prop => prop.IdProductos == id);

            if (producto is null)
            {
                return NotFound();
            }

            context.Remove(producto);

            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]

        public async Task<ActionResult> PostRepetir(Productos productos)
        {

            var ProductoExisteConEseNombre = await context.Productos.
                AnyAsync(prop => prop.NombreProducto == productos.NombreProducto);

            if (ProductoExisteConEseNombre)
            {
                return BadRequest
                    ($"Ya existe Producto con ese nombre: {productos.NombreProducto}");
            }
            return Ok();
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult> FechaGet(int id, DateTime fechavencido)
        {

            var productos2 = await context.Productos.AsTracking().
                Include(x => x.NombreProducto).
                OrderBy(x => x.FechaVencimientoProducto).
                Where(x => x.FechaVencimientoProducto <= fechavencido).
                FirstOrDefaultAsync(x => x.IdProductos == id);


            if (productos2.FechaVencimientoProducto < Convert.ToDateTime(fechavencido.Year))
            {
                return BadRequest("Producto vencido");
            }


            return Ok();

        }
    }
}