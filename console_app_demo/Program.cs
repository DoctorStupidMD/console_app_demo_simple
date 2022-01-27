using Newtonsoft.Json;
using System.Xml;
using System.Xml.Linq;

Console.WriteLine("Please input the absolute path to your XML file so I can automagically convert it:");
string filePath = @"" + Console.ReadLine();

XmlDocument importXmlDoc = new XmlDocument();
try
{
    importXmlDoc.Load(filePath);
    Console.WriteLine("I found your XML file! Beep boop...");
}
catch (System.IO.FileNotFoundException)
{
    Console.WriteLine("XML file not found at this location, bummer!");
}

string baseDir = AppDomain.CurrentDomain.BaseDirectory;
string jsonFilePath = System.IO.Path.Combine(baseDir, $@"..\..\..\..\console_app_demo\files\RightslineSampleFromXml.json");
string jsonFormattedText = JsonConvert.SerializeXmlNode(importXmlDoc, Newtonsoft.Json.Formatting.Indented);
File.WriteAllText(jsonFilePath, jsonFormattedText);

string textExtractedFromJson = System.IO.File.ReadAllText(jsonFilePath);
string xmlFilePath = System.IO.Path.Combine(baseDir, $@"..\..\..\..\console_app_demo\files\RightslineSampleFromJson.xml");
XNode xmlDeserializedText = JsonConvert.DeserializeXNode(textExtractedFromJson, "Root");
File.WriteAllText(xmlFilePath, xmlDeserializedText.ToString());

Console.WriteLine("Conversion process is complete! Please navigate to the files folder to view your new JSON and XML files.");
Console.WriteLine("Have a lovely day!");