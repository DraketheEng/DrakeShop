using DrakeShop.Images.Models;
using DrakeShop.Images.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DrakeShop.Images.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class GCSController : ControllerBase
    {
        private readonly ICloudStorageService _cloudStorageService;

        public GCSController(ICloudStorageService cloudStorageService)
        {
            _cloudStorageService = cloudStorageService;
        }

        [HttpGet("file")]
        public async Task<IActionResult> GetFile([FromQuery] string fileName)
        {
            var fileBytes = await _cloudStorageService.DownloadFileAsync(fileName);
            return File(fileBytes, "application/octet-stream", fileName);
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile([FromBody] IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Dosya yüklenmedi");

            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                var fileBytes = stream.ToArray();
                var link = await _cloudStorageService.UploadFileAsync(fileBytes, file.FileName, file.ContentType);
                return Ok(new { Link = link });
            }
        }

        [HttpGet("file/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var fileRecord = await _cloudStorageService.GetById(id);
            if (fileRecord == null)
            {
                return NotFound();
            }

            return Ok(fileRecord);
        }

        [HttpDelete("file/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _cloudStorageService.Delete(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet("files")]
        public async Task<IActionResult> GetAll()
        {
            var fileRecords = await _cloudStorageService.GetAll();
            return Ok(fileRecords);
        }
    }
}
