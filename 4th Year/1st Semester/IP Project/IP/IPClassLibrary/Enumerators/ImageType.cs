/// <summary>
/// The Type of the Image
/// </summary>
public enum ImageType
{
    /// <summary>
    /// Regular Windows Bitmap Images
    /// </summary>
    Bitmap,

    /// <summary>
    /// Image type is written in Strings Splitted By Spaces
    /// </summary>
    P3,

    /// <summary>
    /// Image type is written in Bytes with no Separators
    /// </summary>
    P6,

    /// <summary>
    /// Image is Corrupted
    /// </summary>
    Corrupted,
}