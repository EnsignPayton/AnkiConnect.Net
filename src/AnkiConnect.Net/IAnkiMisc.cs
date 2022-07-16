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
    /// Tell anki to reload all data from the database
    /// </summary>
    /// <returns>Task</returns>
    Task ReloadCollectionAsync();
}
