using AutoMapper;
using Core.Entites;
using Core.Entites.OrderEntities;
using Infrastracture.Interfaces;
using Infrastructure.Specification;
using Service.OrderService.Interface;
using Service.OrderService.Service.Dtos;

namespace Service.OrderService.Service
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<OrderDto> CreateOrderAsync(OrderDto orderDto)
        {
            var camp = await _unitOfWork.Reposatory<Camp>().GetByAsynsc(orderDto.PurchasedCampId);

            if (camp is null)
                return null;
            orderDto.TotalMoney = camp.RegistrationFees;

            var order = _mapper.Map<Order>(orderDto);

            await _unitOfWork.Reposatory<Order>().Add(order);
            var result = await _unitOfWork.Complete();
            if(result >  0)
                return orderDto;

            return null;


        }

        public async Task<OrderDto> GetOrderByIdForUserAsync(int id, string buyerEmail)
        {
            var specs = new OrderWithSpecification(id,buyerEmail);

            var order = await _unitOfWork.Reposatory<Order>().GetByIdWithSpecificationsAsync(specs);

            var mappedOrder = _mapper.Map<OrderDto>(order);

            return mappedOrder;
        }

        public async Task<IReadOnlyList<OrderDto>> GetOrderForUser(string buyerEmail)
        {
            var specs = new OrderWithSpecification(buyerEmail);

            var orders = await _unitOfWork.Reposatory<Order>().GetAllWithSpecificationsAsync(specs);

            var mappedOrders = _mapper.Map<IReadOnlyList<OrderDto>>(orders);

            return mappedOrders;
            
        }
    }
}
