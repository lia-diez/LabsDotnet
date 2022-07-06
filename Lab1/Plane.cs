namespace Lab1;

public class Plane
{
    public int Id { get; set; }
    public string? Type { get; set; }
    public int LoadCapacity { get; set; }
    public int FlightRange { get; set; }
    public int WingSpan { get; set; }
    public int RunRange { get; set; }
    public int CompanyId { get; set; }

    public override bool Equals(object? obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return Id;
    }

    public override string ToString()
    {
        return $"Id: {Id}, " +
               $"Type: {Type}, " +
               $"Load capacity: {LoadCapacity}, "+
               $"Flight range: {FlightRange}, " +
               $"Wingspan: {WingSpan}, " +
               $"Run range: {RunRange}, " +
               $"Company Id: {CompanyId}";
    }
}