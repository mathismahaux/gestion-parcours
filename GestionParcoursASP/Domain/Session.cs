using System.Text.Json.Serialization;

namespace Domain;

public class Session
{
    public int Id { get; set; }
    public int PersonneId { get; set; }
    
    public int ParcoursId { get; set; }
    public string Type { get; set; }
    public int TempsMinutes { get; set; }
}