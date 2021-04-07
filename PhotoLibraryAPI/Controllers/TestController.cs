using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PhotoLibraryApplication.Models;

namespace PhotoLibraryApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [Produces("application/json")]
        public List<Image> Get()
        {
            var images = new List<Image>
            {
                new()
                {
                    Id = 1,
                    Url = "https://miro.medium.com/max/750/1*zc1BKfAHkpvrZlHPbUvuYA.png",
                    Width = 750,
                    Height = 280,
                    Photographer = "Aaron van den Berg"
                }
            };

            return images;
        }
    }
}