using HechoaMano.Application.Products.Common;
using HechoaMano.Domain.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HechoaMano.Application.Products.Queries
{
    public class GetProductQueryHandler : IRequestHandler<GetProductsQuery, List<ProductsResult>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductsResult>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
           var products = await _productRepository.GetAll();
            return products.Select(p => new ProductsResult
            (
                p.Id.Value,
                p.Name,
                p.Family.Name,
                p.SubFamily.Name,
                p.Region.Name,
                p.FamilyType.Name,
                p.Size.Name,
                p.SellPrice,
                p.BuyPrice )).ToList();
        }
    }
}
