using lab4.TextManipulation.TextMutators;
using lab4.TextManipulation.TextSources;

string filePath = "result.txt";
string filePath2 = "result2.txt";

if (File.Exists(filePath)) 
    File.WriteAllText(filePath,string.Empty);
TextSource a = new StringTextSource("Hello world!");

a.SaveToFile(filePath)
    .Translate("de")
    .SaveToFile(filePath)
    .Encrypt()
    .SaveToFile(filePath)
    .Decrypt()
    .SaveToFile(filePath)
    .Translate("es")
    .SaveToFile(filePath);

if (File.Exists(filePath2)) 
    File.WriteAllText(filePath2,string.Empty);
FileTextSource b = new FileTextSource("data.txt");

b.SaveToFile(filePath2)
    .Translate("es")
    .SaveToFile(filePath2);