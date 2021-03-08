using System.Windows.Controls;
using PhotoLibraryApp.Helpers;

namespace PhotoLibraryApp.View
{
    public partial class StudentView : UserControl
    {
        public StudentView()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
        }
    }
}