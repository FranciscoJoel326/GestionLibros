using System.ComponentModel.DataAnnotations;

namespace GestionLibros.Models;

public class Libros
{
    [Key]
    public int LibroId { get; set; }

    [Required(ErrorMessage = "El título es obligatorio.")]
    public string Titulo { get; set; } = string.Empty;

    [Required(ErrorMessage = "El autor es obligatorio.")]
    public string Autor { get; set; } = string.Empty;

    [Required(ErrorMessage = "El año de publicación es obligatorio.")]
    [Range(1, 2100, ErrorMessage = "Ingrese un año válido.")]
    public int AnoPublicacion { get; set; }
}
