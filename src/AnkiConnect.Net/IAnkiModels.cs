namespace AnkiConnect.Net;

public interface IAnkiModels
{
    Task<IList<string>?> ModelNamesAsync();
    Task<IDictionary<string, ulong>?> ModelNamesAndIdsAsync();
}
