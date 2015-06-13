using HearTheImage.Helpers;
using System.Windows.Controls;

namespace HearTheImage.ViewModels
{
    public class MainVM : ViewModelBase
    {
        private bool _isPresentation;
        public bool IsPresentation
        {
            get { return _isPresentation; }
            set
            {
                if (value != _isPresentation)
                {
                    _control = value ? (UserControl)(new Controls.PresentationControl()) : (UserControl)(new Controls.PresentationCreatorControl());
                    _isPresentation = value;
                    Notify("IsPresentation");
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

    }
}
