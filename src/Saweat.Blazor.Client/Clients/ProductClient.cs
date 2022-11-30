using Saweat.Application.Contracts.Products;
using Saweat.Blazor.Client.Common;

namespace Saweat.Blazor.Client.Clients;

public class ProductClient : BaseCrudClient<ProductForListDto>, IProductService
{

    public ProductClient(HttpClient httpClient) 
        : base(httpClient)
    {
    }

    protected override string BaseUrl => "products";
}
 