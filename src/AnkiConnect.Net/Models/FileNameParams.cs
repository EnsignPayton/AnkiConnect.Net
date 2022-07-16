namespace AnkiConnect.Net.Models;

public class FileNameParams
{
    public FileNameParams()
    {
    }

    public FileNameParams(string fileName)
    {
        FileName = fileName;
    }

    public static implicit operator FileNameParams(string fileName) => new(fileName);

    [JsonPropertyName("filename")]
    public string FileName { get; set; } = string.Empty;
}
