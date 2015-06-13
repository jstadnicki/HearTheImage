using System;

namespace HearTheImage
{
    public interface ISynonymGenerator
    {
        StoryWord GetSynonyms(string word);
    }

    class SynonymGenerator : ISynonymGenerator
    {
        public StoryWord GetSynonyms(string word)
        {
            throw new NotImplementedException();
        }
    }
}