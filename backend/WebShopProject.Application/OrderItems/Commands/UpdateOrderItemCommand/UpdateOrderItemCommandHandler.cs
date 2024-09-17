using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Domain.Entities;
using WebShop.Domain.Exceptions;
using WebShopProject.Domain.Repositories;

namespace WebShopProject.Application.OrderItems.Commands.UpdateOrderItemCommand
{
    public class UpdateOrderItemCommandHandler( IMapper mapper,
    IOrderItemsRepository orderItemRepository) : IRequestHandler<UpdateOrderItemCommand>
    {
        public async Task Handle(UpdateOrderItemCommand request, CancellationToken cancellationToken)
        {
            var oi = await orderItemRepository.GetOrderItemByOrderAndProduct(request.OrderId,request.ProductId);
            if (oi is null)
            {
                throw new NotFoundException(nameof(OrderItem), request.OrderId.ToString() +" + " +request.ProductId.ToString());

            }
            mapper.Map(request, oi);

            await orderItemRepository.SaveChanges();
        }
    }
}
