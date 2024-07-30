using DeviceShop.Application.Common.Models;
using DeviceShop.Domain.Entity;

namespace DeviceShop.Application.Common.Interfaces
{
    public interface ICartManager
    {
        Task<Cart> GetCartById(int id);
        Task<Cart> CreateCart(CreateCartModel model);

        Task UpdateCart(UpdateCartModel cart);

        Task DeleteCart(int id);
    }
}
