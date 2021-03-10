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

        public async Task LoadImages()
        {
            var images = new ObservableCollection<Image>();
            var imagesService = new ImagesService();
            var imagesList = await imagesService.LoadPhotos();

            foreach (var image in imagesList)
            {
                images.Add(image);
            }

            Console.WriteLine("Fetched!");
            
            Images = images;
        }
    }
}
