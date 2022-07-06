using System.Xml;
using System.Xml.Linq;
using Lab2;


#region DataInserting

var planesXml = new List<Plane>
{
    new()
    {
        Id = 1,
        Type = "Combat",
        FlightRange = 2000,
        LoadCapacity = 200,
        CompanyId = 1,
        RunRange = 100,
        WingSpan = 50
    },
    new()
    {
        Id = 2,
        Type = "Passenger",
        FlightRange = 5000,
        LoadCapacity = 150,
        CompanyId = 2,
        RunRange = 150,
        WingSpan = 70
    },
    new()
    {
        Id = 3,
        Type = "Cargo",
        FlightRange = 2000,
        LoadCapacity = 3000,
        CompanyId = 3,
        RunRange = 10,
        WingSpan = 78
    },
    new()
    {
        Id = 4,
        Type = "Cargo",
        FlightRange = 3000,
        LoadCapacity = 20000,
        CompanyId = 1,
        RunRange = 50,
        WingSpan = 65
    },
    new()
    {
        Id = 5,
        Type = "Passenger",
        FlightRange = 1000,
        LoadCapacity = 20,
        CompanyId = 2,
        RunRange = 10,
        WingSpan = 20
    },
    new()
    {
        Id = 6,
        Type = "Passenger",
        FlightRange = 1000,
        LoadCapacity = 4000,
        CompanyId = 2,
        RunRange = 120,
        WingSpan = 50
    }
};

var helicoptersXml = new List<Helicopter>
{
    new()
    {
        Id = 1,
        Type = "Passenger",
        FlightRange = 4000,
        LoadCapacity = 15,
        CompanyId = 2,
        FlightHeight = 3000
    },
    new()
    {
        Id = 5,
        Type = "Passenger",
        FlightRange = 2000,
        LoadCapacity = 20,
        CompanyId = 2,
        FlightHeight = 4000
    },
    new()
    {
        Id = 2,
        Type = "Cargo",
        FlightRange = 1000,
        LoadCapacity = 200,
        CompanyId = 1,
        FlightHeight = 3500
    },
    new()
    {
        Id = 3,
        Type = "Passenger",
        FlightRange = 7000,
        LoadCapacity = 12,
        CompanyId = 1,
        FlightHeight = 3200
    },
    new()
    {
        Id = 4,
        Type = "Cargo",
        FlightRange = 10000,
        LoadCapacity = 100,
        CompanyId = 3,
        FlightHeight = 7000
    },
};

var companiesXml = new List<Company>
{
    new(companyId: 1, name: "KPI Airlines", creationDate: new DateOnly(2012, 9, 1),
        officeAddress: "Kyiv, 37 Peremohy Ave."),
    new(companyId: 2, name: "Key Airlines", creationDate: new DateOnly(1989, 4, 12),
        officeAddress: "Kyiv, 1 Tupolev Str."),
    new(companyId: 3, name: "Ukraine International Airlines", creationDate: new DateOnly(1992, 10, 1),
        officeAddress: "Kyiv, 111 Sobornyy Ave.")
};

#endregion

var settings = new XmlWriterSettings();
settings.Indent = true;

