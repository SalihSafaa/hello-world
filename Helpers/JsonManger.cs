using System.Text.Json;

namespace HelloWorld;
public class JsonManager<T>
{
    private readonly string _filePath;
    private readonly JsonSerializerOptions _options =new (){WriteIndented=true};

    public JsonManager(string fileName="data.json")
    {
        _filePath=Path.Combine(Directory.GetCurrentDirectory(),fileName);
    }
    public void save(T data)
    {
        string jsonString=JsonSerializer.Serialize(data,_options);
        File.WriteAllText(_filePath,jsonString);
    }
    public T load(T fallbackValue)
    {
        string jsonString=string.Empty;
        if(!File.Exists(_filePath))
        {
            return fallbackValue;
        }
        try
        {
            jsonString=File.ReadAllText(_filePath);
        }catch(IOException ex)
        {
            Console.WriteLine($"Something went wrong when reading from the file {_filePath}: {ex.Message}");
        }
        return JsonSerializer.Deserialize<T>(jsonString,_options)?? fallbackValue;
    }
}