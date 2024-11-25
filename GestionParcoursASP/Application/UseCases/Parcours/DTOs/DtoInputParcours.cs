using System.ComponentModel.DataAnnotations;

namespace Application.UseCases.Parcours.DTOs;

public class DtoInputParcours
{
    [Required]
    public string Nom { get; set; }
    [Range(0, int.MaxValue, ErrorMessage = "Walk time must be positive.")]
    public int TempsMarcheMinutes { get; set; }
    [Range(0, int.MaxValue, ErrorMessage = "Run time must be positive.")]
    public int TempsCourseMinutes { get; set; }
}