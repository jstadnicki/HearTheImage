using System;

namespace HearTheImage
{
    public interface ISoundsProvider
    {
        StorySound GetSoundForWord(string word);
    }

    class SoundsProvider : ISoundsProvider
    {
        public StorySound GetSoundForWord(string word)
        {
            switch (word.ToLower())
            {
                case "bee":
                case "hymenopterous insect":
                case "social gathering":
                    return new StorySound(".\\content\\sounds\\Bee.mp3");
                case "gallinacean":
                case "gallinaceous bird":
                    return new StorySound(".\\content\\sounds\\Cow.mp3");
                case "truecat":
                    return new StorySound(".\\content\\sounds\\CatMeaw.mp3");
                case "Duck":
                case "anseriform bird":
                case "duck's egg":
                case "poultry":
                case "move":
                case "dive":
                case "dip":
                case "hedge":
                    return new StorySound(".\\content\\sounds\\Duck.mp3");
                    
            }
            return null;
        }
    }
}