namespace Lab2;

public class Helicopter
{
    public Helicopter(int id, string? type, int loadCapacity, int flightRange, int flightHeight, int companyId)
    {
        Id = id;
        Type = type;
        LoadCapacity = loadCapacity;
        FlightRange = flightRange;
        FlightHeight = flightHeight;
        CompanyId = companyId;
    }

    public Helicopter()
    {
    }

    public int Id { get; set; }
    public string? Type { get; set; }
    public int LoadCapacity { get; set; }
    public int FlightHeight { get; set; }
    public int FlightRange { get; set; }
    public int CompanyId { get; set; }

    public override string ToString()
    {
        return $"Id: {Id}, " +
               $"Type: {Type}, " +
               $"Load capacity: {LoadCapacity}, "+
               $"Flight height: {FlightHeight}, " +
               $"Flight range: {FlightRange}, " +
               $"Company Id: {CompanyId}";
    }
}

