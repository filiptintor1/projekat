using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Domain.Exceptions;
using WebShop.Domain.Repositories;
using WebShopProject.Application.Products.Dto;
using WebShopProject.Domain.Entities;

namespace WebShopProject.Application.Products.Queries.GetProductsByCategory
{
    internal class GetProductsByGenderQueryHandler(IMapper mapper, IProductsRepository productsRepository) : IRequestHandler<GetProductsByGenderQuery, IEnumerable<ProductDto>>
    {
        public async Task<IEnumerable<ProductDto>> Handle(GetProductsByGenderQuery request, CancellationToken cancellationToken)
        {
            var products = await productsRepository.GetProductsByGender(request.Gender)
                ?? throw new NotFoundException(nameof(Product), request.Gender.ToString());

            var productsDtos = mapper.Map<IEnumerable<ProductDto>>(products);
            return productsDtos;
        }
    }
}