using (XmlWriter writer = XmlWriter.Create("data.xml", settings))
{
    writer.WriteStartElement("data");
    writer.WriteStartElement("planes");
    foreach (var plane in planesXml)
    {
        writer.WriteStartElement("Plane");
        writer.WriteElementString("Id", plane.Id.ToString());
        writer.WriteElementString("Type", plane.Type);
        writer.WriteElementString("LoadCapacity", plane.LoadCapacity.ToString());
        writer.WriteElementString("FlightRange", plane.FlightRange.ToString());
        writer.WriteElementString("WingSpan", plane.WingSpan.ToString());
        writer.WriteElementString("RunRange", plane.RunRange.ToString());
        writer.WriteElementString("CompanyId", plane.CompanyId.ToString());
        writer.WriteEndElement();
    }

    writer.WriteEndElement();

    writer.WriteStartElement("helicopters");
    foreach (var helicopter in helicoptersXml)
    {
        writer.WriteStartElement("Helicopter");
        writer.WriteElementString("Id", helicopter.Id.ToString());
        writer.WriteElementString("Type", helicopter.Type);
        writer.WriteElementString("LoadCapacity", helicopter.LoadCapacity.ToString());
        writer.WriteElementString("FlightHeight", helicopter.FlightHeight.ToString());
        writer.WriteElementString("FlightRange", helicopter.FlightRange.ToString());
        writer.WriteElementString("CompanyId", helicopter.CompanyId.ToString());
        writer.WriteEndElement();
    }

    writer.WriteEndElement();

    writer.WriteStartElement("companies");
    foreach (var company in companiesXml)
    {
        writer.WriteStartElement("Company");
        writer.WriteElementString("CompanyId", company.CompanyId.ToString());
        writer.WriteElementString("Name", company.Name);
        writer.WriteElementString("OfficeAdress", company.OfficeAddress);
        writer.WriteElementString("CreationDate", company.CreationDate.ToString());
        writer.WriteEndElement();
    }

    writer.WriteEndElement();
    writer.WriteEndElement();
}

var planes = XDocument.Load("data.xml").Descendants("Plane");
var helicopters = XDocument.Load("data.xml").Descendants("Helicopter");
var companies = XDocument.Load("data.xml").Descendants("Company");

Console.WriteLine("Planes:");
Console.WriteLine(
    $"\t{string.Join("\n\t", planes.Select(a => new Plane(int.Parse(a.Element("Id").Value), a.Element("Type").Value.ToString(), int.Parse(a.Element("LoadCapacity").Value), int.Parse(a.Element("FlightRange").Value), int.Parse(a.Element("WingSpan").Value), int.Parse(a.Element("RunRange").Value), int.Parse(a.Element("CompanyId").Value))))}");

Console.WriteLine("\nHelicopters:");
Console.WriteLine(
    $"\t{string.Join("\n\t", helicopters.Select(h => new Helicopter(int.Parse(h.Element("Id").Value), h.Element("Type").Value.ToString(), int.Parse(h.Element("LoadCapacity").Value), int.Parse(h.Element("FlightRange").Value), int.Parse(h.Element("FlightHeight").Value), int.Parse(h.Element("CompanyId").Value))))}");

Console.WriteLine("\nCompanies:");
Console.WriteLine(
    $"\t{string.Join("\n\t", companies.Select(c => new Company(int.Parse(c.Element("CompanyId").Value), c.Element("Name").Value.ToString(), DateOnly.Parse(c.Element("CreationDate").Value), c.Element("OfficeAdress").Value.ToString())))}");

Console.WriteLine("\n---------------- Queries ----------------\n");
Console.WriteLine("\n1.Distinct planes and helicopters types");
var query1 = planes
    .Select(a => a.Element("Type").Value)
    .Union(helicopters
        .Select(a => a.Element("Type").Value))
    .Distinct();
foreach (var str in query1)
    Console.WriteLine($"\t{str}");
Console.WriteLine("\n2.Planes with wing span bigger than 60");
var query2 = planes
    .Select(a => new Plane(
        int.Parse(a.Element("Id").Value),
        a.Element("Type").Value.ToString(),
        int.Parse(a.Element("LoadCapacity").Value),
        int.Parse(a.Element("FlightRange").Value),
        int.Parse(a.Element("WingSpan").Value),
        int.Parse(a.Element("RunRange").Value),
        int.Parse(a.Element("CompanyId").Value)))
    .Where(p => p.WingSpan > 60);
foreach (var str in query2)
    Console.WriteLine($"\t{str}");

Console.WriteLine("\n3.Companies with planes and helicopters");
var query3 =
    (from c in companies
        join p in planes on
            int.Parse(c.Element("CompanyId").Value) equals
            int.Parse(p.Element("CompanyId").Value)
        select new
        {
            transport = p.Name.ToString(),
            id = int.Parse(p.Element("Id").Value),
            type = p.Element("Type").Value.ToString(),
            company = c.Element("Name").Value
        })
    .Union(
        from c in companies
        join h in helicopters on
            int.Parse(c.Element("CompanyId").Value) equals
            int.Parse(h.Element("CompanyId").Value)
        select new
        {
            transport = h.Name.ToString(),
            id = int.Parse(h.Element("Id").Value),
            type = h.Element("Type").Value.ToString(),
            company = c.Element("Name").Value
        }).OrderBy(a => a.company);
