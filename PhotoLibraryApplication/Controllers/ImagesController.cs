using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhotoLibraryApplication.Models;
using PexelsDotNetSDK.Api;
using PhotoLibraryApplication.helpers;

namespace PhotoLibraryApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImagesController : ControllerBase
    {
        private readonly AzureVaultHelper _azureVaultHelper = new("https://schoolapplicationkeys.vault.azure.net/");
        private string _pexelsApiKey;
        private PexelsClient _pexelsClient;

        [HttpGet]
        public async Task<List<Image>> Get(string search)
        {
            if (_pexelsClient == null) await InitPexelsClient();
            
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

        [HttpGet("{id}")]
        public async Task<Image> Get(int id)
        {
            if (_pexelsClient == null) await InitPexelsClient();

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

        private async Task InitPexelsClient()
        {
            _pexelsApiKey ??= await _azureVaultHelper.GetSecretAzureVaultValue("pexelsApiKey");
            _pexelsClient = new PexelsClient(_pexelsApiKey);
            
            Console.WriteLine("Init funciton runs");
        }
    }
}