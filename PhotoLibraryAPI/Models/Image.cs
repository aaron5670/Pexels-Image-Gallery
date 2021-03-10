namespace PhotoLibraryApplication.Models
{
    public class Image
    {
        public long Id { get; set; }
        public string Url { get; set; }
        public string Photographer { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}