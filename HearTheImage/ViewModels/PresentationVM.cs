using HearTheImage.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Threading;

namespace HearTheImage.ViewModels
{
    class PresentationVM : ViewModelBase
    {
        private static int interval = 15000;
        private int index = 0;
        private Timer timer;

        public PresentationVM()
        {
            _dispatcher = Dispatcher.CurrentDispatcher;

            timer = new Timer();
            timer.Interval = interval;
            timer.Elapsed += Timer_Elapsed;
            _bassplayer = new BassPlayer();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            ++index;
            if (index > Images.Count - 1) index = 0;
            CurrentImage = Images[index];
            this._bassplayer.PlayStream(CurrentImage.BassMixedStream);
        }

        private List<StoryImageWithBackgrounMusic> _images;
        public List<StoryImageWithBackgrounMusic> Images
        {
            get { return _images; }
            set
            {
                _images = value;
                if (_images != null) CurrentImage = _images[index];
                timer.Enabled = true;
                Notify("Images");
            }
        }

        private StoryImageWithBackgrounMusic _currentImage;
        private BassPlayer _bassplayer;
        private Dispatcher _dispatcher;

        public StoryImageWithBackgrounMusic CurrentImage
        {
            get { return _currentImage; }
            set
            {
                _currentImage = value;
                Notify("CurrentImage");
            }
        }

    }
}
