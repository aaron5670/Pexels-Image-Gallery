using System.ComponentModel;

namespace PhotoLibraryApp.Model
{
    public class Student : INotifyPropertyChanged
    {
        private string _firstName;
        private string _lastName;

        public string FirstName
        {
            get => _firstName;

            set
            {
                if (_firstName == value) return;
                _firstName = value;
                RaisePropertyChanged("FirstName");
                RaisePropertyChanged("FullName");
            }
        }

        public string LastName
        {
            get => _lastName;

            set
            {
                if (_lastName == value) return;
                _lastName = value;
                RaisePropertyChanged("LastName");
                RaisePropertyChanged("FullName");
            }
        }

        public string FullName => _firstName + " " + _lastName;

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
