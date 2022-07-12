using System.Text.Json;
using AnkiConnect.Net;

var client = new AnkiClient(new HttpClient());

var deckConfig = await client.GetDeckConfigAsync("Mining");

PrettyPrint(deckConfig);

void PrettyPrint<T>(T value)
{
    var options = new JsonSerializerOptions {WriteIndented = true};
    var json = JsonSerializer.Serialize(value, options);
    Console.WriteLine(json);
}
