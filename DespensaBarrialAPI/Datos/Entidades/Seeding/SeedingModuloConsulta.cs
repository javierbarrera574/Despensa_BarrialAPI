using Microsoft.EntityFrameworkCore;

namespace DespensaBarrialAPI.Datos.Entidades.Seeding
{
    public class SeedingModuloConsulta
    {

        public static void Seed(ModelBuilder modelBuilder)
        {


            var AlcoholBebidas = new Categorias { IdCategoria = 1 };
            var Lacteos = new Categorias { IdCategoria = 2 };
            var Azucar = new Categorias { IdCategoria = 3 };


            modelBuilder.Entity<Categorias>().HasData(AlcoholBebidas, Lacteos, Azucar);


            var Alcohol_Bebidas = new Categorias()
            {
                IdCategoria = 1,
                TipoDeCategoria = TipoDeCategoria.BebidasAlcoholicas
            };

            var lacteos = new Categorias()
            {
                IdCategoria = 2,
                TipoDeCategoria = TipoDeCategoria.Lacteos
            };

            var Azucares = new Categorias()
            {
                IdCategoria = 3,
                TipoDeCategoria = TipoDeCategoria.Azucares
            };

            modelBuilder.Entity<Categorias>().HasData(Alcohol_Bebidas, lacteos, Azucares);


            var JuanPerez = new Proveedores
            {
                IdProveedores = 1,
                Nombre = "Juan Perez",
                CorreoElectronico = "juanperez12@gmail.com",
                NumeroTelefono = 2323232
            };

            var JotaroSanchez = new Proveedores()
            {
                IdProveedores = 2,
                Nombre = "Jotaro Sanchez",
                CorreoElectronico = "jotaro_sanchez12@gmail.com",
                NumeroTelefono = 2343424
            };

            var RicardoJuarez = new Proveedores()
            {
                IdProveedores = 3,
                Nombre = "Ricardo Juarez",
                CorreoElectronico = "ricardo_juarez1234@gmail.com",
                NumeroTelefono = 35453323,
            };

            modelBuilder.Entity<Proveedores>().HasData(JuanPerez, JotaroSanchez, RicardoJuarez);

            var Fernet = new Productos()
            {
                IdProductos = 1,

                Categoria = new Categorias()
                {
                    IdCategoria = 1,
                    TipoDeCategoria = TipoDeCategoria.BebidasAlcoholicas,
                },

                NombreProducto = "Fernet Branca",

                DescripcionProducto = "Alcohol bebible",

                FechaVencimientoProducto = new DateTime(2022, 12, 9),

                PrecioProducto = 232,
            };

            var Serenisima = new Productos()
            {
                IdProductos = 2,

                Categoria = new Categorias()
                {
                    IdCategoria = 2,
                    TipoDeCategoria = TipoDeCategoria.Lacteos,
                },

                NombreProducto = "La Serenisima",

                DescripcionProducto = "Lacteos procesados",

                FechaVencimientoProducto = new DateTime(2025, 10, 23),

                PrecioProducto = 12,

            };

            var GalletasOreo = new Productos()
            {
                IdProductos = 3,
                Categoria = new Categorias()
                {
                    IdCategoria = 3,
                    TipoDeCategoria = TipoDeCategoria.Azucares,
                },

                NombreProducto = "Galletas Oreo",

                DescripcionProducto = "Dulces y deliciosas",

                FechaVencimientoProducto = new DateTime(2038, 2, 15),

                PrecioProducto = 23,
            };

            modelBuilder.Entity<Productos>().HasData(Fernet, Serenisima, GalletasOreo);


            var FernetAlcohol = new ProveedorProducto()
            {
                ProductoId = Fernet.IdProductos,
                ProveedorId = JuanPerez.IdProveedores,
            };

            var Lactosa = new ProveedorProducto()
            {
                ProductoId = Serenisima.IdProductos,
                ProveedorId = JotaroSanchez.IdProveedores,
            };

            var azucarado = new ProveedorProducto()
            {
                ProductoId = GalletasOreo.IdProductos,
                ProveedorId = RicardoJuarez.IdProveedores,
            };

            modelBuilder.Entity<Productos>().HasData(Fernet, Serenisima, GalletasOreo);
            modelBuilder.Entity<ProveedorProducto>().HasData(FernetAlcohol, Lactosa, azucarado);


        }
    }
}
