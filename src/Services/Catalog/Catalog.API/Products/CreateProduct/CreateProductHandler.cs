using MediatR;

namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string Name, List<string> Category, string description, string ImageFile, decimal Price)
        : IRequest<CreateProductResult>;
    public record CreateProductResult(Guid Id);
    internal class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
    {
        public Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            //Bussiness Logic to create a product
            throw new NotImplementedException();
        }
    }
}
