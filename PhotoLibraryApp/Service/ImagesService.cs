using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PhotoLibraryApp.Helpers;
using PhotoLibraryApp.Model;

namespace PhotoLibraryApp.Service
{
    public class ImagesService
    {
        public async Task<List<Image>> LoadImages()
        {
            const string url = "https://photo-library.azurewebsites.net/images";
            using var response = await ApiHelper.ApiClient.GetAsync(url);

            if (!response.IsSuccessStatusCode) throw new Exception(response.ReasonPhrase);

            var data = await response.Content.ReadAsStringAsync();
            
            return JsonConvert.DeserializeObject<List<Image>>(data);
        }

        public async Task<List<Image>> SearchImages(string searchString)
        {
            var url = $"https://photo-library.azurewebsites.net/images?search={searchString}";
            using var response = await ApiHelper.ApiClient.GetAsync(url);

            if (!response.IsSuccessStatusCode) throw new Exception(response.ReasonPhrase);

            var data = await response.Content.ReadAsStringAsync();
            
            return JsonConvert.DeserializeObject<List<Image>>(data);
        }

    }
}