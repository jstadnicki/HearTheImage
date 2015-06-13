using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace HearTheImage
{
    public interface IImageAnalyzer
    {
        Dictionary<StoryImage, List<string>> GetWords(IEnumerable<StoryImage> images);
    }
}