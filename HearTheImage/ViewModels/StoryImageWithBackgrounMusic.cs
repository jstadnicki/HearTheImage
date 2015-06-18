using NAudio.Wave;

namespace HearTheImage.ViewModels
{
    internal class StoryImageWithBackgrounMusic
    {
        public StoryImage Image { get; set; }
        public Mp3FileReader BassMixedStream { get; set; }

        public StoryImageWithBackgrounMusic(StoryImage image, Mp3FileReader bassMixedStream)
        {
            this.Image = image;
            this.BassMixedStream = bassMixedStream;
        }
    }
}