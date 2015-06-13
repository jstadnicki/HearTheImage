using System.IO;

namespace HearTheImage
{
    public class StoryImage
    {
        public FileInfo ImageFile { get; set; }

        public StoryImage(FileInfo info)
        {
            ImageFile = info;
        }
    }
}