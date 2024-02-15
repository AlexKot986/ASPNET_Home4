using Contracts;

namespace AuthLearn.BLL.Base;

public interface IAuthService
{
    Task<IResult> Login(UserAuthRequest request);
    Task<IResult> Register(UserAuthRequest request);
}
