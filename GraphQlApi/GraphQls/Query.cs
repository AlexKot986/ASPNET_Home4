using Contracts.Response;
using HotChocolate.Authorization;

namespace GraphQlApi.GraphQls;


public class Query
{
    private readonly IGraphService _service;

    public Query(IGraphService service)
    {
        _service = service;
    }


    public async Task<ResultResponse?> SecretUser()
    => await _service.Get<ResultResponse>("https://localhost:7224/registration/secret-user") ;

    public async Task<ResultResponse?> SecretAdmin()
    => await _service.Get<ResultResponse>("https://localhost:7224/registration/secret-admin");
}
