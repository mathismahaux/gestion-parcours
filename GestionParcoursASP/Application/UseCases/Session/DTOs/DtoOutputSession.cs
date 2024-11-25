namespace Application.UseCases.Session.DTOs;

public class DtoOutputSession
{
    public int Id { get; set; }
    public int PersonneId { get; set; }
    public int ParcoursId { get; set; }
    public string Type { get; set; }
    public int TempsMinutes { get; set; }
}