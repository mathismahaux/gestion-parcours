namespace Infrastructure.EF.DbEntities;

public class DbParcours
{
    public int Id { get; set; }
    public string Nom { get; set; }
    public int TempsMarcheMinutes { get; set; }
    public int TempsCourseMinutes { get; set; }
}