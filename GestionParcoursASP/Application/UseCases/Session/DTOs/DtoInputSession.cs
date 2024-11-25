namespace Application.UseCases.Session.DTOs;

public class DtoInputSession
{
    public int PersonneId { get; set; }
    public int ParcoursId { get; set; }
    public string Type { get; set; }
    public int TempsMinutes { get; set; }
}