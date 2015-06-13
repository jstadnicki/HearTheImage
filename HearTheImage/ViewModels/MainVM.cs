using HearTheImage.Helpers;
using System.Collections.Generic;
using System.Linq;
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
                    List<string> images = null;
                    if(Control is Controls.PresentationCreatorControl)
                    {
                        var vm = (Control as Controls.PresentationCreatorControl).DataContext as CreatorVM;
                        images = vm.Images.ToList();
                        if (images == null || images.Count == 0) return;
                    }
                    _control = value ? (UserControl)(new Controls.PresentationControl()) : (UserControl)(new Controls.PresentationCreatorControl());
                    if(_control is Controls.PresentationControl)
                    {
                        var vm = (Control as Controls.PresentationControl).DataContext as PresentationVM;
                        vm.Images = images;
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
            IsPresentation = true;
        }
        private bool playCanExecute(object parameter)
        {
            return true;
        }
    }
}
