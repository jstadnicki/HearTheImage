using System.Collections.Generic;
using System.Threading.Tasks;

namespace HearTheImage
{
    public interface IImageAnalyzer
    {
        Task<Dictionary<string, List<string>>> GetWords(IEnumerable<string> images);
    }
}