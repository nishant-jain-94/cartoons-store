using System.Threading.Tasks;
using System.Collections.Generic;
using Cartoons.Models;

namespace Cartoons.Services
{
    public interface ICartoonStoreDBService
    {
        Task<IEnumerable<Cartoon>> GetCartoonsAsync();
        Task<Cartoon> GetCartoonAsync(string id);
        Task<Cartoon> AddCartoonAsync(Cartoon cartoon);
        Task UpdateCartoonAsync(string id, Cartoon cartoon);
        Task DeleteCartoonAsync(string id);
    }
}