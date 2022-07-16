using AnkiConnect.Net.Models;

namespace AnkiConnect.Net;

public interface IAnkiModels
{
    /// <summary>
    /// Gets the complete list of model names for the current user
    /// </summary>
    /// <returns>Model names</returns>
    Task<IList<string>?> ModelNamesAsync();

    /// <summary>
    /// Gets the complete list of model names and their corresponding IDs for the current user
    /// </summary>
    /// <returns>Model names and IDs</returns>
    Task<IDictionary<string, ulong>?> ModelNamesAndIdsAsync();

    /// <summary>
    /// Gets the complete list of field names for the provided model name
    /// </summary>
    /// <param name="value">Parameter structure</param>
    /// <returns>Field names</returns>
    Task<IList<string>?> ModelFieldNamesAsync(ModelNameParams value);

    /// <summary>
    /// Returns an object indicating the fields on the question and answer side of each card template for the given
    /// model name. The question side is given first in each array
    /// </summary>
    /// <param name="value">Parameter structure</param>
    /// <returns>The fields on the question and answer side of each card template for the given model name</returns>
    Task<IDictionary<string, IList<IList<string>>>?> ModelFieldsOnTemplatesAsync(ModelNameParams value);
}
