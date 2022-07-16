namespace AnkiConnect.Net;

public interface IAnkiClient :
    IAnkiCards,
    IAnkiDecks,
    IAnkiGui,
    IAnkiMedia,
    IAnkiMisc,
    IAnkiModels,
    IAnkiNotes,
    IAnkiStats
{
}
