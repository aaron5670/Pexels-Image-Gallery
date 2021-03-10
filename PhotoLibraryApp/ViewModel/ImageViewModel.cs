using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using PhotoLibraryApp.Model;
using PhotoLibraryApp.Service;

namespace PhotoLibraryApp.ViewModel
{
    public class ImageViewModel
    {
        public ObservableCollection<Image> Images { get; set; }
        private string _searchString;

        public async Task LoadInitialImages()
        {
            var images = new ObservableCollection<Image>();
            var imagesService = new ImagesService();
            var imagesList = await imagesService.LoadImages();

            foreach (var image in imagesList)
            {
                images.Add(image);
            }

            Console.WriteLine("Fetched!");
            
            Images = images;
        }

        public async Task FindSearchedImages(string searchString)
        {
            var imagesService = new ImagesService();
            var imagesList = await imagesService.SearchImages(searchString);

            Images.Clear();
            foreach (var image in imagesList)
            {
                Images.Add(image);
            }

            Console.WriteLine("Search fetched!");
        }

        public string SearchImages
        {
            get { return _searchString; }
            set
            {
                if (_searchString == value) return;
                Console.WriteLine(value);
                FindSearchedImages(value);
            }
        }
    }
}