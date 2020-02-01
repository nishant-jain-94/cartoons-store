using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Cartoons.Models;
using Cartoons.Services;

namespace Cartoons.Api.Controllers
{
    [ApiController]
    [Route("api/cartoons/draft")]
    public class DraftsController: ControllerBase
    {
        private readonly IDraftCartoonStoreDBService _cartoonStoreDBService;
        public DraftsController(IDraftCartoonStoreDBService cartoonStoreDBService)
        {
            _cartoonStoreDBService = cartoonStoreDBService;
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