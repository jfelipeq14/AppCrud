using Microsoft.EntityFrameworkCore;
using AppCrud.Models;

namespace AppCrud.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Servicio> Servicios { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(tb =>
            {
                tb.HasKey(col => col.IdCliente);
                tb.Property(col => col.IdCliente).UseIdentityColumn().ValueGeneratedOnAdd();

                tb.Property(col => col.IdUsuario).IsRequired();
                tb.Property(col => col.IdMunicipio).IsRequired();
                tb.Property(col => col.Direccion).HasMaxLength(100).IsRequired();
                tb.Property(col => col.Telefono).HasMaxLength(15).IsRequired();
                tb.Property(col => col.Sexo).HasMaxLength(1).IsRequired();
                tb.Property(col => col.TipoDeSangre).HasMaxLength(3).IsRequired();
                tb.Property(col => col.Eps).HasMaxLength(50).IsRequired();
                tb.Property(col => col.Estado).HasDefaultValue(true);
            });
            modelBuilder.Entity<Cliente>().ToTable("Cliente");



            modelBuilder.Entity<Servicio>(tb =>
            {
                tb.HasKey(col => col.IdServicio);
                tb.Property(col => col.IdServicio).UseIdentityColumn().ValueGeneratedOnAdd();

                tb.Property(col => col.Nombre).HasMaxLength(100).IsRequired();
                tb.Property(col => col.Categoria).HasMaxLength(50).IsRequired();
                tb.Property(col => col.Estado).HasDefaultValue(true);
            });

            modelBuilder.Entity<Servicio>().ToTable("Servicio");

        }


    }
}
