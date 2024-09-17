using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShopProject.Application.Orders.Dto;
using WebShopProject.Domain.Repositories;

namespace WebShopProject.Application.Orders.Queries.GetAllOrders
{
    public class GetAllOrdersQueryHandler(IOrdersRepository ordersRepository,
    IMapper mapper) : IRequestHandler<GetAllOrdersQuery, IEnumerable<OrderDto>>
    {
        public async Task<IEnumerable<OrderDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await ordersRepository.GetAllOrders();
            var ordersDtos = mapper.Map<IEnumerable<OrderDto>>(orders);
            return ordersDtos;
        }
    }
}
