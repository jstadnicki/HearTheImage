using System.IO;

namespace HearTheImage
{
    public class StorySound
    {
        public StorySound(string path)
        {
            SoundFile = new FileInfo(path);
        }

        public FileInfo SoundFile { get; set; } 
    }
}