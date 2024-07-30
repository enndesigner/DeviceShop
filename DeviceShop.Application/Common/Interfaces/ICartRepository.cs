using DeviceShop.Domain.Entity;

namespace DeviceShop.Application.Common.Interfaces
{
    public interface ICartRepository
    {
        Task<Cart> GetCartById(int id);

        Task<Cart> CreateCart(Cart cart);
        Task UpdateCart(Cart cart);

        Task DeleteCart(int id);
    }
}
