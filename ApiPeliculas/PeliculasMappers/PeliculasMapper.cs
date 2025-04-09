using ApiPeliculas.Models;
using ApiPeliculas.Models.DTO;
using AutoMapper;

namespace ApiPeliculas.PeliculasMapper
{
    public class PeliculasMapper : Profile
    {
        public PeliculasMapper()
        {
            CreateMap<Categoria, CategoriaDto>().ReverseMap();
            CreateMap<Categoria, CrearCategoriaDTO>().ReverseMap();

        }
    }
}
