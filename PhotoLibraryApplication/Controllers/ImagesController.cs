using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PhotoLibraryApplication.Models;
using PexelsDotNetSDK.Api;

namespace PhotoLibraryApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImagesController : ControllerBase
    {
        private PexelsClient _pexelsClient;
        
        private static IConfiguration _configuration;

        public ImagesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<List<Image>> Get(string search)
        {
            try
            {
                InitPexelsClient();

                var result = search != null
                    ? await _pexelsClient.SearchPhotosAsync(search)
                    : await _pexelsClient.CuratedPhotosAsync(pageSize: 15);

                return result.photos.Select(photo => new Image
                    {
                        Id = photo.id,
                        Url = photo.source.original,
                        Width = photo.width,
                        Height = photo.height,
                        Photographer = photo.photographer
                    })
                    .ToList();
            }
            catch
            {
                StatusCode(401);
                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<Image> Get(int id)
        {
            if (_pexelsClient == null) InitPexelsClient();

            var result = await _pexelsClient.GetPhotoAsync(id);
            return new Image
            {
                Id = result.id,
                Url = result.source.original,
                Width = result.width,
                Height = result.height,
                Photographer = result.photographer
            };
        }

        private void InitPexelsClient()
        {
            var pexelsApiKey = _configuration["MySettings:PexelsApiKey"];
            _pexelsClient = new PexelsClient(pexelsApiKey);
        }
    }
}
