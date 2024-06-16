﻿using HechoaMano.Application.Common.Abstractions;
using HechoaMano.Application.Products.Abstractions;
using HechoaMano.Domain.Inventory.Events;
using HechoaMano.Domain.Products;
using MediatR;

namespace HechoaMano.Application.Products.Events;

public class EmployeeOrderCreatedHandler(IProductRepository productRepository, IUnitOfWork unitOfWork) : INotificationHandler<EmployeeOrderCreated>
{
    private readonly IProductRepository _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

    public async Task Handle(EmployeeOrderCreated notification, CancellationToken cancellationToken)
    {
        List<Product> productsToUpdate = [];

        foreach(var detail in notification.Order.Details)
        {
            var product = await _productRepository.GetProductAsync(detail.ProductId);
            product!.AddStock(detail.Quantity);

            productsToUpdate.Add(product);
        }

        _productRepository.UpdateProducts(productsToUpdate);
        await _unitOfWork.SaveChangeAsync(cancellationToken);
    }
}
