using System.Data.Common;

namespace Lab2;

public class Plane
{
    public Plane(int id, string? type, int loadCapacity, int flightRange, int wingSpan, int runRange, int companyId)
    {
        Id = id;
        Type = type;
        LoadCapacity = loadCapacity;
        FlightRange = flightRange;
        WingSpan = wingSpan;
        RunRange = runRange;
        CompanyId = companyId;
    }

    public Plane()
    {
    }

    public int Id { get; set; }
    public string? Type { get; set; }
    public int LoadCapacity { get; set; }
    public int FlightRange { get; set; }
    public int WingSpan { get; set; }
    public int RunRange { get; set; }
    public int CompanyId { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj.GetType() != GetType()) return false;
        var plane2 = (Plane)obj;
        return Id == plane2.Id && Type == plane2.Type && LoadCapacity == plane2.LoadCapacity &&
               FlightRange == plane2.FlightRange && WingSpan == plane2.WingSpan && RunRange == plane2.RunRange &&
               CompanyId == plane2.CompanyId;
    }

    public override int GetHashCode()
    {
        return Id;
    }

    public override string ToString()
    {
        return $"Id: {Id}, " +
               $"Type: {Type}, " +
               $"Load capacity: {LoadCapacity}, " +
               $"Flight range: {FlightRange}, " +
               $"Wingspan: {WingSpan}, " +
               $"Run range: {RunRange}, " +
               $"Company Id: {CompanyId}";
    }
}