foreach (var str in query3)
    Console.WriteLine($"\t{str}");

Console.WriteLine("\n4.Combat companies");
var query4 = (
    from c in companies
    join p in planes on
        int.Parse(c.Element("CompanyId").Value) equals
        int.Parse(p.Element("CompanyId").Value)
    join h in helicopters on
        int.Parse(c.Element("CompanyId").Value) equals
        int.Parse(h.Element("CompanyId").Value)
    where p.Element("Type").Value == "Combat"
          || h.Element("Type").Value == "Combat"
    select new
    {
        id = int.Parse(c.Element("CompanyId").Value),
        name = c.Element("Name").ToString()
    }).Distinct();
foreach (var str in query4)
    Console.WriteLine($"\t{str}");

Console.WriteLine("\n5.Companies sorted by creation date");
var query5 = companies
    .Select(c => new Company(
        int.Parse(c.Element("CompanyId").Value),
        c.Element("Name").Value.ToString(),
        DateOnly.Parse(c.Element("CreationDate").Value),
        c.Element("OfficeAdress").Value.ToString()))
    .OrderBy(c => c.CreationDate);
foreach (var str in query5)
    Console.WriteLine($"\t{str}");

Console.WriteLine("\n6.Helicopters grouped by company");
var query6 = helicopters
    .Select(h => new Helicopter(
        int.Parse(h.Element("Id").Value),
        h.Element("Type").Value.ToString(),
        int.Parse(h.Element("LoadCapacity").Value),
        int.Parse(h.Element("FlightRange").Value),
        int.Parse(h.Element("FlightHeight").Value),
        int.Parse(h.Element("CompanyId").Value)))
    .GroupBy(h => h.CompanyId)
    .Select(g => $"{g.Key}: \n\t\t{string.Join("\n\t\t", g)}");
foreach (var str in query6)
    Console.WriteLine($"\t{str}");

Console.WriteLine("\n7.Amount of transport own by company");
var query7 = companies
    .Select(c => $"{c.Element("Name").Value.ToString()}:" +
                 $"\n\t\tPlanes: {planes.Count(p => int.Parse(p.Element("CompanyId").Value) == int.Parse(c.Element("CompanyId").Value))}" +
                 $"\n\t\tHelicopters: {helicopters.Count(h => int.Parse(h.Element("CompanyId").Value) == int.Parse(c.Element("CompanyId").Value))}");
foreach (var str in query7)
    Console.WriteLine($"\t{str}");

Console.WriteLine("\n8.Average wing span of planes");
var query8 = planes
    .Select(a => int.Parse(a.Element("WingSpan").Value))
    .Average();
Console.WriteLine($"\t{query8}");

Console.WriteLine("\n9.Planes with run range less than 100 ordered by flight range descending");
var query9 = planes
    .Select(p => new Plane(
        int.Parse(p.Element("Id").Value),
        p.Element("Type").Value.ToString(),
        int.Parse(p.Element("LoadCapacity").Value),
        int.Parse(p.Element("FlightRange").Value),
        int.Parse(p.Element("WingSpan").Value),
        int.Parse(p.Element("RunRange").Value),
        int.Parse(p.Element("CompanyId").Value)))
    .OrderBy(p => p.RunRange)
    .TakeWhile(p => p.RunRange < 100)
    .OrderByDescending(p => p.FlightRange).ToArray();
foreach (var str in query9)
    Console.WriteLine($"\t{str}");

Console.WriteLine("\n10.Planes with helicopters ordered by load capacity descending");
var query10 = planes
    .Select(p => new
    {
        transport = "plane",
        id = int.Parse(p.Element("Id").Value),
        type = p.Element("Type").Value.ToString(),
        capacity = int.Parse(p.Element("LoadCapacity").Value),
        company = int.Parse(p.Element("CompanyId").Value)
    })
    .Union(
        helicopters.Select(h => new
        {
            transport = "helicopter",
            id = int.Parse(h.Element("Id").Value),
            type = h.Element("Type").Value.ToString(),
            capacity = int.Parse(h.Element("LoadCapacity").Value),
            company = int.Parse(h.Element("CompanyId").Value)
        }))
    .OrderByDescending(t => t.capacity);
