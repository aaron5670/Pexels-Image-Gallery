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
        public List<Student> FetchStudents()
        {
            var students = new List<Student>();
            students.Add(new Student
            {
                FirstName = "Hugo",
                LastName = "de Jong"
            });
            students.Add(new Student
            {
                FirstName = "Mark",
                LastName = "Rutte"
            });

            return students;
        }

        public async Task<List<Image>> LoadPhotos()
        {
            const string url = "https://photo-library.azurewebsites.net/images";
            using var response = await ApiHelper.ApiClient.GetAsync(url);

            if (!response.IsSuccessStatusCode) throw new Exception(response.ReasonPhrase);

            var data = await response.Content.ReadAsStringAsync();
            
            return JsonConvert.DeserializeObject<List<Image>>(data);
        }

    }
}