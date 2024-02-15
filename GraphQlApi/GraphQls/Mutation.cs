using Contracts;

namespace GraphQlApi.GraphQls;

public class Mutation
{
    private readonly IGraphService _service;

    public Mutation(IGraphService service)
    {
        _service = service;
    }


    public async Task<string> Login(UserAuthRequest request)
        => await _service.Post("https://localhost:7224/registration/login", request);

    public async Task<string> Register(UserAuthRequest request)
    => await _service.Post("https://localhost:7224/registration/register", request);


}
