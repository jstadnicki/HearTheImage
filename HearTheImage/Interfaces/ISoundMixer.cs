using System.Collections.Generic;

namespace HearTheImage
{
    public interface ISoundMixer
    {
        int MixSounds(List<StorySound> sounds);
    }
}