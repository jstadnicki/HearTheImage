using System.IO;

namespace HearTheImage
{
    public interface IImageUrlProvider
    {
        string GetImageUrlFromFile(FileInfo inputfile);
    }
}