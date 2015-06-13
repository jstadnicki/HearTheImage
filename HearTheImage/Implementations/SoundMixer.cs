using System.Collections.Generic;
using System.IO;
using System.Linq;
using Un4seen.Bass;
using Un4seen.Bass.AddOn.Mix;

namespace HearTheImage
{
    public class SoundMixer : ISoundMixer
    {
        public int MixSounds(List<StorySound> sounds)
		{
            var mixerStream = BassMix.BASS_Mixer_StreamCreate(44100, 2, BASSFlag.BASS_SAMPLE_FLOAT );
            var streams = sounds.Select(sound => CreateStream(sound.SoundFile)).ToList();
            this.MixStreams(streams, mixerStream);
            return mixerStream;
        }
        
        private void MixStreams(List<int> streams, int mixerStream)
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
