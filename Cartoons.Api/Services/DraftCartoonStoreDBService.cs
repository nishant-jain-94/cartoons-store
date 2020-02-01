using System.Collections.Generic;
using System.Threading.Tasks;
using Cartoons.Models;
using MongoDB.Driver;

namespace Cartoons.Services
{
    public class DraftCartoonStoreDBService : IDraftCartoonStoreDBService
    {
        private readonly IMongoCollection<Cartoon> _readCartoon;
        private readonly IMongoCollection<Cartoon> _writeCartoon;

        public async Task<Cartoon> GetCartoonAsync(string id)
        {
            var cartoons = await this._readCartoon.FindAsync(cartoon => cartoon.Id == id);
            return await cartoons.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Cartoon>> GetCartoonsAsync()
        {
            var cartoons = await this._readCartoon.FindAsync(cartoon => true);
            return cartoons.ToList();
        }
        public async Task<Cartoon> AddCartoonAsync(Cartoon cartoon)
        {
            await _writeCartoon.InsertOneAsync(cartoon);
            return cartoon;
        }

        public async Task DeleteCartoonAsync(string id)
        {
            await this._writeCartoon.DeleteOneAsync(cartoon => cartoon.Id == id);
        }

        public async Task UpdateCartoonAsync(string id, Cartoon cartoonIn)
        {
            await this._writeCartoon.ReplaceOneAsync(cartoon => cartoon.Id == id, cartoonIn);
        }
    }
}