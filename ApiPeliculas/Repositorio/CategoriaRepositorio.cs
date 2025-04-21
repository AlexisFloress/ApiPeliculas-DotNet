using ApiPeliculas.Data;
using ApiPeliculas.Models;
using ApiPeliculas.Repositorio.IRepositorio;

namespace ApiPeliculas.Repositorio
{
    public class CategoriaRepositorio : ICategoriaRepoitorio
    {
        private readonly ApplicationDbContext _bd;
        public CategoriaRepositorio(ApplicationDbContext bd)
        {
            _bd = bd;
        }

        public bool ActualizarCategoria(Categoria categoria)
        {
            categoria.fechaCreacion = DateTime.Now;

            //fix put problem
            var categoriaExistente = _bd.Categorias.Find(categoria.Id);
            if (categoriaExistente != null)
            {
                _bd.Categorias.Entry(categoriaExistente).CurrentValues.SetValues(categoria);
            }
            else
            {
                _bd.Categorias.Update(categoria);
            }

            return Guardar();
        }

        public bool BorrarCategoria(Categoria categoria)
        {
            _bd.Categorias.Remove(categoria);
            return Guardar();
        }

        public bool CrearCategoria(Categoria categoria)
        {
            categoria.fechaCreacion = DateTime.Now;
            _bd.Categorias.Add(categoria);
            return Guardar();
        }

        public bool ExisteCategoria(int categoriaId)
        {
            return _bd.Categorias.Any(c =>  c.Id == categoriaId);
        }

        public bool ExisteCategoria(string name)
        {
            bool valor = _bd.Categorias.Any(c => c.nombre.ToLower().Trim() == name.ToLower().Trim());
            return valor;
        }

        public Categoria GetCategoria(int categoriaId)
        {
            return _bd.Categorias.FirstOrDefault(c => c.Id == categoriaId);
        }

        public ICollection<Categoria> GetCategorias()
        {
            return _bd.Categorias.OrderBy(c => c.nombre).ToList();
        }

        public bool Guardar()
        {
            return _bd.SaveChanges() >= 0 ? true : false;
        }
    }
}
