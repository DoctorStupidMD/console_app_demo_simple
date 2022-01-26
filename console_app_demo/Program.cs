using Newtonsoft.Json;
using System.Xml;
using System.Xml.Linq;

XmlDocument importXmlDoc = new XmlDocument();

try
{
    importXmlDoc.Load("C:/Users/acm/RightslineSample.xml");
    Console.WriteLine("XML file import succeeded, yay!");
}
catch (System.IO.FileNotFoundException)
{
    Console.WriteLine("XML file import failed, sorry!");
}

string jsonFile = "C:/Users/acm/source/repos/console_app_demo/console_app_demo/files/RightslineSample.json";
string jsonFormattedText = JsonConvert.SerializeXmlNode(importXmlDoc, Newtonsoft.Json.Formatting.Indented);
File.WriteAllText(jsonFile, jsonFormattedText);

Console.WriteLine(File.ReadAllText(jsonFile));

string extractedTextFromJson = System.IO.File.ReadAllText(jsonFile);
string xmlFile = "C:/Users/acm/source/repos/console_app_demo/console_app_demo/files/RightslineSample2.xml";
XNode finalXmlText = JsonConvert.DeserializeXNode(extractedTextFromJson, "Root");
File.WriteAllText(xmlFile, finalXmlText.ToString());

Console.WriteLine(File.ReadAllText(xmlFile));