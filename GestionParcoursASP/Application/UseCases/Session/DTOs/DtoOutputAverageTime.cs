namespace Application.UseCases.Session.DTOs;

public class DtoOutputAverageTime
{
    public int ParcoursId { get; set; }
    public string Type { get; set; }
    public double AverageTime { get; set; }
    public int StandardTime { get; set; }
    public bool IsBetterThanStandard { get; set; }
}