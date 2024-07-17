namespace DrakeShop.Images.Models
{
    public class FileUpload
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public IFormFile File { get; set; }
    }

}
