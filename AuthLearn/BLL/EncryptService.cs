using AuthLearn.BLL.Base;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Text;

namespace AuthLearn.BLL;

public class EncryptService : IEncryptService
{
    public byte[] GenerateSalt() => Encoding.UTF8.GetBytes(Guid.NewGuid().ToString());
    public byte[] HashPassword(string password, byte[] salt)
    {
        return KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA512,
            iterationCount: 10000,
            numBytesRequested: 512 / 8 // 512 bits (64 bytes)
            );
    }
}
