using Core.Entites.OrderEntities;
using Service.OrderService.Service.Dtos;

namespace Service.OrderService.Interface
{
    public interface IOrderService
    {
        Task<OrderDto> CreateOrderAsync(OrderDto orderDto);
        Task<IReadOnlyList<OrderDto>> GetOrderForUser(string buyerEmail);

        Task<OrderDto> GetOrderByIdForUserAsync(int id,string buyerEmail);

    }
}
