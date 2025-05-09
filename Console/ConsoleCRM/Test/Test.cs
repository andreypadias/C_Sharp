/*
public void SaveData<T>(List<T> data) where T : class
{
    if (data == null || data.Count == 0)
    {
        Console.WriteLine("Data cannot be null or empty.");
        return;
    }

    List<T> existingData;

    // Check if the file exists and is not empty
    if (!File.Exists(_filePath) || new FileInfo(_filePath).Length == 0)
    {
        // File doesn't exist or is empty — start a new list
        existingData = new List<T>();
    }
    else
    {
        string jsonContent = File.ReadAllText(_filePath);

        // Attempt to deserialize existing content to a list
        try
        {
            existingData = JsonSerializer.Deserialize<List<T>>(jsonContent) ?? new List<T>();
        }
        catch
        {
            Console.WriteLine("Failed to read existing data. Starting with an empty list.");
            existingData = new List<T>();
        }
    }

    // Add only new items to the existing data
    foreach (var item in data)
    {
        if (!existingData.Contains(item))
        {
            existingData.Add(item);
        }
    }

    // Serialize back to JSON array
    var options = new JsonSerializerOptions { WriteIndented = true };
    string updatedJson = JsonSerializer.Serialize(existingData, options);
    File.WriteAllText(_filePath, updatedJson);
}
*/