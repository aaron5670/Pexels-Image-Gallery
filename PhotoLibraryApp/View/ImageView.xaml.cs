using PhotoLibraryApp.Helpers;

namespace PhotoLibraryApp.View
{
    public partial class ImageView
    {
        public ImageView()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
        }
    }
}