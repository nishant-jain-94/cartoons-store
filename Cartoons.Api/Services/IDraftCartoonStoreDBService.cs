using Cartoons.Models;
using System.Threading.Tasks;

namespace Cartoons.Services
{
    public interface IDraftCartoonStoreDBService: ICartoonStoreDBService
    {
        Task<Cartoon> AddCartoonAsync(Cartoon cartoon);
        Task DeleteCartoonAsync(string id);
        Task UpdateCartoonAsync(string id, Cartoon cartoonIn);
    }
}