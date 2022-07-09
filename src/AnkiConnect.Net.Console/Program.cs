using AnkiConnect.Net;

try
{
    var client = new HttpClient();
    IAnkiClient ankiClient = new AnkiClient(client);

    var result = await ankiClient.GetNumCardsReviewedByDayAsync();

    Console.Read();
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}
