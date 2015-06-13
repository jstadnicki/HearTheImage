using System.Collections.Generic;
using Un4seen.Bass.AddOn.Mix;

namespace HearTheImage
{
    public class SoundMixer : ISoundMixer
    {
        public int MixSounds(List<StorySound> sounds)
		{
            int mixerStream = BassMix.BASS_Mixer_StreamCreate(44100, 2, BASSFlag.BASS_SAMPLE_FLOAT );
            List<int> streams;
              
            foreach(var sound in sounds)
            {
                streams.add(CreateStream(sound.get()));
            }
            return MixStreams(streams, mixerStream);
        }
        
        private int MixStreams(List<int> streams, int mixerStream)
        {
            foreach(var stream in streams)
            {
                BassMix.BASS_Mixer_StreamAddChannel(mixerStream, stream, 
                   BASSFlag.BASS_STREAM_AUTOFREE | BASSFlag.BASS_MIXER_DOWNMIX);
            }
        }
        
        private int CreateStream(FileInfo file)
        {
                return Bass.BASS_StreamCreateFile(file.FullName, 0, 0, 
                        BASSFlag.BASS_STREAM_DECODE | BASSFlag.BASS_SAMPLE_FLOAT);
        }
    }
}
