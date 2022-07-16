using System.Text.Json;
using AnkiConnect.Net.Models;

namespace AnkiConnect.Net.Internal;

public class StoreMediaFileParamsConverter : JsonConverter<StoreMediaFileParams>
{
    public override StoreMediaFileParams? Read(ref Utf8JsonReader reader, Type typeToConvert,
        JsonSerializerOptions options) =>
        JsonSerializer.Deserialize<StoreMediaFileParams>(ref reader, options);

    public override void Write(Utf8JsonWriter writer, StoreMediaFileParams value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        writer.WriteString("filename", value.FileName);
        if (!string.IsNullOrEmpty(value.Data))
            writer.WriteString("data", value.Data);
        if (!string.IsNullOrEmpty(value.Path))
            writer.WriteString("path", value.Path);
        if (!string.IsNullOrEmpty(value.Url))
            writer.WriteString("url", value.Url);
        if (!value.DeleteExisting)
            writer.WriteBoolean("deleteExisting", value.DeleteExisting);

        writer.WriteEndObject();
    }
}
