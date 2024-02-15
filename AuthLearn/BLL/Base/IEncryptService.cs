namespace AuthLearn.BLL.Base;

public interface IEncryptService
{
    byte[] GenerateSalt();
    byte[] HashPassword(string password, byte[] salt);
}