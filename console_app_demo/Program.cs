using Newtonsoft.Json;
using System.Xml;
using System.Xml.Linq;

namespace ConsoleAppDemo;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Please input the absolute path to your XML file so I can automagically convert it:");
        string? filePath = Console.ReadLine();

        XmlDocument importXmlDoc = new();

        try
        {
            if (filePath is not null)
            {
                importXmlDoc.Load(filePath);
                Console.WriteLine("I found your XML file! Beep boop...");
            }
        }
        catch (Exception exception)
        {
            if (exception is FileNotFoundException || exception is XmlException || Path.GetExtension(filePath) != ".xml")
            {
                Console.Clear();
                Console.WriteLine("XML file is either corrupted or not found at this location, bummer!");
                Environment.Exit(1);
            }
        }

        XmlToJsonToXmlConversion(importXmlDoc);
        SuccessMessage();
    }

    private static void XmlToJsonToXmlConversion(XmlNode importXmlDoc)
    {
        string baseDir = AppDomain.CurrentDomain.BaseDirectory;
        string jsonFilePath = Path.Combine(baseDir, $@"..\..\..\..\console_app_demo\files\XmlToJsonResult.json");
        string jsonFormattedText = JsonConvert.SerializeXmlNode(importXmlDoc, Newtonsoft.Json.Formatting.Indented);
        File.WriteAllText(jsonFilePath, jsonFormattedText);

        string textExtractedFromJson = File.ReadAllText(jsonFilePath);
        string xmlFilePath = Path.Combine(baseDir, $@"..\..\..\..\console_app_demo\files\JsonToXmlResult.xml");
        XNode? xmlDeserializedText = JsonConvert.DeserializeXNode(textExtractedFromJson, "Root"); 
        if (xmlDeserializedText is not null)
        {
            File.WriteAllText(xmlFilePath, xmlDeserializedText.ToString());
        }
    }

    private static string SuccessMessage()
    {
        Console.Clear();
        Console.WriteLine("Conversion process is complete! Please navigate to the files folder to view your new JSON and XML files.");
        Thread.Sleep((int)SleepyTime.Small);
        Console.WriteLine("Have a lovely day!");
        return string.Empty;
    }

    private enum SleepyTime
    {
        Small = 1000,
        Medium = 2000,
        Large = 3000
    }
}