using AnkiConnect.Net.Models;

namespace AnkiConnect.Net;

public interface IAnkiMedia
{
    /// <summary>
    /// Stores a file with the specified base64-encoded contents inside the media folder. Alternatively you can specify
    /// an absolute file path, or a url from where the file shall be downloaded.
    /// </summary>
    /// <remarks>
    /// If more than one of <see cref="StoreMediaFileParams.Data"/>, <see cref="StoreMediaFileParams.Path"/>, and
    /// <see cref="StoreMediaFileParams.Url"/> are provided, the Data field will be used first, then Path,
    /// and finally url. To prevent Anki from removing files not used by any cards (e.g. for configuration files),
    /// prefix the filename with an underscore. These files are still synchronized to AnkiWeb.
    /// Any existing file with the same name is deleted by default.
    /// Set <see cref="StoreMediaFileParams.DeleteExisting"/>
    /// to false to prevent that by letting Anki give the new file a non-conflicting name
    /// </remarks>
    /// <param name="value">Parameter structure</param>
    /// <returns>File name</returns>
    Task<string?> StoreMediaFileAsync(StoreMediaFileParams value);

    /// <summary>
    /// Retrieves the base64-encoded contents of the specified file
    /// </summary>
    /// <param name="value">Parameter structure</param>
    /// <returns>File contents, or null if the file does not exist</returns>
    Task<string?> RetrieveMediaFileAsync(FileNameParams value);

    /// <summary>
    /// Gets the names of media files matched the pattern. Returning all names by default
    /// </summary>
    /// <param name="value">Parameter structure</param>
    /// <returns>File names</returns>
    Task<IList<string>?> GetMediaFileNamesAsync(PatternParams value);

    /// <summary>
    /// Deletes the specified file inside the media folder
    /// </summary>
    /// <param name="value">Parameter structure</param>
    /// <returns>Task</returns>
    Task DeleteMediaFileAsync(FileNameParams value);
}
