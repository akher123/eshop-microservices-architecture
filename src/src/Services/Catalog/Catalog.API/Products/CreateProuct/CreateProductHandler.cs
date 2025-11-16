
namespace Catalog.API.Products.CreateProuct;
public record CreateProductCommand(string Name,List<string>Category,string Description,string ImageFile,decimal Price):ICommand<CreateProductResult>;
public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required");
        RuleFor(x => x.Category)
          .NotEmpty()
          .WithMessage("Category is required");
        RuleFor(x => x.ImageFile)
          .NotEmpty()
          .WithMessage("ImageFile is required");
        RuleFor(x => x.Price)
         .GreaterThan(0)
         .WithMessage("Price must be greater than 0");
    }
}
public record CreateProductResult(Guid Id); 
public class CreateProductCommandHandler(IDocumentSession session,IValidator<CreateProductCommand> validator): ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        Product product = command.Adapt<Product>();
        session.Store(product);
        await session.SaveChangesAsync(cancellationToken);

        return new CreateProductResult(product.Id);
    }
}
