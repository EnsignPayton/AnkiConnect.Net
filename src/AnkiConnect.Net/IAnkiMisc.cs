using AnkiConnect.Net.Models;

namespace AnkiConnect.Net;

public interface IAnkiMisc
{
    /// <summary>
    /// Requests permission to use the API exposed by this plugin. This method does not require the API key, and is the
    /// only one that accepts requests from any origin; the other methods only accept requests from trusted origins,
    /// which are listed under webCordOriginList in the add-on config. localhost is trusted by default
    /// </summary>
    /// <remarks>
    /// Calling this method from an untrusted origin will display a popup in Anki asking the user whether they want to
    /// allow your origin to use the API; calls from trusted origins will return the result without displaying the
    /// popup. When denying permission, the user may also choose to ignore further permission requests from that origin.
    /// These origins end up in the ignoreOriginList, editable via the add-on config.
    ///
    /// The result always contains the <see cref="RequestPermissionResult.Permission"/> field, which in turn contains
    /// either the string "granted" or "denied", corresponding to whether your origin is trusted. If your origin is
    /// trusted, the fields <see cref="RequestPermissionResult.RequireApiKey"/> (true if required) and
    /// <see cref="RequestPermissionResult.Version"/> will also be returned.
    ///
    /// This should be the first call you make to make sure that your application and Anki-Connect are able to
    /// communicate properly with each other. New versions of Anki-Connect are backwards compatible; as long as you are
    /// using actions which are available in the reported Anki-Connect version or earlier, everything should work fine.
    /// </remarks>
    /// <returns>Permissions</returns>
    Task<RequestPermissionResult?> RequestPermissionAsync();

    /// <summary>
    /// Gets the version of the API exposed by this plugin. Currently versions 1 through 6 are defined
    /// </summary>
    /// <returns>Version</returns>
    Task<int?> VersionAsync();

    /// <summary>
    /// Gets information about AnkiConnect APIs available
    /// </summary>
    /// <remarks>
    /// The request supports the following params:
    ///
    /// <see cref="ApiReflectInfo.Scopes"/> - An array of scopes to get reflection information about. The only
    /// currently supported value is "actions".
    ///
    /// <see cref="ApiReflectInfo.Actions"/> - Either null or an array of API method names to check for. If the value
    /// is null, the result will list all of the available API actions. If the value is an array of strings, the result
    /// will only contain actions which went in this array
    /// </remarks>
    /// <param name="value">Parameter structure</param>
    /// <returns>A list of which scopes were used and a value for each scope. For example, the "actions" scope will
    /// contain an "actions" property which contains a list of supported action names</returns>
    Task<ApiReflectResult?> ApiReflectAsync(ApiReflectParams value);

    /// <summary>
    /// Synchronizes the local Anki collections with AnkiWeb
    /// </summary>
    /// <returns>Task</returns>
    Task SyncAsync();

    /// <summary>
    /// Retrieve the list of profiles
    /// </summary>
    /// <returns>Profiles</returns>
    Task<IList<string>?> GetProfilesAsync();

    /// <summary>
    /// Selects the profile specified in request
    /// </summary>
    /// <param name="value">Parameter structure</param>
    /// <returns>Result</returns>
    Task<bool?> LoadProfileAsync(NameParams value);

    // TODO: Multi

    /// <summary>
    /// Exports a given deck in .apkg format
    /// </summary>
    /// <remarks>
    /// The optional property <see cref="ExportPackageParams.IncludeScheduleData"/> (default is false) can be specified
    /// to include the cards' scheduling data
    /// </remarks>
    /// <param name="value">Parameter structure</param>
    /// <returns>True if successful or false otherwise</returns>
    Task<bool?> ExportPackageAsync(ExportPackageParams value);

    /// <summary>
    /// Imports a file in .apkg format into the collection
    /// </summary>
    /// <remarks>Note that the file path is relative to Anki's collection.media folder, not to the client</remarks>
    /// <param name="value">Parameter structure</param>
    /// <returns>True if successful or false otherwise</returns>
    Task<bool?> ImportPackageAsync(PathParams value);

    /// <summary>
    /// Tell anki to reload all data from the database
    /// </summary>
    /// <returns>Task</returns>
    Task ReloadCollectionAsync();
}
