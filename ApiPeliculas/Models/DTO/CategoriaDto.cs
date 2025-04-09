
using System.ComponentModel.DataAnnotations;

namespace ApiPeliculas.Models.DTO
{
    public class CategoriaDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(100,ErrorMessage ="El numero maximo de caracteres es de 100")]
        public string nombre { get; set; }
        public DateTime fechaCreacion { get; set; }
    }
}
