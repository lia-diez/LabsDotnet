namespace Lab1;

public class Company
{
    public int CompanyId { get; set; }
    public string Name { get; set; }
    public string OfficeAddress { get; set; }
    public DateOnly CreationDate { get; set; }

    public override string ToString()
    {
        return $"{CompanyId}, {Name}, {OfficeAddress}, {CreationDate}";
    }
}