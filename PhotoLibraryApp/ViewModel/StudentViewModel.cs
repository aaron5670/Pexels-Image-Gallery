using System.Collections.ObjectModel;
using System.Threading.Tasks;
using PhotoLibraryApp.Model;
using PhotoLibraryApp.Service;

namespace PhotoLibraryApp.ViewModel
{
    public class StudentViewModel
    {
        public ObservableCollection<Student> Students { get; set; }

        public async Task LoadStudents()
        {
            var students = new ObservableCollection<Student>();
            var imagesService = new ImagesService();
            
            var studentsList = imagesService.FetchStudents();
            
            foreach (var student in studentsList)
            {
                students.Add(student);
            }

            // var images = await imagesService.LoadPhotos();
            //
            // Console.WriteLine(images[0].Url);
            
            Students = students;
        }
    }
}
