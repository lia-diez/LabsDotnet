namespace Lab2;

public class Company
{
    public Company(int companyId, string name, DateOnly creationDate, string officeAddress)
    {
        CompanyId = companyId;
        Name = name;
        CreationDate = creationDate;
        OfficeAddress = officeAddress;
    }

    public int CompanyId { get; set; }
    public string Name { get; set; }
    public string OfficeAddress { get; set; }
    public DateOnly CreationDate { get; set; }

    public override string ToString()
    {
        return $"{CompanyId}, {Name}, {OfficeAddress}, {CreationDate}";
    }
}