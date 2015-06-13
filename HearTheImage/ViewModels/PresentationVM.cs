using HearTheImage.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace HearTheImage.ViewModels
{
    class PresentationVM : ViewModelBase
    {
        private static int interval = 3000;
        private int index = 0;
        private Timer timer;

        public PresentationVM()
        {
            timer = new Timer();
            timer.Interval = interval;
            timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            ++index;
            if (index > Images.Count - 1) index = 0;
            CurrentImage = Images[index];
        }

        private List<string> _images;
        public List<string> Images
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

        private string _currentImage;
        public string CurrentImage
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
