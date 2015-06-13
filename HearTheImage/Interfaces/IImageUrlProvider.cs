using System.IO;
using System.Threading.Tasks;

namespace HearTheImage
{
    public interface IImageUrlProvider
    {
        Task<string> GetImageUrlFromFile(FileInfo inputfile);
    }
}