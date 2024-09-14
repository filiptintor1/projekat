using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShopProject.Application.Products.Dto;

namespace WebShopProject.Application.Products.Queries.GetProductsByCategory
{
    public class GetProductsByGenderQuery : IRequest<IEnumerable<ProductDto>>
    {
        public string Gender { get; init; }

        public GetProductsByGenderQuery(string gender)
        {
            Gender = gender;
        }
    }
}
