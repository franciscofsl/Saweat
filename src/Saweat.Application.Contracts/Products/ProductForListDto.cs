namespace Saweat.Application.Contracts.Products;

public class ProductForListDto
{
    public Guid Id => Guid.NewGuid();

    public string Code { get; set; }
}
