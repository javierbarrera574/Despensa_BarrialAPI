using DespensaBarrialAPI.Datos.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace DespensaBarrialAPI.Controllers
{
    public class DepositoController : ControllerBase
    {
        private readonly DespensaBarrialAPIDbContext context;


        [HttpPost("AgregarProductos")]

        public async Task<ActionResult<Deposito>> Post(int cantidad)
        {
            if (cantidad < 10)
            {

                var deposito = await context.Productos.FirstOrDefaultAsync(prop => prop.DepositoCantidad.UnidadMinima < cantidad);

                context.Add(deposito);

                await context.SaveChangesAsync();

            }
            return Ok();

        }


    }
}
