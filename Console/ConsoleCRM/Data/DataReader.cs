

using System.Text.Json;

public class DataReader
{
    private readonly string _filePath;

    public DataReader(string filePath)
    {
        _filePath = filePath;
    }

    //Get all records from the file
    public List<T> ReadData<T>() where T : class
    {
        // Check if the file exists
        if (!File.Exists(_filePath))
        {
            Console.WriteLine("No data found.");
            return new List<T>();
        }

        // Read the entire JSON file content
        string jsonContent = File.ReadAllText(_filePath);

        List<T> data;

        try
        {
            // Attempt to deserialize as a list of objects
            data = JsonSerializer.Deserialize<List<T>>(jsonContent) ?? new List<T>();

            // If deserialization as a list fails, try deserializing as a single object
            if (data == null)
            {
                var singleObject = JsonSerializer.Deserialize<T>(jsonContent);
                data = singleObject != null ? new List<T> { singleObject } : new List<T>();
            }
        }
        catch (JsonException)
        {
            Console.WriteLine("The JSON file is not in a valid format.");
            return new List<T>();
        }

        // Return the deserialized data
        return data;
    }
    //Save a record in the file
  
  public void SaveData<T>(List<T> data) where T : class
{
    if (data == null || data.Count == 0)
    {
        Console.WriteLine("Data cannot be null or empty.");
        return;
    }

    // Serialize back to JSON array
    var options = new JsonSerializerOptions { WriteIndented = true };
    string updatedJson = JsonSerializer.Serialize(data, options);
    File.WriteAllText(_filePath, updatedJson);
}
}