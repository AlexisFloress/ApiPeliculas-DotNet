using ApiPeliculas.Models.DTO;
using ApiPeliculas.Repositorio.IRepositorio;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace ApiPeliculas.Controllers
{
    // [Route("api/[controller]")] opcion estatica
    [Route("api/Categorias")] //opcion dinamica
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaRepoitorio _ctRepo;
        private readonly IMapper _mapper;
        public CategoriasController(ICategoriaRepoitorio ctRepo, IMapper mapper)
        {
            _ctRepo = ctRepo;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult GetCategorias()
        {
            var listaCategoria = _ctRepo.GetCategorias();
            var listaCategoriasDto = new List<CategoriaDto>();

            foreach (var lista in listaCategoria){

                listaCategoriasDto.Add(_mapper.Map<CategoriaDto>(lista));
            }
            return Ok(listaCategoriasDto); 
        }

        [HttpGet]
        [HttpGet("{categoriaId:int}", Name ="GetCategoria")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetCategoria(int categoriaId)
        {
            var itemCategoria = _ctRepo.GetCategoria(categoriaId);

            if(itemCategoria == null)
            {
                return NotFound();
            }

            //Map recibe como como tipo el DTO y el parametro es el modelo que sera mapeado
            var itemCategoriaDto = _mapper.Map<CategoriaDto>(itemCategoria);

            return Ok(itemCategoriaDto);
        }
    }
}
