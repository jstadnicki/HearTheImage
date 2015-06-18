using System.Collections.Generic;

namespace HearTheImage.ViewModels
{
    internal class StorySlide
    {
        public StoryImage Image { get; set; }
        public IEnumerable<StorySound> Sounds { get; set; }

        public StorySlide(StoryImage image, IEnumerable<StorySound> sounds)
        {
            this.Image = image;
            this.Sounds = sounds;
        }
    }
}