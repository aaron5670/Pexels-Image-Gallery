using System.Windows.Controls;
using PhotoLibraryApp.Helpers;

namespace PhotoLibraryApp.View
{
    public partial class ImageView : UserControl
    {
        public ImageView()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
        }
    }
}