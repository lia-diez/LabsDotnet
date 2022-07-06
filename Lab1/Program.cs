using System.ComponentModel.Design;
using System.Threading.Tasks.Dataflow;
using Lab1;

#region DataInserting

var planes = new List<Plane>
{
    new()
    {
        Id = 1,
        Type = "Passenger",
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
        FlightRange = 2500,
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
    }
};

var helicopters = new List<Helicopter>
{
    new()
    {
        Id = 1,
        Type = "Passenger",
        FlightRange = 4000,
        LoadCapacity = 15,
        CompanyId = new[] { 1, 2 },
        FlightHeight = 3000
    },
    new()
    {
        Id = 5,
        Type = "Passenger",
        FlightRange = 2000,
        LoadCapacity = 20,
        CompanyId = new[] { 2, 3 },
        FlightHeight = 4000
    },
    new()
    {
        Id = 2,
        Type = "Cargo",
        FlightRange = 1000,
        LoadCapacity = 200,
        CompanyId = new[] { 1, 3 },
        FlightHeight = 3500
    },
    new()
    {
        Id = 3,
        Type = "Passenger",
        FlightRange = 7000,
        LoadCapacity = 12,
        CompanyId = new[] { 1, 2 },
        FlightHeight = 3200
    },
    new()
    {
        Id = 4,
        Type = "Cargo",
        FlightRange = 10000,
        LoadCapacity = 100,
        CompanyId = new[] { 1, 3 },
        FlightHeight = 7000
    },
};

var companies = new List<Company>
{
    new()
    {
        CompanyId = 1,
        Name = "KPI Airlines",
        CreationDate = new DateOnly(2012, 9, 1),
        OfficeAddress = "Kyiv, 37 Peremohy Ave."
    },
    new()
    {
        CompanyId = 2,
        Name = "Key Airlines",
        CreationDate = new DateOnly(1989, 4, 12),
        OfficeAddress = "Kyiv, 1 Tupolev Str."
    },
    new()
    {
        CompanyId = 3,
        Name = "Ukraine International Airlines",
        CreationDate = new DateOnly(1992, 10, 1),
        OfficeAddress = "Kyiv, 111 Sobornyy Ave."
    }
};

#endregion

Console.WriteLine("\n1.Company Names:");
var query1 = from c in companies select c.Name;
foreach (var name in query1) Console.WriteLine($"\t{name}");

Console.WriteLine("\n2.Planes sorted by flight range:");
var query2 = planes
    .OrderByDescending(p => p.FlightRange)
    .Select(p => $"id:{p.Id} range:{p.FlightRange}");
foreach (var planeRange in query2) Console.WriteLine($"\t{planeRange}");

Console.WriteLine("\n3.Company names starting with \"K\":");
var query3 =
    (from c in companies
    where c.Name.StartsWith('K')
    select c.Name).ToArray();
foreach (var name in query3) Console.WriteLine($"\t{name}");

Console.WriteLine("\n4.Companies that were created after 1990:");
var query4 = companies
    .Where(c => c.CreationDate >= new DateOnly(1990, 12, 31))
    .Select(c => c.Name).ToArray();
foreach (var name in query4) Console.WriteLine($"\t{name}");

Console.WriteLine("\n5.Created after 1990 and starts with \"K\":");
var query5 = query3.Intersect(query4);
foreach (var name in query5) Console.WriteLine($"\t{name}");

Console.WriteLine("\n6.Planes with wingspan > 70 or run range > 90 using union:");
var query6 = planes
    .Where(p => p.WingSpan > 70)
    .Union(planes.Where(p => p.RunRange > 90)).ToArray();
foreach (var plane in query6) Console.WriteLine($"\t{plane}");

Console.WriteLine("\n7.Company:helicopter pairs ordered by company ID, many to many join");
var query7 = helicopters
    .SelectMany(helicopter => helicopter.CompanyId
        .Select(cid => (helicopter, company: companies
            .First(c => c.CompanyId == cid))))
    .OrderBy(a => a.company.CompanyId).ToArray();
foreach (var ch in query7) Console.WriteLine($"\t{ch.company.Name}: {ch.helicopter}");

Console.WriteLine("\n8.Helicopters with flight range > 10 ordered by flight range descending and flight height");
var query8 = 
    from h in helicopters
    where h.FlightHeight > 10
    orderby h.FlightRange descending, h.FlightHeight
    select h;
foreach (var h in query8) Console.WriteLine($"\t{h}");

Console.WriteLine("\n9.Planes IDs grouped by type");
var query9 = planes
        .GroupBy(p => p.Type)
        .Select(a => $"{a.Key}: {string.Join(", ", a.Select(b => b.Id))}");
foreach (var h in query9) Console.WriteLine($"\t{h}");

Console.WriteLine("\n10.Average load capacity of helicopters and planes");
var query10 = planes
    .Select(p => p.LoadCapacity)
    .Concat(helicopters.Select(h => h.LoadCapacity))
    .Average();
Console.WriteLine($"\t{query10}");

Console.WriteLine("\n11.Planes with flight range from 2000 to 4000 using skip while and take while");
var query11 = planes
    .OrderBy(p => p.FlightRange)
    .SkipWhile(p => p.FlightRange < 2000)
    .TakeWhile(p => p.FlightRange <= 4000);
foreach (var h in query11) Console.WriteLine($"\t{h}");

Console.WriteLine("\n12.Decart multiplication where plane load capacity > 1000");
var query12 =
    from p in planes
    from h in helicopters
    where p.LoadCapacity > 1000
    select new { plane = p, helicopter = h };
foreach (var h in query12) Console.WriteLine($"\t{h}");

Console.WriteLine("\n13.Planes with companies using where");
var query13 =
    from p in planes
    from c in companies
    where p.CompanyId == c.CompanyId
    select new {c.Name, p.Type, p.LoadCapacity};
foreach (var h in query13) Console.WriteLine($"\t{h}");

Console.WriteLine("\n14.Passenger-only companies");
var query14 = companies.Except((
    from p in planes
    join c in companies on p.CompanyId equals c.CompanyId
    where p.Type == "Cargo"
    select c)
    .ToList());
foreach (var h in query14) Console.WriteLine($"\t{h}");

Console.WriteLine("\n15.Planes and helicopters ordered by flight range");
var query15 =
    from t in
        (from p in planes
            select new { transport = "Plane", id = p.Id, Range = p.FlightRange })
        .Union
        (from h in helicopters
            select new { transport = "Helicopter", id = h.Id, Range = h.FlightRange })
    orderby t.Range
    select t;
foreach (var h in query15) Console.WriteLine($"\t{h}");