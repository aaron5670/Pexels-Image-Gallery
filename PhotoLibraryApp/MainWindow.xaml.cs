using System.Windows;

namespace PhotoLibraryApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void ImageViewControl_Loaded(object sender, RoutedEventArgs e)
        {
            var imageViewModelObject = new ViewModel.ImageViewModel();
            await imageViewModelObject.LoadImages();

            ImageViewControl.DataContext = imageViewModelObject;
        }
    }
}