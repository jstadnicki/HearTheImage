﻿using HearTheImage.Helpers;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearTheImage.ViewModels
{
    public class CreatorVM : ViewModelBase
    {
        #region Commands
        private DelegateCommand _addImages;
        public DelegateCommand AddImages
        {
            get { return _addImages ?? (_addImages = new DelegateCommand(addImagesExecute, (x) => true)); }
        }

        private void addImagesExecute(object parameter)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.BMP; *.JPG; *.GIF)| *.BMP; *.JPG; *.GIF";
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == true)
            {
                foreach (var image in openFileDialog.FileNames)
                {
                    Images.Add(image);
                }
            }
        }

        private DelegateCommand _removeImage;
        public DelegateCommand RemoveImage
        {
            get { return _removeImage ?? (_removeImage = new DelegateCommand(removeImageExecute, x => SelectedImage != null)); }
        }
        private void removeImageExecute(object parameter)
        {
            if (SelectedImage == null) return;
            Images.Remove(SelectedImage);
        }

        private DelegateCommand _moveUp;
        public DelegateCommand MoveUp
        {
            get { return _moveUp ?? (_moveUp = new DelegateCommand(moveUpExecute, moveUpCanExecute)); }
        }
        private void moveUpExecute(object parameter)
        {
            if (SelectedImage == null) return;
            var index = Images.IndexOf(SelectedImage);
            if(index > 0)
            {
                var img = SelectedImage;
                Images.Remove(SelectedImage);
                SelectedImage = null;
                Images.Insert(index - 1, img);
                SelectedImage = Images[index - 1];
            }
        }
        private bool moveUpCanExecute(object parameter)
        {
            return SelectedImage != null && Images.IndexOf(SelectedImage) > 0;
        }

        private DelegateCommand _moveDown;
        public DelegateCommand MoveDown
        {
            get { return _moveDown ?? (_moveDown = new DelegateCommand(moveDownExecute, moveDownCanExecute)); }
        }
        private void moveDownExecute(object parameter)
        {
            if (SelectedImage == null) return;
            var index = Images.IndexOf(SelectedImage);
            if (index < Images.Count - 1)
            {
                var img = SelectedImage;
                Images.Remove(SelectedImage);
                SelectedImage = null;
                Images.Insert(index + 1, img);
                SelectedImage = Images[index + 1];
            }
        }
        private bool moveDownCanExecute(object parameter)
        {
            return SelectedImage != null && Images.IndexOf(SelectedImage) < Images.Count - 1;
        }
        #endregion

        private ObservableCollection<string> _images;
        public ObservableCollection<string> Images
        {
            get
            {
                return _images ?? (_images = new ObservableCollection<string>());
            }
            set
            {
                _images = value;
                Notify("Images");
            }
        }

        private string _selectedImage;
        public string SelectedImage
        {
            get { return _selectedImage; }
            set
            {
                _selectedImage = value;
                RemoveImage.RaiseCanExecuteChanged();
                MoveUp.RaiseCanExecuteChanged();
                MoveDown.RaiseCanExecuteChanged();
                Notify("SelectedImage");
            }
        }
    }
}
