namespace AuthLearn.BLL.Base;

public interface ITokenService
{
    string GenerateToken(string email, string roleName);
}