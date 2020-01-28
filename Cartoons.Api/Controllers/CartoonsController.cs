using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Cartoons.Models;
using Cartoons.Services;

namespace Cartoons.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartoonsController: ControllerBase
    {
        private readonly ICartoonStoreDBService _cartoonStoreDBService;
        public CartoonsController(ICartoonStoreDBService cartoonStoreDBService)
        {
            _cartoonStoreDBService = cartoonStoreDBService;
        }

        [HttpGet]
        public async Task<IEnumerable<Cartoon>> GetCartoons()
        {
            var cartoons = await _cartoonStoreDBService.GetCartoonsAsync();
            return cartoons;
        }

        [HttpPost]
        public async Task<Cartoon> PostCartoon(Cartoon cartoonIn)
        {
            var cartoon = await _cartoonStoreDBService.AddCartoonAsync(cartoonIn);
            return cartoon;
        }

        [HttpPut("{id}")]
        public async Task UpdateCartoon(string id, Cartoon cartoonIn)
        {
            await _cartoonStoreDBService.UpdateCartoonAsync(id, cartoonIn);
        }

        [HttpDelete]
        public async Task DeleteCartoon(string cartoonId)
        {
            await _cartoonStoreDBService.DeleteCartoonAsync(cartoonId);
        }
    }    
}