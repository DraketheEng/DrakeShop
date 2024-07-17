using DrakeShop.Images.Models;
using DrakeShop.Images.MongoDB.Repository;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Storage.v1.Data;
using Google.Cloud.Storage.V1;
using System.Text.RegularExpressions;

namespace DrakeShop.Images.Services
{
    public class CloudStorageService : ICloudStorageService
    {
        private const string SERVICE_ACCOUNT_KEY_PATH = "C:\\Users\\agirb\\Desktop\\CAN\\PROJELER\\E-Commerce\\DrakeShop\\Services\\Images\\DrakeShop.Images\\storage-429410-9203e7212934.json";
        private const string _bucketName = "drake-shop-bucket";
        private readonly StorageClient _client;
        private readonly IMongoDbServices<CloudImage> _cloudServices;

        public CloudStorageService(IMongoDbServices<CloudImage> cloudServices)
        {
            var credential = GoogleCredential.FromFile(SERVICE_ACCOUNT_KEY_PATH);
            _client = StorageClient.Create(credential);
            _cloudServices = cloudServices;
        }

        private static string Slugify(string text)
        {
            text = text.ToLowerInvariant();
            text = Regex.Replace(text, @"[^a-z0-9\s-]", "");
            text = Regex.Replace(text, @"\s+", " ").Trim();
            text = text.Substring(0, text.Length <= 45 ? text.Length : 45).Trim();
            text = Regex.Replace(text, @"\s", "-");
            return text;
        }

        public async Task<string> UploadFileAsync(byte[] fileBytes, string fileName, string contentType)
        {
            var slugifiedFileName = Slugify(fileName);
            using (var stream = new MemoryStream(fileBytes))
            {
                var obj = await _client.UploadObjectAsync(_bucketName, slugifiedFileName, contentType, stream);
                obj.Acl = new List<ObjectAccessControl>
                {
                    new ObjectAccessControl
                    {
                        Entity = "allUsers",
                        Role = "READER"
                    }
                };
                await _client.UpdateObjectAsync(obj);

                var fileUrl = $"https://storage.googleapis.com/{_bucketName}/{slugifiedFileName}";

                var cloudImage = new CloudImage { ImageUrl = fileUrl };
                await Create(cloudImage);

                return fileUrl;
            }
        }

        public async Task<byte[]> DownloadFileAsync(string fileName)
        {
            using (var stream = new MemoryStream())
            {
                await _client.DownloadObjectAsync(_bucketName, fileName, stream);
                return stream.ToArray();
            }
        }

        public async Task<List<CloudImage>> GetAll()
        {
            return _cloudServices.FilterBy(x => true).ToList();
        }

        public async Task<CloudImage> GetById(string id)
        {
            return await _cloudServices.FindByIdAsync(id);
        }

        public async Task<bool> Create(CloudImage image)
        {
            await _cloudServices.InsertOneAsync(image);
            return true;
        }

        public async Task<bool> Delete(string id)
        {
            await _cloudServices.DeleteOneAsync(x => x.Id == id);
            return true;
        }
    }
}