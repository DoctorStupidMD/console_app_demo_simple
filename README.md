# console_app_demo_simple
>A bare-bones C# console app that transforms data between XML and JSON formats.

### Forward: 

Starting with .NET 6, new C# projects using the console template generate different code than 
previous versions. The features that make the new program simpler are top-level statements, 
global using directives, and implicit using directives.

You can learn more here: https://docs.microsoft.com/en-us/dotnet/core/tutorials/top-level-templates

## Overview: 

This is a simple console application written in C#. It imports an XML file, turns it into JSON,
and exports the JSON contents into a new file within the repo. It then takes the new JSON file, turns it
back into XML, then exports the XML contents into a new file within the repo. Very basic error handling included.

## User Instructions:

- Ensure that you have downloaded the [Sample XML File](https://drive.google.com/file/d/1fLx85CuVbMyc7qVrBOLicEo-a-Vdl1LH/view) to your preferred location
and have the absolute path for later use.
- Clone this repository to the location of your choosing.
- Launch the `console_app_demo.sln` file with Visual Studio 2022.
- Run by entering F5, clicking the green start button in the top bar, or navigating to 'Debug' in the 
top menu >> 'Start Debugging'.
- Input the XML file's absolute path when prompted by the console.
- After the application has concluded running, view your two newly-generated files in the Solution Explorer
by expanding the `files` folder: `console_app_demo/files/*`.