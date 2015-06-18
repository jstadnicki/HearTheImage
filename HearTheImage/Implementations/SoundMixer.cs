using System.Collections.Generic;
using System.IO;
using System.Linq;
using NAudio.Wave;

namespace HearTheImage
{
    public class SoundMixer : ISoundMixer
    {
        public Mp3FileReader MixSounds(List<StorySound> sounds)
        {
            //var output = new MemoryStream();
                Mp3FileReader reader = new Mp3FileReader(sounds.First().SoundFile.FullName);
            return reader;

            //foreach (var sound in sounds)
            //{
            //    Mp3FileReader reader = new Mp3FileReader(sound.SoundFile.FullName);
            //    if ((output.Position == 0) && (reader.Id3v2Tag != null))
            //    {
            //        output.Write(reader.Id3v2Tag.RawData, 0, reader.Id3v2Tag.RawData.Length);
            //    }
            //    Mp3Frame frame;
            //    while ((frame = reader.ReadNextFrame()) != null)
            //    {
            //        output.Write(frame.RawData, 0, frame.RawData.Length);
            //    }

            //    Mp3
            //}

            

            //return output;
        }
        
        
    }
}
