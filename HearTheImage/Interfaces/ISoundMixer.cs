using System.Collections.Generic;

namespace HearTheImage
{
    public interface ISoundMixer
    {
        StorySoundMix MixSounds(List<StorySound> sounds);
    }
}