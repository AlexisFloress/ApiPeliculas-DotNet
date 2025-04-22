using ApiPeliculas.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPeliculas.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        //Aqui se pasan todos los modelos
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Pelicula> Pelicula { get; set; }
    }
}
