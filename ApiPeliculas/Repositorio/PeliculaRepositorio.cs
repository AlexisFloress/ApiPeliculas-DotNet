using ApiPeliculas.Data;
using ApiPeliculas.Models;
using ApiPeliculas.Repositorio.IRepositorio;
using Microsoft.EntityFrameworkCore;

namespace ApiPeliculas.Repositorio
{
    public class PeliculaRepositorio : IPeliculaRepositorio
    {
        private readonly ApplicationDbContext _bd;
        public PeliculaRepositorio(ApplicationDbContext bd)
        {
            _bd = bd;
        }

        public bool ActualizarPelicula(Pelicula pelicula)
        {
            pelicula.FechaCreacion = DateTime.Now;
            _bd.Pelicula.Update(pelicula);
            return Guardar();
        }

        public bool BorrarPelicula(Pelicula pelicula)
        {
            _bd.Pelicula.Remove(pelicula);
            return Guardar();
        }

        public bool CrearPelicula(Pelicula pelicula)
        {
            pelicula.FechaCreacion = DateTime.Now;
            _bd.Pelicula.Add(pelicula);
            return Guardar();
        }

        public bool ExistePelicula(int peliculaId)
        {
            return _bd.Pelicula.Any(c =>  c.Id == peliculaId);
        }

        public bool ExistePelicula(string name)
        {
            bool valor = _bd.Pelicula.Any(c => c.Nombre.ToLower().Trim() == name.ToLower().Trim());
            return valor;
        }

        public Pelicula GetPelicula(int peliculaId)
        {
            return _bd.Pelicula.FirstOrDefault(c => c.Id == peliculaId);
        }

        public ICollection<Pelicula> GetPeliculas()
        {
            return _bd.Pelicula.OrderBy(c => c.Nombre).ToList();
        }

        public ICollection<Pelicula> GetPeliculasEnCategoria(int categoriaId)
        {
            return _bd.Pelicula.Include(ca => ca.categoria).Where(ca => ca.categoriaId == categoriaId).ToList();
        }

        public IEnumerable<Pelicula> BuscarPelicula(string nombre)
        {
            IQueryable<Pelicula> query = _bd.Pelicula;
            //string.IsNullOrEmpty(nombre) devuelve true si es esta vacio
            if (!string.IsNullOrEmpty(nombre))
            {
                query.Where(e => e.Nombre.Contains(nombre) || e.Descripcion.Contains(nombre));
            }
            return query.ToList();
        }

        public bool Guardar()
        {
            return _bd.SaveChanges() >= 0 ? true : false;
        }

    }
}
