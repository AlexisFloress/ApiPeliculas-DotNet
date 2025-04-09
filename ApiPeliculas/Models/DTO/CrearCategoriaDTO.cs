using System.ComponentModel.DataAnnotations;

namespace ApiPeliculas.Models.DTO
{
    public class CrearCategoriaDTO
    {
        
        [Required(ErrorMessage ="EL campo nombre es requerido")]
        [MaxLength(100,ErrorMessage ="El numero maximo de caracteres es de 100")]
        public string nombre { get; set; }
        
    }
}
