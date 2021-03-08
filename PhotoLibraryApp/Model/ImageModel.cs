using System.ComponentModel;

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
            set => _id = value;
        }

        public string Url
        {
            get => _url;
            set => _url = value;
        }

        public string Photographer
        {
            get => _photographer;
            set => _photographer = value;
        }

        public string Width
        {
            get => _width;
            set => _width = value;
        }

        public string Height
        {
            get => _height;
            set => _height = value;
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
