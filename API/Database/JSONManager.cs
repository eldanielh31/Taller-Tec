using System.Text.Json;

namespace API.Database;

public class JSONManager
{
    public static void AddToJSON<T>(T newObj, string fileName)
    {
        var options = new JsonSerializerOptions()
        { 
            WriteIndented = true
        };

        T[] list = ReadJSON<T[]>(fileName);
        T[] newList = list.Append<T>(newObj).ToArray();
        var jsonString = JsonSerializer.Serialize(newList, options);
        File.WriteAllText(fileName, jsonString);
    }

    public static void OverrideJSON<T>(T[] list, string fileName)
    {
        string updatedJSON = JsonSerializer.Serialize<T[]>(list);
        File.WriteAllText(fileName,updatedJSON);
    }
    public static T ReadJSON<T>(string fileName)
    {
        string readFile = File.ReadAllText(fileName);
        T jsonObj = JsonSerializer.Deserialize<T>(readFile);
        return jsonObj;
    }
}