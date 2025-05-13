using ApiPeliculas.Models;

namespace ApiPeliculas.Repositorio.IRepositorio
{
    public interface IPeliculaRepositorio
    {
        ICollection<Pelicula> GetPeliculas();
        ICollection<Pelicula> GetPeliculasEnCategoria(int categoriaId);
        IEnumerable<Pelicula> BuscarPelicula(string nombre);
        Pelicula GetPelicula(int peliculaId);
        bool ExistePelicula(int Id);
        bool ExistePelicula(string name);
        bool CrearPelicula(Pelicula Pelicula);
        bool ActualizarPelicula(Pelicula Pelicula);
        bool BorrarPelicula(Pelicula Pelicula);
        bool Guardar();


    }
}
