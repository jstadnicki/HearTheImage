using HearTheImage.Helpers;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using HearTheImage.Controls;

namespace HearTheImage.ViewModels
{
    public class MainVM : ViewModelBase
    {
        private IImageUrlProvider _imageUrlProvider;
        private IImageAnalyzer _imageAnalyzer;
        private ISoundMixer _soundMixer;
        private ISoundsProvider _soundsProvider;
        public IBassPlayer _bassPlayer;
        private List<string> _images;

        public MainVM()
        {
            _imageAnalyzer = new ImageAnalyzer();
            _soundMixer = new SoundMixer();
            _imageUrlProvider = new AzureBlobStorage();
            _soundsProvider = new SoundsProvider();
            _bassPlayer = new BassPlayer();
            _images = new List<string>();
        }

        private bool _isPresentation;
        public bool IsPresentation
        {
            get { return _isPresentation; }
            set
            {
                if (value != _isPresentation)
                {
                    if(Control is Controls.PresentationCreatorControl)
                    {
                        var vm = (Control as Controls.PresentationCreatorControl).DataContext as CreatorVM;
                        _images = vm.Images.ToList();
                        if (_images == null || _images.Count == 0) return;
                    }
                    _control = value ? (UserControl)(new Controls.PresentationControl()) : (UserControl)(new Controls.PresentationCreatorControl());
                    if(_control is Controls.PresentationControl)
                    {
                        var vm = (Control as Controls.PresentationControl).DataContext as PresentationVM;
                    }
                    _isPresentation = value;
                    Notify("IsPresentation");
                    Notify("Control");
                }
            }
        }

        private UserControl _control;
        public UserControl Control
        {
            get
            {
                return _control ?? (_control = new Controls.PresentationCreatorControl());
            }
        }

        private DelegateCommand _play;
        public DelegateCommand Play
        {
            get { return _play ?? (_play = new DelegateCommand(playExecute, playCanExecute)); }
        }
        private void playExecute(object parameter)
        {
             
            if (_images == null || _images.Count < 0) return;

            IsPresentation = true;


            Dictionary<StoryImage, List<string>> imagesWithWords = GetImagesWithWords();

            var storySlides = imagesWithWords.Select(
                image => new StorySlide(image.Key, image.Value.Select(word => _soundsProvider.GetSoundForWord(word))))
                .ToList();

            List<StoryImageWithBackgrounMusic> storyImageWithBackgrounMusics = storySlides.Select(
                slide =>
                    new StoryImageWithBackgrounMusic(slide.Image, this._soundMixer.MixSounds(slide.Sounds.ToList())))
                .ToList();


            var presentationControl = (this.Control as Controls.PresentationControl);
            var vm = presentationControl.DataContext;
            (vm as PresentationVM).Images = storyImageWithBackgrounMusics;
        }

        private Dictionary<StoryImage, List<string>> GetImagesWithWords()
        {
            Dictionary<StoryImage, Task<string>> urlTasks = _images.Select(file => new FileInfo(file))
                .ToList()
                .ToDictionary(x => new StoryImage(x), x => this._imageUrlProvider.GetImageUrlFromFile(x));

            Dictionary<StoryImage, string> imageFileUrlDictionary = urlTasks.ToDictionary(x => x.Key,
                x => x.Value.Result);

            Dictionary<StoryImage, Dictionary<string, List<string>>> dictionary = imageFileUrlDictionary.ToDictionary(
                x => x.Key,
                x => this._imageAnalyzer.GetWords(new List<string> { x.Value }).Result);

            Dictionary<StoryImage, List<string>> imagesWithWords = dictionary.ToDictionary(x => x.Key,
                x => x.Value.SelectMany(v => v.Value).ToList());

            return imagesWithWords;
        }

        private bool playCanExecute(object parameter)
        {
            return true;
        }
    }

    internal class StoryImageWithBackgrounMusic
    {
        public StoryImage Image { get; set; }
        public int BassMixedStream { get; set; }

        public StoryImageWithBackgrounMusic(StoryImage image, int bassMixedStream)
        {
            this.Image = image;
            this.BassMixedStream = bassMixedStream;
        }
    }

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
