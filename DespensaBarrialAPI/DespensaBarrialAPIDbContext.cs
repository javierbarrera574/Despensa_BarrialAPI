using DespensaBarrialAPI.Datos.Entidades;
using DespensaBarrialAPI.Datos.Entidades.Seeding;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DespensaBarrialAPI
{
    public class DespensaBarrialAPIDbContext : DbContext
    {

        public DespensaBarrialAPIDbContext(DbContextOptions options) : base(options) { }


        protected override void ConfigureConventions(ModelConfigurationBuilder modelConfigurationBuilder)
        {

            modelConfigurationBuilder.Properties<DateTime>().HaveColumnType("Date");

        }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            SeedingModuloConsulta.Seed(modelBuilder);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        public DbSet<ProveedorProducto> ProveedorProducto { get; set; }

        public DbSet<Productos> Productos { get; set; }

        public DbSet<Proveedores> Proveedores { get; set; }

        public DbSet<Empleado> Empleado { get; set; }

        public DbSet<Deposito> StockDeposito { get; set; }

        public DbSet<Administrador> Administrador { get; set; }

        public Categorias Categoria { get; set; }

        public DbSet<Logs> Logs { get; set; }

    }
}