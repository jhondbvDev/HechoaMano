using HechoaMano.Application.Common.Abstractions;
using HechoaMano.Application.Common.Errors;
using HechoaMano.Application.Products.Abstractions;
using HechoaMano.Domain.Products;
using MediatR;

namespace HechoaMano.Application.Products.Commands.UploadProducts;

public class UploadProductsCommandHandler(
    IProductRepository repository, 
    IFileDataExtractionService fileDataExtractionService,
    IUnitOfWork unitOfWork) : IRequestHandler<UploadProductsCommand>
{
    private readonly IProductRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    private readonly IFileDataExtractionService _fileDataExtractionService = fileDataExtractionService ?? throw new ArgumentNullException(nameof(fileDataExtractionService));
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

    public async Task Handle(UploadProductsCommand request, CancellationToken cancellationToken)
    {
        if (!_fileDataExtractionService.ExtractProductsFromFile(request.File, out List<Product> products))
        {
            throw new FileValidationException();
        }

        if (products.Count == 0)
        {
            throw new FileWithNoRecordsException();
        }

        await _repository.CreateProductsAsync(products);
        await _unitOfWork.SaveChangeAsync(cancellationToken);
    }
}
