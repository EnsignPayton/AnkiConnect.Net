using AnkiConnect.Net;
using AnkiConnect.Net.Models;

var client = new AnkiClient(new HttpClient());

var t1 = await client.GetEaseFactorsAsync(new CardsParams
{
    Cards = new[] {0ul, 1ul, 2ul}
});

var t2 = await client.GetEaseFactorsAsync(new CardsParams(0ul, 1ul, 2ul));

var t3 = await client.CreateDeckAsync("deck");

var t4 = await client.FindCardsAsync("query");

var t5 = await client.SuspendedAsync(0ul);
