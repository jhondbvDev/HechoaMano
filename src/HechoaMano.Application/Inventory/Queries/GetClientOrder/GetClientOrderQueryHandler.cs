﻿using HechoaMano.Application.Clients.Abstractions;
using HechoaMano.Application.Common.Errors;
using HechoaMano.Application.Inventory.Abstractions;
using HechoaMano.Application.Inventory.Common;
using HechoaMano.Application.Products.Abstractions;
using Mapster;
using MediatR;

namespace HechoaMano.Application.Inventory.Queries.GetClientOrder
{
    public class GetClientOrderQueryHandler(
        IInventoryRepository inventoryRepository, 
        IClientRepository clientRepository,
        IProductRepository productRepository) : IRequestHandler<GetClientOrderQuery, DetailedClientOrderResult>
    {
        private readonly IInventoryRepository _inventoryRepository = inventoryRepository ?? throw new ArgumentNullException(nameof(inventoryRepository));
        private readonly IClientRepository _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
        private readonly IProductRepository _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));

        public async Task<DetailedClientOrderResult> Handle(GetClientOrderQuery request, CancellationToken cancellationToken)
        {
            var clientOrder = await _inventoryRepository.GetClientOrderAsync(request.OrderId) ?? throw new RecordNotFoundException(request.OrderId.ToString());
            
            var clientData = await _clientRepository.GetAsync(clientOrder.ClientId) ?? throw new RecordNotFoundException(clientOrder.ClientId.Value.ToString());

            //TODO: GetProduct Name per detail

            return clientOrder.Adapt<DetailedClientOrderResult>();
        }
    }
}
