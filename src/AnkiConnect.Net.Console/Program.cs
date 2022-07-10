using System.Text.Json;
using AnkiConnect.Net.Models;

var foo = new ChangeDeckParams
{
    Cards = new[] {1502098034045ul, 1502098034048ul, 1502298033753ul},
    Deck = "Japanese::JLPT N3"
};

var bar = JsonSerializer.Serialize(foo);

Console.WriteLine(bar);
