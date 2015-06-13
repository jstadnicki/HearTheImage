using System.Collections.Generic;
using System.Threading.Tasks;

namespace HearTheImage
{
    public interface IImageAnalyzer
    {
        Task<Dictionary<StoryImage, List<string>>> GetWords(IEnumerable<StoryImage> images);
    }
}