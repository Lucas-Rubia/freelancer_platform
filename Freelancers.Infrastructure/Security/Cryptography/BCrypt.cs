using Freelancers.Domain.Security.Cryptography;
using BC = BCrypt.Net.BCrypt;

namespace Freelancers.Infrastructure.Security.Cryptography;

internal class BCrypt : IPasswordEncryption
{
    public string Encrypt(string password) => BC.HashPassword(password);
    

    public bool Verify(string password, string passwordHash) => BC.Verify(password, passwordHash);
}
