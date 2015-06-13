using System.Collections.Generic;
using System.Linq;

namespace HearTheImage
{
    public class StoryWord
    {
        public StoryWord(string word, IEnumerable<string> tr)
        {
            Word = word;
            Synonyms = tr.ToList();
        }

        public string Word { get; set; }
        public IList<string> Synonyms { get; set; }
    }
}