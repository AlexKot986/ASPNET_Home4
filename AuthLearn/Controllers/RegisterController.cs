using AuthLearn.BLL.Base;
using Contracts;
using Contracts.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthLearn.Controllers;

[Route("registration")]
[ApiController]
public class RegisterController : ControllerBase
{
    private readonly IAuthService _service;

    public RegisterController(IAuthService service)
	{
        _service = service;
    }

    [AllowAnonymous]
    [HttpPost(template:"login")]
    public async Task<IResult> Login([FromBody]UserAuthRequest request)
    {
        var result = await _service.Login(request);
        return result;
    }

    [AllowAnonymous]
    [HttpPost(template: "register")]
    public async Task<IResult> Register([FromBody] UserAuthRequest request)
    {
        var result = await _service.Register(request);
        return result;
    }


    [Authorize(Roles = "Administrator, User")]
    [HttpGet(template:"secret-user")]
    public ActionResult<ResultResponse> Secret()
    {
        return Ok(new ResultResponse { Success = true });
    }


    [Authorize(Roles = "Administrator")]
    [HttpGet(template: "secret-admin")]
    public ActionResult<ResultResponse> SecretAdmin()
    {
        return Ok(new ResultResponse {Success = true});
    }
}
