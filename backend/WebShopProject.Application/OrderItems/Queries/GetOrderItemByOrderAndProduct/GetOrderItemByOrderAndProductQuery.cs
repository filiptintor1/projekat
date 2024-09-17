using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShopProject.Application.OrderItems.Dto;

namespace WebShopProject.Application.OrderItems.Queries.GetOrderItemByOrderAndProduct
{
    public class GetOrderItemByOrderAndProductQuery : IRequest<OrderItemDto>
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }


        public GetOrderItemByOrderAndProductQuery(Guid orderId,Guid productId)
        {
            OrderId = orderId;
            ProductId = productId;
        }
    }
}
