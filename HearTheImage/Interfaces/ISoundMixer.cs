using System.Collections.Generic;
using System.IO;
using NAudio.Wave;

namespace HearTheImage
{
    public interface ISoundMixer
    {
        Mp3FileReader MixSounds(List<StorySound> sounds);
    }
}