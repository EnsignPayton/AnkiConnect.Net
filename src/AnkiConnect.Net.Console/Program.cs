using AnkiConnect.Net;
using AnkiConnect.Net.Models;

try
{
    var client = new HttpClient();
    IAnkiClient ankiClient = new AnkiClient(client);

    var result = await ankiClient.DeckNamesAsync();

    Console.Read();
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}
