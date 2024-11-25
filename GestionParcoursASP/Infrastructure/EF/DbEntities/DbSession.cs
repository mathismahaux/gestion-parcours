using System.Text.Json.Serialization;

namespace Infrastructure.EF.DbEntities;

public class DbSession
{
    public int Id { get; set; }
    public int PersonneId { get; set; }
    public int ParcoursId { get; set; }
    public string Type { get; set; }
    public int TempsMinutes { get; set; }
}