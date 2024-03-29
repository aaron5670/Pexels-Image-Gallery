﻿using System.ComponentModel;

namespace PhotoLibraryApp.Model
{
    public class Image : INotifyPropertyChanged
    {
        private string _id;
        private string _url;
        private string _photographer;
        private string _width;
        private string _height;

        public string Id
        {
            get => _id;

            set
            {
                if (_id == value) return;
                _id = value;
                RaisePropertyChanged("Id");
            }
        }

        public string Url
        {
            get => _url;
            set
            {
                if (_url == value) return;
                _url = value;
                RaisePropertyChanged("Url");
            }
        }

        public string Photographer
        {
            get => _photographer;
            set
            {
                if (_photographer == value) return;
                _photographer = value;
                RaisePropertyChanged("Photographer");
            }
        }

        public string Width
        {
            get => _width;
            set
            {
                if (_width == value) return;
                _width = value;
                RaisePropertyChanged("Width");
            }
        }

        public string Height
        {
            get => _height;
            set
            {
                if (_height == value) return;
                _height = value;
                RaisePropertyChanged("Height");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}