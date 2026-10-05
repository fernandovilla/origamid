namespace Ninegoldy.Services.PasswordHasher
{
    public class PasswordHasherService : IPasswordHasherService
    {
        private const int WorkFactor = 12;
        private const BCrypt.Net.HashType HashAlgorithm = BCrypt.Net.HashType.SHA256;

        public string Hash(string password)
        {
            return BCrypt.Net.BCrypt.EnhancedHashPassword(password, WorkFactor, HashAlgorithm);
        }

        public bool Verify(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(password, hashedPassword, HashAlgorithm);
        }
    }
}
