using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShopProject.Application.OrderItems.Dto;
using WebShopProject.Application.OrderItems.Queries.GetOrderItemsByOrderId;
using WebShopProject.Domain.Repositories;

namespace WebShopProject.Application.OrderItems.Queries.GetOrderItemByOrderAndProduct
{
    public class GetOrderItemsByOrderIdQueryHandler : IRequestHandler<GetOrderItemsByOrderIdQuery, IEnumerable<OrderItemDto>>
    {
        private readonly IOrderItemsRepository _orderItemsRepository;
        private readonly IMapper _mapper;

        public GetOrderItemsByOrderIdQueryHandler(IOrderItemsRepository orderItemsRepository, IMapper mapper)
        {
            _orderItemsRepository = orderItemsRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderItemDto>> Handle(GetOrderItemsByOrderIdQuery request, CancellationToken cancellationToken)
        {
            // Use the repository method to get all OrderItems for the given OrderId
            var orderItems = await _orderItemsRepository.GetOrderItemsByOrderId(request.OrderId);

            // Map the list of OrderItems to OrderItemDto
            var orderItemDtos = _mapper.Map<IEnumerable<OrderItemDto>>(orderItems);

            // Return the mapped DTOs
            return orderItemDtos;
        }
    }
}
