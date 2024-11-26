using System.ComponentModel.DataAnnotations;

namespace Application.UseCases.Parcours.DTOs;

public class DtoInputParcours
{
    [Required]
    public string Nom { get; set; }
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Walk time must be at least 1 minute.")]
    public int TempsMarcheMinutes { get; set; }
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Run time must be at least 1 minute.")]
    public int TempsCourseMinutes { get; set; }
}