using System.Collections.Generic;

namespace HearTheImage
{
    public interface IImageAnalyzer
    {
        Dictionary<StoryImage, List<string>> GetWords(IEnumerable<StoryImage> images);
    }
}