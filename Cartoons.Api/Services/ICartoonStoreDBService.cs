using System.Threading.Tasks;
using System.Collections.Generic;
using Cartoons.Models;

namespace Cartoons.Services
{
    public interface ICartoonStoreDBService
    {
        Task<IEnumerable<Cartoon>> GetCartoonsAsync();
        Task<Cartoon> GetCartoonAsync(string id);
    }
}