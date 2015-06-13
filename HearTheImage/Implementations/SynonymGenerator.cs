using System.Linq;
using HearTheImage.Interfaces;
using NHunspell;

namespace HearTheImage.Implementations
{
    internal class SynonymGenerator : ISynonymGenerator
    {
        private MyThes _thes;
        private Hunspell _hunspell;

        public SynonymGenerator()
        {
            _thes = new MyThes(".\\content\\th_en_us_new.dat");
            _hunspell = new Hunspell(".\\content\\en_us.aff", ".\\content\\en_us.dic");

        }

        public StoryWord GetSynonyms(string word)
        {
            var tr = _thes.Lookup(word, _hunspell);
            var result = new StoryWord(word, tr.Meanings.Select(x=>x.Description));
            return result;
        }
    }
}