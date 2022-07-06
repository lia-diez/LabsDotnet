namespace Lab1;

public class Helicopter
{
    public int Id { get; set; }
    public string? Type { get; set; }
    public int LoadCapacity { get; set; }
    public int FlightHeight { get; set; }
    public int FlightRange { get; set; }
    public int[] CompanyId { get; set; }
    
    public override string ToString()
    {
        return $"Id: {Id}, " +
               $"Type: {Type}, " +
               $"Load capacity: {LoadCapacity}, "+
               $"Flight range: {FlightRange}, " +
               $"Flight height: {FlightHeight}, " +
               $"Company IDs: [{string.Join(", ", CompanyId)}]";
    }
}