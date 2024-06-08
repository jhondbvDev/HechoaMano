using MediatR;

namespace HechoaMano.Application.Products.Commands.UploadProducts;

public class UploadProductsCommandHandler : IRequestHandler<UploadProductsCommand>
{
    public Task Handle(UploadProductsCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
