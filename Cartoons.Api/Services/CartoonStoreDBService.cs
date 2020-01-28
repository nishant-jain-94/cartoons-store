using System.Threading.Tasks;
using Cartoons.Models;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;

namespace Cartoons.Services
{
    public class CartoonStoreDBService: ICartoonStoreDBService
    {
        private readonly IMongoCollection<Cartoon> _readCartoon;
        private readonly IMongoCollection<Cartoon> _writeCartoon;
    
        public CartoonStoreDBService(ICartoonStoreDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _readCartoon = database.GetCollection<Cartoon>(settings.CollectionName);
            _writeCartoon = _readCartoon;
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

        public async Task UpdateCartoonAsync(string id, Cartoon cartoonIn)
        {
            await this._writeCartoon.ReplaceOneAsync(cartoon => cartoon.Id == id, cartoonIn);
        }
    }
}