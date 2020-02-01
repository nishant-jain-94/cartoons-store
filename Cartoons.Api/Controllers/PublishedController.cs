using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cartoons.Models;
using Cartoons.Services;

namespace Cartoons.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartoonsController: ControllerBase
    {
        private readonly ICartoonStoreDBService _cartoonStoreDBService;
        public CartoonsController(ICartoonStoreDBService cartoonsStoreDBService)
        {
            _cartoonStoreDBService = cartoonsStoreDBService;
        }

        [HttpGet]
        public async Task<IEnumerable<Cartoon>> GetCartoonsAsync()
        {
            var cartoons = await _cartoonStoreDBService.GetCartoonsAsync();
            return cartoons;
        }

        [HttpGet("{id}")]
        public async Task<Cartoon> GetCartoonAsync(string id)
        {
            var cartoon = await _cartoonStoreDBService.GetCartoonAsync(id);
            return cartoon;
        }
    }
}