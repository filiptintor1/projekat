using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Domain.Entities;
using WebShop.Domain.Exceptions;
using WebShopProject.Application.Orders.Dto;
using WebShopProject.Application.Orders.Queries.GetOrderById;
using WebShopProject.Domain.Repositories;

namespace WebShopProject.Application.Orders.Queries.GetOrderByUser
{
    public class GetOrderByUserQueryHandler(IMapper mapper, IOrdersRepository ordersRepository) : IRequestHandler<GetOrderByUserQuery, IEnumerable<OrderDto>>
    {
        public async Task<IEnumerable<OrderDto>> Handle(GetOrderByUserQuery request, CancellationToken cancellationToken)
        {
            var orders = await ordersRepository.GetOrderByUserId(request.UserId)
                ?? throw new NotFoundException(nameof(Order), request.UserId.ToString());
            var orderDto = mapper.Map<IEnumerable<OrderDto>>(orders);
            return orderDto;
        }
    }
}
