using DrakeShop.Images.Models;

namespace DrakeShop.Images.Services
{
    public interface ICloudStorageService
    {
        Task<string> UploadFileAsync(byte[] fileBytes, string fileName, string contentType);
        Task<byte[]> DownloadFileAsync(string fileName);
        Task<List<CloudImage>> GetAll();
        Task<CloudImage> GetById(string id);
        Task<bool> Create(CloudImage image);
        Task<bool> Delete(string id);
    }
}