foreach (var str in query10)
    Console.WriteLine($"\t{str}");

Console.WriteLine("\n11.Planes with load capacity bigger than average transport's");
var query11 = planes
    .Select(p => new Plane(
        int.Parse(p.Element("Id").Value),
        p.Element("Type").Value.ToString(),
        int.Parse(p.Element("LoadCapacity").Value),
        int.Parse(p.Element("FlightRange").Value),
        int.Parse(p.Element("WingSpan").Value),
        int.Parse(p.Element("RunRange").Value),
        int.Parse(p.Element("CompanyId").Value)))
    .Where(p => p.LoadCapacity > query10.Average(a => a.capacity)).ToArray();
foreach (var str in query11)
    Console.WriteLine($"\t{str}");

Console.WriteLine("\n12.Planes with load capacity bigger than average and run range less than 100");
var query12 = planes
    .Select(p => new
    {
        id = int.Parse(p.Element("Id").Value),
        type = p.Element("Type").Value.ToString(),
        capacity = int.Parse(p.Element("LoadCapacity").Value),
        run = int.Parse(p.Element("RunRange").Value)
    })
    .Where(p => p.capacity > query10.Average(a => a.capacity)).ToArray()
    .Intersect(planes
            .Select(p => new
            {
                id = int.Parse(p.Element("Id").Value),
                type = p.Element("Type").Value.ToString(),
                capacity = int.Parse(p.Element("LoadCapacity").Value),
                run = int.Parse(p.Element("RunRange").Value)
            })
            .OrderBy(p => p.run)
            .TakeWhile(p => p.run < 100));
foreach (var str in query12)
    Console.WriteLine($"\t{str}");

Console.WriteLine("\n13.Companies sorted by the amount of transport");
var query13 = companies
    .Select(c => new
    {
        id = int.Parse(c.Element("CompanyId").Value),
        name = c.Element("Name").Value.ToString(),
        address = c.Element("OfficeAdress").Value.ToString(),
        count =
            planes.Count(p => int.Parse(c.Element("CompanyId").Value) == int.Parse(p.Element("CompanyId").Value)) +
            helicopters.Count(h => int.Parse(c.Element("CompanyId").Value) == int.Parse(h.Element("CompanyId").Value))
    })
    .OrderBy(c => c.count);
foreach (var str in query13)
    Console.WriteLine($"\t{str}");

Console.WriteLine("\n14.Top 5 plane and helicopter pairs with load capacity closest to 300 and flight range bigger than 1000");
var query14 =
    (from p in planes
            .Select(p => new
            {
                id = int.Parse(p.Element("Id").Value),
                type = p.Element("Type").Value.ToString(),
                capacity = int.Parse(p.Element("LoadCapacity").Value),
                range = int.Parse(p.Element("FlightRange").Value)
            })
        from h in helicopters
            .Select(h => new
            {
                id = int.Parse(h.Element("Id").Value),
                type = h.Element("Type").Value.ToString(),
                capacity = int.Parse(h.Element("LoadCapacity").Value),
                range = int.Parse(h.Element("FlightRange").Value)
            })
        where (p.range >= 1000 && h.range >= 1000) && (p.capacity + h.capacity >= 300)
        select new { plane = p, helicopter = h })
    .OrderBy(t => (t.helicopter.capacity + t.plane.capacity) - 300).Take(5);
    
foreach (var str in query14)
    Console.WriteLine($"\t{str}");
    
Console.WriteLine("\n15.Planes ordered by flight range and run range");
var query15 = planes
            .Select(p => new
            {
                id = int.Parse(p.Element("Id").Value),
                type = p.Element("Type").Value.ToString(),
                range = int.Parse(p.Element("FlightRange").Value),
                run = int.Parse(p.Element("RunRange").Value)
            })
            .OrderBy(p => (p.range, p.run));
    
foreach (var str in query15)
    Console.WriteLine($"\t{str}");