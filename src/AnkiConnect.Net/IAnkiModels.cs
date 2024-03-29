﻿using AnkiConnect.Net.Models;

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

    // TODO: createModel

    /// <summary>
    /// Returns an object indicating the template content for each card connected to the provided model by name
    /// </summary>
    /// <param name="value">Parameter structure</param>
    /// <returns>Template content for each card</returns>
    Task<IDictionary<string, CardTemplate>?> ModelTemplatesAsync(ModelNameParams value);

    /// <summary>
    /// Gets the CSS styling for the provided model by name
    /// </summary>
    /// <param name="value">Parameter structure</param>
    /// <returns>Styling</returns>
    Task<ModelStyling?> ModelStylingAsync(ModelNameParams value);

    /// <summary>
    /// Modify the templates of an existing model by name
    /// </summary>
    /// <remarks>Only specified cards and specified sides will be modified. If an existing card or side is not
    /// included in the request, it will be left unchanged</remarks>
    /// <param name="value">Parameter structure</param>
    /// <returns>Task</returns>
    Task UpdateModelTemplatesAsync(UpdateModelTemplatesParams value);

    /// <summary>
    /// Modify the CSS styling of an existing model by name
    /// </summary>
    /// <param name="value">Parameter structure</param>
    /// <returns>Task</returns>
    Task UpdateModelStylingAsync(UpdateModelStylingParams value);

    /// <summary>
    /// Find and replace string in existing model by model name. Customize to replace in front, back, or css by
    /// setting to true or false
    /// </summary>
    /// <param name="value">Parameter structure</param>
    /// <returns>Number of models modified</returns>
    Task<int?> FindAndReplaceInModelsAsync(FindAndReplaceInModelsParams value);
}
